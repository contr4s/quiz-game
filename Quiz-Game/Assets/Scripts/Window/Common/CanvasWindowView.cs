using UnityEngine;

namespace Window.Common
{
    public abstract class CanvasWindowView<T> : WindowView<T> where T : IWindowAdapter
    {
        [SerializeField] private Canvas canvas;

        public override void InstantlyShow()
        {
            canvas.enabled = true;
        }

        public override void InstantlyHide()
        {
            canvas.enabled = false;
        }
    }
}