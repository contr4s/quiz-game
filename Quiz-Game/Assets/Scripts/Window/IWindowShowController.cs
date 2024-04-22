namespace Window
{
    public interface IWindowShowController
    {
        void SetNext<T>() where T : WindowView;

        void SetNext<TWindow, TModel>(TModel model) where TModel : IWindowModel 
                                                    where TWindow : WindowView;
    }
}