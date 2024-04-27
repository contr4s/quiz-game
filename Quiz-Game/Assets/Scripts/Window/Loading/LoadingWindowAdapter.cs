using System.Threading;
using Cysharp.Threading.Tasks;
using Quiz;
using Window.Common;
using Window.MainMenu;
using Window.ShowProcessors;

namespace Window.Loading
{
    public class LoadingWindowAdapter : IWindowAdapter
    {
        private readonly QuizJsonParser _quizJsonParser;
        private readonly IWindowShowController _windowShowController;
        
        public LoadingWindowAdapter(QuizJsonParser quizJsonParser, IWindowShowController windowShowController)
        {
            _quizJsonParser = quizJsonParser;
            _windowShowController = windowShowController;
        }

        public void Load()
        {
            LoadJson().Forget();
        }

        private async UniTaskVoid LoadJson()
        {
            await _quizJsonParser.Parse(CancellationToken.None);
            _windowShowController.Show<MainMenuWindowView, ReversedShowProcessor>();
        }
    }
}