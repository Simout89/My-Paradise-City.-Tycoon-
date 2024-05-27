using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : ValueManager
{

    public int _money { get; private set; }
    private int _happy = 0;

    private void Awake()
    {
        ValueChanged(_money);
    }

    public void AddMoney(int value)
    {
        _money += value;
        Debug.Log(_money);
        ValueChanged(_money);
    }

    public bool TrySpendMoney(int value)
    {
        if(_money < value)
        {
            return false;
        }

        _money -= value;
        ValueChanged(_money);
        return true;
    }

    public void SetMoney(int value)
    {
        _money = value;
        ValueChanged(_money);

    }
}
