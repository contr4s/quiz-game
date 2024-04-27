using System;

namespace Window.Common
{
    public class CallbackWindowModel
    {
        public Action Callback { get; }
        
        public CallbackWindowModel(Action callback)
        {
            Callback = callback;
        }
    }
}