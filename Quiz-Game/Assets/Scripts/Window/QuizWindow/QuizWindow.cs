using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Window.Common;
using Window.QuizWindow.Elements;

namespace Window.QuizWindow
{
    public class QuizWindow : CanvasWindowView<QuizAdapter>
    {
        [SerializeField] private RawImage background;
        [SerializeField] private TMP_Text questionText;
        [SerializeField] private Button checkButton;
        [SerializeField] private AnswerVariant answerVariantPrefab;
        [SerializeField] private Transform answerVariantsContainer;
        [SerializeField] private QuestionMark questionMarkPrefab;
        [SerializeField] private Transform questionMarksContainer;
        
        private List<AnswerVariant> _spawnedQuizAnswerVariants = new List<AnswerVariant>();
        private List<QuestionMark> _spawnedQuestionMarks = new List<QuestionMark>();
        private HashSet<string> _selectedAnswers = new HashSet<string>();

        protected override void SetAdapter(QuizAdapter adapter)
        {
            base.SetAdapter(adapter);
            adapter.OnPrepared += SetUpQuestionMarks;
            adapter.CurrentQuestion.OnChanged += UpdateQuestion;
            checkButton.onClick.AddListener(CheckAnswer);
        }

        public override void InstantlyHide()
        {
            base.InstantlyHide();
            foreach (QuestionMark questionMark in _spawnedQuestionMarks)
            {
                Adapter.ReturnToPool(questionMark);
            }
            _spawnedQuestionMarks.Clear();
        }

        private void SetUpQuestionMarks()
        {
            for (int i = 0; i < Adapter.TotalQuestions; i++)
            {
                QuestionMark questionMark = Adapter.GetFromPool(questionMarkPrefab);
                questionMark.transform.SetParent(questionMarksContainer, false);
                questionMark.SetQuestionNumber(i + 1);
                _spawnedQuestionMarks.Add(questionMark);
            }
        }

        private void UpdateQuestion(int _)
        {
            foreach (AnswerVariant spawnedQuizAnswerVariant in _spawnedQuizAnswerVariants)
            {
                spawnedQuizAnswerVariant.OnSelectedStatusChanged -= AnswerSelectionHandler;
                Adapter.ReturnToPool(spawnedQuizAnswerVariant);
            }
            _spawnedQuizAnswerVariants.Clear();
            _selectedAnswers.Clear();
            
            checkButton.interactable = false;
            background.texture = Adapter.CurrentQuestionTexture;
            questionText.text = Adapter.CurrentQuestionText;
            _spawnedQuestionMarks[Adapter.CurrentQuestion.Value].SetSelected();

            foreach (string answer in Adapter.CurrentQuestionAnswers)
            {
                AnswerVariant answerVariant = Adapter.GetFromPool(answerVariantPrefab);
                answerVariant.transform.SetParent(answerVariantsContainer, false);
                answerVariant.Text = answer;
                answerVariant.OnSelectedStatusChanged += AnswerSelectionHandler;
                _spawnedQuizAnswerVariants.Add(answerVariant);
            }
        }

        private void AnswerSelectionHandler(string answer, bool isSelected)
        {
            if (isSelected)
            {
                _selectedAnswers.Add(answer);
            }
            else
            {
                _selectedAnswers.Remove(answer);
            }

            checkButton.interactable = _selectedAnswers.Any();
        }

        private void CheckAnswer()
        {
            bool correct = Adapter.CheckAnswer(_selectedAnswers);
            _spawnedQuestionMarks[Adapter.CurrentQuestion.Value].SetFinished(correct);
        }
    }
}