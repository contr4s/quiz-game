using Quiz;
using Window.Common;
using Window.ShowProcessors;

namespace Window.MainMenu
{
    public class MainMenuAdapter : IWindowAdapter<EmptyWindowModel>
    {
        private readonly IWindowShowController _windowShowController;
        private readonly QuizJsonParser _quizJsonParser;
        
        public MainMenuAdapter(IWindowShowController windowShowController, QuizJsonParser quizJsonParser)
        {
            _windowShowController = windowShowController;
            _quizJsonParser = quizJsonParser;
        }

        public void StartQuiz()
        {
            _quizJsonParser.Quiz.Reset();
            _windowShowController.Show<QuizWindow.QuizWindow, ReversedShowProcessor, QuizModel>(_quizJsonParser.Quiz);
        }

        void IWindowAdapter<EmptyWindowModel>.SetUp(EmptyWindowModel model) { }
    }
}