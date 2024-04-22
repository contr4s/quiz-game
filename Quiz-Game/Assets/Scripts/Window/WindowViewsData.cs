using System;
using System.Collections.Generic;
using UnityEngine;

namespace Window
{
    [Serializable]
    public class WindowViewsData
    {
        [SerializeField] private WindowView[] windowViews;
        [SerializeField] private WindowView startWindow;
        
        public IReadOnlyList<WindowView> WindowViews => windowViews;
        public WindowView StartWindow => startWindow == null ? WindowViews[0] : startWindow;
    }
}