using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyBuildingButton : MonoBehaviour
{
    [SerializeField] private int Cost = 50;
    [SerializeField] private Building building;
    private Button button;

    [Inject]
    private SaveLoadSystem saveLoadSystem;
    [Inject]
    private BuildingGrid buildingGrid;
    [Inject]
    private CurrencyManager currencyManager;
    [Inject]
    private BuildingManager buildingManager;
    [Inject]
    private UtilitiesManager utilitiesManager;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
        button.interactable = false;
    }

    private void HandleClick()
    {
        currencyManager.TrySpendMoney(Cost);
        buildingGrid.StartPlacingBuilding(building);
    }
    private void OnEnable()
    {
        currencyManager.OnValueChanged += HandleValueChaged;
        buildingManager.OnBuildPlace += HandleBuildChaged;
        saveLoadSystem.DataLoaded += HandleDataLoaded;

    }
    private void OnDisable()
    {
        currencyManager.OnValueChanged -= HandleValueChaged;
        buildingManager.OnBuildPlace -= HandleBuildChaged;
        saveLoadSystem.DataLoaded -= HandleDataLoaded;

    }

    private void HandleDataLoaded()
    {
        HandleBuildChaged();
    }

    private void HandleBuildChaged()
    {
        BaseBuilding baseBuilding = building.GetComponent<BaseBuilding>();
        if ((buildingManager.GetBuildingCount(baseBuilding.buildingType) > baseBuilding.MaxBuilding))
        {
            button.interactable = false;
        }
    }

    private void HandleValueChaged(int obj)
    {
        BaseBuilding baseBuilding = building.GetComponent<BaseBuilding>();
        if ((obj >= Cost) &&
            (buildingManager.GetBuildingCount(baseBuilding.buildingType) < baseBuilding.MaxBuilding) && utilitiesManager.CheckUtilitiesWalidate(baseBuilding.WaterCost, baseBuilding.ElectricCost))
        {
            button.interactable = true;
        }else
        {
            button.interactable = false; 
        }
    }
}
