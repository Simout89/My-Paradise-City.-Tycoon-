using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class BaseBuilding: MonoBehaviour
{
    [HideInInspector] public bool flying = true;
    [SerializeField] private int PeopleSlot;
    public int PeopleCount { get; set; }
    public int MoneyMultiplayer = 1;
    [HideInInspector] public int UpgradeCount = 1;
    [HideInInspector] public int Money
    {
        get
        {
            return MoneyMultiplayer * UpgradeCount;
        }
    }
    [SerializeField] public int MaxBuilding;

    [SerializeField] private BuildingsScriptableObject[] buildingsScriptableObjects;

    private int CurrentLvl = 0;

    public BuildingsScriptableObject GetNextLevel()
    {
        return buildingsScriptableObjects[CurrentLvl];
    }
    public int GetLevel()
    {
        return CurrentLvl;
    }
    public void AddPeople()
    {
        PeopleSlot++;
    }

    public void RemovePeople()
    {
        PeopleSlot--;
    }

    public void Upgrade()
    {
        MoneyMultiplayer = buildingsScriptableObjects[CurrentLvl].MoneyMultiplayer;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(buildingsScriptableObjects[CurrentLvl].gameObject, transform);
        if(CurrentLvl + 1 < buildingsScriptableObjects.Length)
        {
            if(CurrentLvl != -1)
            {
                CurrentLvl++;
            }
        }else
        {
            CurrentLvl = -1;
        }
    }
}
