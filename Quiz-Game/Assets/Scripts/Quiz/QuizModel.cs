using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz
{
    public class QuizModel
    {
        private readonly IReadOnlyList<QuizQuestion> _quizQuestions;
        private int _currentQuestionIndex;

        public int TotalQuestions => _quizQuestions.Count;
        public QuizQuestion CurrentQuestion => _quizQuestions[_currentQuestionIndex];
        public int CorrectQuestions => _quizQuestions.Count(x => x.IsCompleted && x.IsAnsweredCorrect);
        
        public QuizModel(IReadOnlyList<QuizQuestion> quizQuestions)
        {
            _quizQuestions = quizQuestions;
        }
        
        public void GoToNextQuestion()
        {
            if (_currentQuestionIndex >= _quizQuestions.Count - 1)
            {
                Debug.LogWarning("No more questions");
                return;
            }
            
            _currentQuestionIndex++;
        }
        
        public void Reset()
        {
            _currentQuestionIndex = 0;
            foreach (QuizQuestion question in _quizQuestions)
            {
                question.Reset();
            }
        }
    }
}