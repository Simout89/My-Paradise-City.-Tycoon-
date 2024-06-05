using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Building", menuName = "ScriptableObjects/Building")]
public class BuildingsScriptableObject : ScriptableObject
{
    [Header("Upgrade")]
    public int MoneyMultiplayer = 1;
    public int Happy = 1;
    [Header("Cost")]
    public int MoneyCost;
    public int HappyCost;
    public GameObject gameObject;
}
