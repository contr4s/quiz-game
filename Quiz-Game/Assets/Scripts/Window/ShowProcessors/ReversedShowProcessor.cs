using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Window.ShowProcessors
{
    public class ReversedShowProcessor : IWindowShowProcessor
    {
        public async UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct)
        {
            await windowView.Show(ct);
            
            foreach (WindowView openedWindow in openedWindows)
            {
                await openedWindow.Hide(ct);
            }
            
            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            openedWindows.Clear();
            openedWindows.Add(windowView);
        }
    }
}