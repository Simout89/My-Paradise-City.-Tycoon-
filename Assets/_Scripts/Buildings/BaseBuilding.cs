using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;


[Serializable]
public abstract class BaseBuilding: MonoBehaviour
{
    [HideInInspector] public bool flying = true;
    [SerializeField] public int index;
    [SerializeField] private int PeopleSlot;
    [SerializeField] public BuildingType buildingType;
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

    [HideInInspector] public int placeX;
    [HideInInspector] public int placeY;

    public BuildingsScriptableObject GetNextLevel()
    {
        return buildingsScriptableObjects[CurrentLvl];
    }
    public int GetLevel()
    {
        return CurrentLvl;
    }
    public void SetLevel(int lvl)
    {
        while (CurrentLvl != lvl) {
            MoneyMultiplayer = buildingsScriptableObjects[CurrentLvl].MoneyMultiplayer;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Instantiate(buildingsScriptableObjects[CurrentLvl].gameObject, transform);
            if (CurrentLvl + 1 < buildingsScriptableObjects.Length)
            {
                if (CurrentLvl != -1)
                {
                    CurrentLvl++;
                }
            }
            else
            {
                CurrentLvl = -1;
            }
        }
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
