using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AirPort : BaseBuilding
{
    [Inject]
    private BuildingManager buildingManager;

    private List<Human> humanList = new List<Human>();

    [SerializeField] private Human human;
    private void Awake()
    {
        SpawnPeople();
    }

    private void SpawnPeople()
    {
        for (int i = 0; i < 10; i++)
        {
            humanList.Add(Instantiate(human, transform));
        }
    }

    private void FixedUpdate()
    {
        //int key = buildingManager.GetFreeBuilding();
        //if (-1 != key)
        //{
        //    if (buildingManager.building.TryGetValue(key, out BaseBuilding baseBuilding))
        //    {
        //        humanList[0].transform.parent = baseBuilding.transform;
        //        humanList.RemoveAt(0);
        //        baseBuilding.AddPeople();
        //    }
        //}
    }
}
