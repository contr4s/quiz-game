using System;
using Window.Common;

namespace Window.GameResultWindow
{
    public class GameResultWindowModel : CallbackWindowModel
    {
        public int TotalQuestions { get; }
        public int CorrectAnswers { get; }
        
        public GameResultWindowModel(Action callback, int totalQuestions, int correctAnswers) : base(callback)
        {
            TotalQuestions = totalQuestions;
            CorrectAnswers = correctAnswers;
        }
    }
}