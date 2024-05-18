using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class BaseBuilding: MonoBehaviour, IBuilding
{
    [Inject]
    private CurrencyManager currencyManager;

    [SerializeField] private int PeopleSlot;
    [SerializeField] private int MoneyMyltiplayer;

    [SerializeField] private float UpdatePerTime = 1f;
    private float time;

    private void Start()
    {
        time = UpdatePerTime;
    }

    private void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            HandleTick();
            time = UpdatePerTime;
        }
    }

    private void HandleTick()
    {
        TickUpdate();
        currencyManager.AddMoney(MoneyMyltiplayer);
    }

    public virtual void TickUpdate() { }

    private CurrencyManager _currencyManager;
    public void Intialize(CurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
    }

    public void AwakeBuilding()
    {

    }
}
