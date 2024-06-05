using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class UpgradeMenu : MonoBehaviour
{
    public event Action OnUpgrade;

    [Inject]
    private HappyManager happyManager;
    [Inject]
    private CurrencyManager currencyManager;
    [Inject]
    private AudioManager audioManager;

    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text happyText;
    [SerializeField] private Button upgradeButton;

    private BaseBuilding selectedBuilding;

    private void Awake()
    {
        upgradeButton.onClick.AddListener(HandleUpgradeButton);
    }

    private void HandleUpgradeButton()
    {
        if(currencyManager.TrySpendMoney(selectedBuilding.GetNextLevel().MoneyCost) && happyManager.EnoughHappy(selectedBuilding.GetNextLevel().HappyCost))
        {
            selectedBuilding.Upgrade();
            WriteStats(selectedBuilding);
            OnUpgrade.Invoke();
        }
    }

    private void Update()
    {

        if (IsPointerOverBlockingUI())
        {
            // Курсор над UI элементом, не выполняем Raycast
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (SimpleInput.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.gameObject.TryGetComponent(out BaseBuilding baseBuilding))
            {
                ShowMenu();
                WriteStats(baseBuilding);
                selectedBuilding = baseBuilding;
                if(baseBuilding.UpgradeMenuClip != null)
                {
                    audioManager.PlayClip(baseBuilding.UpgradeMenuClip);
                }
            }
        }
    }

    private void WriteStats(BaseBuilding baseBuilding)
    {
        if(baseBuilding.GetLevel() != -1)
        {
            costText.text = baseBuilding.GetNextLevel().MoneyCost.ToString();
            happyText.text = baseBuilding.GetNextLevel().Happy.ToString();
        }else
        {
            costText.text = $"Max";
            happyText.text = $"Max";
        }
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }

    private bool IsPointerOverBlockingUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        foreach (RaycastResult result in raycastResults)
        {
            UIClickHandler clickHandler = result.gameObject.GetComponent<UIClickHandler>();
            if (clickHandler != null && clickHandler.isRaycastBlocking)
            {
                return true;
            }
        }

        return false;
    }
}
