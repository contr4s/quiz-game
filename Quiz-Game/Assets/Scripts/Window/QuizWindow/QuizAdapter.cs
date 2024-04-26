using Quiz;

namespace Window.QuizWindow
{
    public class QuizAdapter : IWindowAdapter<QuizModel>
    {
        private QuizModel _quizModel;
        
        void IWindowAdapter<QuizModel>.SetUp(QuizModel model)
        {
            _quizModel = model;
        }
    }
}