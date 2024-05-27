using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBuild : BaseBuilding
{
    [SerializeField] private int[] _electricOnLvl = new int[5];
    public int _electric { get; private set; }

    private void Awake()
    {
        _electric = _electricOnLvl[0];
    }

    public override void UpgradeSuccesful()
    {
        _electric = _electricOnLvl[UpgradeCount];
    }
}
