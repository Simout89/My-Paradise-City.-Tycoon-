using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class BaseBuilding: MonoBehaviour
{
    [SerializeField] private int PeopleSlot;
    public int PeopleCount { get; set; }
    [SerializeField] public int MoneyMyltiplayer;
    [SerializeField] public int MaxBuilding;

    public bool GetState()
    {
        return true;
        if (gameObject.transform.GetComponentsInChildren<Human>().Length < PeopleSlot)
        {

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
}
