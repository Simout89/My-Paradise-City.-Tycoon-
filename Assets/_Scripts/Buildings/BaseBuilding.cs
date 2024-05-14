using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuilding: MonoBehaviour
{
    [SerializeField] private int PeopleSlot;
    [SerializeField] private int MoneyMyltiplayer;
    private void OnEnable()
    {
        TimeManager.Instance.OnTick += HandleTick;
    }

    private void OnDisable()
    {
        TimeManager.Instance.OnTick -= HandleTick;
    }

    private void HandleTick()
    {
        TickUpdate();
        CurrencyManager.Instance.AddMoney(MoneyMyltiplayer);
    }

    public virtual void TickUpdate() { }
}
