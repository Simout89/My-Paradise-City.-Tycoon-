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
    private BuildingGrid buildingGrid;
    [Inject]
    private CurrencyManager currencyManager;
    [Inject]
    private BuildingManager buildingManager;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
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
    }
    private void OnDisable()
    {
        currencyManager.OnValueChanged -= HandleValueChaged;
        buildingManager.OnBuildPlace -= HandleBuildChaged;
    }

    private void HandleBuildChaged()
    {
        if((buildingManager.GetBuildingCount(building.GetComponent<BaseBuilding>().index) > building.GetComponent<BaseBuilding>().MaxBuilding))
        {
            button.interactable = false;
        }
    }

    private void HandleValueChaged(int obj)
    {
        if((obj >= Cost) &&
            (buildingManager.GetBuildingCount(building.GetComponent<BaseBuilding>().index) < building.GetComponent<BaseBuilding>().MaxBuilding))
        {
            button.interactable = true;
        }else
        {
            button.interactable = false; 
        }
    }
}
