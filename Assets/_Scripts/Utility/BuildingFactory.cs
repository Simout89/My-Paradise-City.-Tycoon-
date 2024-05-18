using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.Cecil;

public class BuildingFactory : IBuildingFactory
{
    private DiContainer container;

    public BuildingFactory(DiContainer container)
    {
        this.container = container;
    }

    public IBuilding Create()
    {
        return container.InstantiatePrefabResource("BuildingPrefab").GetComponent<IBuilding>();
    }
}
