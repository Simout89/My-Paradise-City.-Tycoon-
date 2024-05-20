using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Building", menuName = "ScriptableObjects/Building")]
public class BuildingsScriptableObject : ScriptableObject
{
    public int MoneyMultiplayer = 1;
    public int HappyMultiplayer = 1;
    public int Cost;
    public GameObject gameObject;
}
