﻿using Extensions;
using UnityEngine;
using Zenject;

namespace Window
{
    public class WindowSystemInstaller : MonoInstaller
    {
        [SerializeField] private WindowViewsData _windowsViews;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_windowsViews);
            Container.BindAllImplementationsOfType<IWindowAdapter>();
            Container.BindAllImplementationsOfType<IWindowShowProcessor>();
            Container.BindInterfacesTo<WindowInitializer>().AsSingle();
            Container.BindInterfacesTo<WindowShowController>().AsSingle();
        }
    }
}