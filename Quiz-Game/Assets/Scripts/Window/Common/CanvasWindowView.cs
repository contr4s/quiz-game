using UnityEngine;

namespace Window.Common
{
    public abstract class CanvasWindowView<T> : WindowView<T> where T : IWindowAdapter
    {
        [SerializeField] private Canvas canvas;
        
        public override void Show()
        {
            canvas.enabled = true;
        }

        public override void Hide()
        {
            canvas.enabled = false;
        }
    }
}