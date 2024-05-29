using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine; 
using Zenject;

public class SaveLoadSystem : MonoBehaviour
{

    [Inject]
    private BuildingGrid buildingGrid;

    [SerializeField] private BaseBuilding[] builds;

    public List<BuildingData> buildings = new List<BuildingData>();

    [Inject]
    private BuildingManager buildingManager;
    [Inject]
    private CurrencyManager currencyManager;


    public void SaveDate()
    {
        print("Save");
        ES3.DeleteKey("buildings");
        buildings.Clear();

        foreach (var building in buildingManager.building)
        {
            buildings.Add(new BuildingData(building.buildingType, building.Money, building.GetComponent<Building>().Size, building.placeX, building.placeY, building.GetLevel()));
        }
        ES3.Save("buildings", buildings);
        ES3.Save("Money", currencyManager._money);
    }

    public void LoadData()
    {
        print("Load");
        buildings = ES3.Load("buildings", buildings);
        currencyManager.SetMoney(ES3.Load("Money", currencyManager._money));
        foreach (var building in buildings)
        {
            buildingGrid.LoadBuild(building, builds[(int)building.buildingType]);
        }

    }
}