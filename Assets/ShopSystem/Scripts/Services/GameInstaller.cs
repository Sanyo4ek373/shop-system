using Zenject;

namespace ShopSystem
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ItemDatabase>().AsSingle();
            Container.Bind<SaveManager>().AsSingle();
        }
    }
}