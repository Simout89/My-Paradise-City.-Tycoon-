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
    }
}