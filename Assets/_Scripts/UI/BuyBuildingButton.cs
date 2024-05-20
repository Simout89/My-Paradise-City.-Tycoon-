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
    [SerializeField] private BaseBuilding baseBuilding;
    [SerializeField] private int MaxBuildingCount = 1;
    private int clickCount = 0;
    

    private Button button;

    [Inject]
    private CurrencyManager currencyManager;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        currencyManager.TrySpendMoney(Cost);
        clickCount++;
    }
    private void OnEnable()
    {

        currencyManager.OnValueChanged += HandleValueChaged;
    }
    private void OnDisable()
    {
        currencyManager.OnValueChanged -= HandleValueChaged;
    }
    private void HandleValueChaged(int obj)
    {
        if((obj >= Cost) && (clickCount < MaxBuildingCount))
        {
            button.interactable = true;
        }else
        {
            button.interactable = false; 
        }
    }
}
