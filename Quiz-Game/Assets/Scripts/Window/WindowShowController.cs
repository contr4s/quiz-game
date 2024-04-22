using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Window
{
    public class WindowShowController : IWindowShowController, IInitializable
    {
        private readonly Dictionary<Type, WindowView> _windowViews;
        private readonly WindowViewsData _windowViewsData;
        
        private WindowView _currentWindow;
        
        public WindowShowController(WindowViewsData windowViewsData)
        {
            _windowViewsData = windowViewsData;
            _windowViews = windowViewsData.WindowViews.ToDictionary(x => x.GetType());
        }
        
        public void Initialize()
        {
            foreach (WindowView windowView in _windowViewsData.WindowViews)
            {
                windowView.Hide();
            }
            _windowViewsData.StartWindow.Show();
            _currentWindow = _windowViewsData.StartWindow;
        }

        public void SetNext<T>() where T : WindowView
        {
            if (!_windowViews.TryGetValue(typeof(T), out WindowView windowView))
            {
                Debug.LogError($"Window of type {typeof(T)} not found");
                return;
            }
            
            _currentWindow.Hide();
            windowView.Show();
            _currentWindow = windowView;
        }

        public void SetNext<TWindow, TModel>(TModel model) where TWindow : WindowView 
                                                           where TModel : IWindowModel
        {
            if (!_windowViews.TryGetValue(typeof(TWindow), out WindowView windowView))
            {
                Debug.LogError($"Window of type {typeof(TWindow)} not found");
                return;
            }

            if (windowView is not IWindowView<IWindowAdapter<TModel>> genericView)
            {
                Debug.LogError($"Window of type {typeof(TWindow)} is not a view for {typeof(TModel)} model type");

                return;
            }

            genericView.Adapter.Model = model;
            SetNext<TWindow>();
        }
    }
}