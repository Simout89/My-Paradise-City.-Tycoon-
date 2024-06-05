using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BuildingGrid>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ModeManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<BuildingManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<TimeManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<CurrencyManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<SaveLoadSystem>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<UtilitiesManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<UpgradeMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<HappyManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}