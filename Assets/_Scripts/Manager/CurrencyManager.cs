using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    private int _money = 0;

    public void AddMoney(int value)
    {
        _money += value;
        print(_money);
    }

    public bool TrySpendMoney(int value)
    {
        if(_money > value)
        {
            return false;
        }

        _money -= value;
        return true;
    }
}
