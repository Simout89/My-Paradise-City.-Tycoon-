using System;
using UnityEngine;


[Serializable]
public class BuildingData
{
    public int Money;
    public int Lvl;
    public int PlaceX; public int PlaceY;
    public Vector2Int Size;
    public BuildingType buildingType;

    public BuildingData(BuildingType buildingType, int money, Vector2Int size, int placeX, int placeY, int lvl)
    {
        this.buildingType = buildingType;
        Money = money;
        Size = size;
        PlaceX = placeX;
        PlaceY = placeY;
        Lvl = lvl;
    }
}

[Serializable]
public enum BuildingType
{
    AirPort,
    Motel,
    Water,
    Electic
}