using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeMenu : MonoBehaviour
{
    [Inject]
    private CurrencyManager currencyManager;

    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button upgradeButton;

    private BaseBuilding selectedBuilding;

    private void Awake()
    {
        upgradeButton.onClick.AddListener(HandleUpgradeButton);
    }

    private void HandleUpgradeButton()
    {
        if(currencyManager.TrySpendMoney(selectedBuilding.GetNextLevel().Cost))
        {
            selectedBuilding.Upgrade();
            WriteStats(selectedBuilding);
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (SimpleInput.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.gameObject.TryGetComponent(out BaseBuilding baseBuilding))
            {
                ShowMenu();
                WriteStats(baseBuilding);
                selectedBuilding = baseBuilding;
            }
        }
    }

    private void WriteStats(BaseBuilding baseBuilding)
    {
        if(baseBuilding.GetLevel() != -1)
        {
            costText.text = $"Upgrade cost: {baseBuilding.GetNextLevel().Cost}\n" +
                    $"MoneyMultiplaer: {baseBuilding.GetNextLevel().MoneyMultiplayer}\n" +
                    $"HappyMultiplaer: {baseBuilding.GetNextLevel().HappyMultiplayer}\n";
        }else
        {
            costText.text = $"Upgrade cost: MAX\n" +
                    $"MoneyMultiplaer: MAX\n" +
                    $"HappyMultiplaer: MAX\n";
        }
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
