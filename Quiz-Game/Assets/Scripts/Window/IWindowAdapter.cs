using System;

namespace Window
{
    public interface IWindowAdapter
    {
        Type ServicedModelType { get; }
    }

    public interface IWindowAdapter<T> : IWindowAdapter where T : IWindowModel
    {
        Type IWindowAdapter.ServicedModelType => typeof(T);
        
        public T Model { get; set; }
    }
 }