using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private ValueManager valueManager;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        valueManager.OnValueChanged += HandleValueChaged;
    }
    private void OnDisable()
    {
        valueManager.OnValueChanged -= HandleValueChaged;
    }
    private void HandleValueChaged(int value)
    {
        text.text = value.ToString();
    }
}
