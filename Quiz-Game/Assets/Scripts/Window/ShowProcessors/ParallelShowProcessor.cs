using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Window.ShowProcessors
{
    public class ParallelShowProcessor : IWindowShowProcessor
    {
        public async UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct)
        {
            var tasks = openedWindows.Select(x => x.Hide(ct)).ToList();
            tasks.Add(windowView.Show(ct));
            
            await UniTask.WhenAll(tasks);
            
            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            openedWindows.Clear();
            openedWindows.Add(windowView);
        }
    }
}