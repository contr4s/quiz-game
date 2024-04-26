using Zenject;

namespace Util
{
    public class UtilsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ImageLoader>().AsSingle();
        }
    }
}