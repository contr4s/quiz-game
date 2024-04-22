namespace Window
{
    public interface IWindowView<out T>
    {
        T Adapter { get; }
    }
}