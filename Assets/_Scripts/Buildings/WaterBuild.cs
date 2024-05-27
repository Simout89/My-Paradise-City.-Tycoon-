using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuild : BaseBuilding
{
    [SerializeField] private int[] _waterOnLvl = new int[5];
    public int _water { get; private set; }

    private void Awake()
    {
        _water = _waterOnLvl[0];
    }

    public override void UpgradeSuccesful()
    {
        _water = _waterOnLvl[UpgradeCount - 1];
    }
}
