using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Window.ShowProcessors
{
    public class ConsistentShowProcessor : IWindowShowProcessor
    {
        public async UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct)
        {
            foreach (WindowView openedWindow in openedWindows)
            {
                await openedWindow.Hide(ct);
            }

            await windowView.Show(ct);
            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            openedWindows.Clear();
            openedWindows.Add(windowView);
        }
    }
}