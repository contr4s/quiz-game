using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Window.ShowProcessors
{
    public class OverrideShowProcessor : IWindowShowProcessor
    {
        public async UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct)
        {
            await windowView.Show(ct);

            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            openedWindows.Add(windowView);
        }
    }
}