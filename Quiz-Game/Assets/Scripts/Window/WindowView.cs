using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Window
{
    public abstract class WindowView : UIBehaviour
    {
        public abstract Type ServicedAdapterType { get; }

        public abstract void SetAdapter(IWindowAdapter adapter);
        
        public abstract void Show();
        public abstract void Hide();
    }

    public abstract class WindowView<T> : WindowView, IWindowView<T> where T : IWindowAdapter
    {
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

        protected virtual void SetAdapter(T adapter)
        {
            Adapter = adapter;
        }
    }
}