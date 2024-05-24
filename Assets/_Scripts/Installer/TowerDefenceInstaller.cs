using UnityEngine;
using Zenject;

public class TowerDefenceInstaller : MonoInstaller
{
    public GameObject entityPrefab;


    public override void InstallBindings()
    {
        EntityPath entityPath = FindObjectOfType<EntityPath>();
        Container.Bind<EntityPath>().FromInstance(entityPath).AsSingle();

        // ������������ Entity �� �������
        Container.BindFactory<Entity, Entity.Factory>()
            .FromComponentInNewPrefab(entityPrefab);
    }
}