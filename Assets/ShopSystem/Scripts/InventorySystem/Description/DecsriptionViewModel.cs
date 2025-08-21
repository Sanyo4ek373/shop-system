using UnityEngine;
using Zenject;

namespace ShopSystem
{
    public class DescriptionViewModel : MonoInstaller
    {
        [SerializeField] private DescriptionView _view;

        public override void InstallBindings()
        {
            Container.Bind<DescriptionViewModel>().FromInstance(this).AsSingle();
        }

        public void ShowDescription(BaseItem item)
        {
            _view.ShowDescription(item);
        }
    }
}