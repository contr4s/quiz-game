using System;
using System.Collections.Generic;
using System.Linq;
using Quiz;
using UnityEngine;
using Util.ObjectPool;
using Util.Rx;
using Window.AnswerResultWindow;
using Window.GameResultWindow;
using Window.MainMenu;
using Window.ShowProcessors;

namespace Window.QuizWindow
{
    public class QuizAdapter : IWindowAdapter<QuizModel>
    {
        public event Action OnPrepared; 
        
        private readonly CallbackProperty<int> _currentQuestion = new CallbackProperty<int>();

        private readonly IPoolingObjectsProvider _poolingObjectsProvider;
        private readonly IWindowShowController _windowShowController;
        
        private QuizModel _quizModel;

        public int TotalQuestions => _quizModel.TotalQuestions;
        public int CorrectQuestions => _quizModel.CorrectQuestions;
        
        public ICallbackProperty<int> CurrentQuestion => _currentQuestion;
        public string CurrentQuestionText => _quizModel.CurrentQuestion.Question;
        public Texture2D CurrentQuestionTexture => _quizModel.CurrentQuestion.BackgroundTexture;
        public IReadOnlyCollection<string> CurrentQuestionAnswers =>
                _quizModel.CurrentQuestion.AnswerVariants.Select(x => x.Text).ToList();
        
        public QuizAdapter(IPoolingObjectsProvider poolingObjectsProvider, IWindowShowController windowShowController)
        {
            _poolingObjectsProvider = poolingObjectsProvider;
            _windowShowController = windowShowController;
        }
        
        public bool CheckAnswer(IReadOnlyCollection<string> answers)
        {
            bool res = _quizModel.CurrentQuestion.CheckAnswer(answers);
            Action nextAction = _currentQuestion.Value < TotalQuestions - 1 ? GoToNextQuestion : ShowQuizResult;
            _windowShowController.Show<AnswerResultWindowView, OverrideShowProcessor, AnswerResultWindowModel>(new AnswerResultWindowModel(nextAction, res));
            return res;
        }

        public T GetFromPool<T>(T prefab) where T : Component => _poolingObjectsProvider.GetFromPool(prefab);
        public void ReturnToPool<T>(T obj) where T : Component => _poolingObjectsProvider.ReturnToPool(obj);

        private void ShowQuizResult()
        {
            _windowShowController.Show<GameResultWindowView, ParallelShowProcessor, GameResultWindowModel>(
                    new GameResultWindowModel(
                            () => _windowShowController.Show<MainMenuWindowView, ReversedShowProcessor>(),
                            CorrectQuestions,
                            TotalQuestions));
        }
        
        private void GoToNextQuestion()
        {
            _quizModel.GoToNextQuestion();
            _currentQuestion.Value++;
        }

        void IWindowAdapter<QuizModel>.SetUp(QuizModel model)
        {
            _quizModel = model;
            OnPrepared?.Invoke();
            _currentQuestion.Value = 0;
        }
    }
}