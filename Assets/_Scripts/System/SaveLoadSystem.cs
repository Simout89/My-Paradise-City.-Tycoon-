using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SaveLoadSystem : MonoBehaviour
{
    public event Action DataLoaded;

    private bool _reset = false;

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
        DataLoaded?.Invoke();
    }

    public void Reset()
    {
        _reset = true;
        ES3.DeleteFile();
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        LoadData();
    }

    private void OnApplicationQuit()
    {
        if(!_reset)
            SaveDate();
    }
}
