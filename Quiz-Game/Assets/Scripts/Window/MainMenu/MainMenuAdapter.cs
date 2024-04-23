using Window.Common;
using Window.Quiz;
using Window.ShowProcessors;

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
            _windowShowController.Show<QuizWindow, ReversedShowProcessor, QuizModel>(new QuizModel());
        }

        public EmptyWindowModel Model { get; set; }
    }
}