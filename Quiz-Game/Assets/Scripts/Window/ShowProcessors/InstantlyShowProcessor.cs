using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Window.ShowProcessors
{
    public class InstantlyShowProcessor : IWindowShowProcessor
    {
        public UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct)
        {
            foreach (WindowView openedWindow in openedWindows)
            {
                openedWindow.InstantlyHide();
            }
            
            windowView.InstantlyShow();
            openedWindows.Clear();
            openedWindows.Add(windowView);
            return UniTask.CompletedTask;
        }
    }
}