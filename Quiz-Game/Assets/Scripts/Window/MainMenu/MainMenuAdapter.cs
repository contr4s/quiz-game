using Window.Common;
using Window.Quiz;

namespace Window.MainMenu
{
    public class MainMenuAdapter : IWindowAdapter<EmptyWindowModel>
    {
        private readonly IWindowShowController _windowShowController;
        
        public MainMenuAdapter(IWindowShowController windowShowController)
        {
            _windowShowController = windowShowController;
        }

        public void StartQuiz()
        {
            _windowShowController.SetNext<QuizWindow, QuizModel>(new QuizModel());
        }

        public EmptyWindowModel Model { get; set; }
    }
}