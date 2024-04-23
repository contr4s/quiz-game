using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Window
{
    public abstract class WindowView : UIBehaviour
    {
        public abstract Type ServicedAdapterType { get; }

        public abstract void SetAdapter(IWindowAdapter adapter);
        
        public abstract void InstantlyShow();
        public abstract void InstantlyHide();
        
        public abstract UniTask Show(CancellationToken ct);
        public abstract UniTask Hide(CancellationToken ct);
    }

    public abstract class WindowView<T> : WindowView, IWindowView<T> where T : IWindowAdapter
    {
        [SerializeField] private WindowAnimation _animation;

        private bool _hasAnimation;
        
        public override Type ServicedAdapterType => typeof(T);
        
        public T Adapter { get; private set; }

        public sealed override void SetAdapter(IWindowAdapter adapter)
        { 
            if (adapter is T genericAdapter)
            {
                SetAdapter(genericAdapter);
            }
            else
            {
                Debug.LogError($"Can't set {adapter} adapter to {this} view");
            }
        }
        
        public sealed override async UniTask Show(CancellationToken ct)
        {
            Debug.Log($"Show {this}");
            InstantlyShow();
            if (_hasAnimation)
            {
                await _animation.ShowAnimation(ct);
            }

            if (ct.IsCancellationRequested)
            {
                InstantlyHide();
            }
        }

        public sealed override async UniTask Hide(CancellationToken ct)
        {
            Debug.Log($"Hide {this}");
            if (_hasAnimation)
            {
                await _animation.HideAnimation(ct);
            }

            if (ct.IsCancellationRequested)
            {
                return;
            }
            
            InstantlyHide();
        }

        protected virtual void SetAdapter(T adapter)
        {
            Adapter = adapter;
        }

        protected override void Awake()
        {
            base.Awake();
            _hasAnimation = _animation != null;
        }
    }
}