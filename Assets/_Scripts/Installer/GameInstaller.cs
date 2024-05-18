using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BuildingGrid>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ModeManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BuildingManager>().FromComponentInHierarchy().AsSingle();
    }
}