using Zenject;

namespace ShopSystem
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ItemsDatabase>().AsSingle();
            Container.Bind<SaveManager>().AsSingle();
        }
    }
}