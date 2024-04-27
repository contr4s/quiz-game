using System;
using Window.Common;

namespace Window.AnswerResultWindow
{
    public class AnswerResultWindowModel : CallbackWindowModel
    {
        public bool IsCorrect { get; }
        
        public AnswerResultWindowModel(Action callback, bool isCorrect) : base(callback)
        {
            IsCorrect = isCorrect;
        }
    }
}