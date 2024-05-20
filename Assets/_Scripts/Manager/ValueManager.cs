using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueManager : MonoBehaviour
{
    public event Action<int> OnValueChanged;

    public void ValueChanged(int value)
    {
        OnValueChanged?.Invoke(value);
    }
}
