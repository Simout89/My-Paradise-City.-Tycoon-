using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10,10);

    private Building[,] grid;
    private Building flyingBuilding;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if(flyingBuilding != null)
        {
            Destroy(flyingBuilding);
        }
        ModeManager.Instance.ChangeMode(Modes.Building);
        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if(flyingBuilding != null)
        {
            var groundPlace = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(groundPlace.Raycast(ray,out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool avaliable = true;

                if(x < 0 || x > GridSize.x - flyingBuilding.Size.x) avaliable = false;
                if(y < 0 || y > GridSize.y - flyingBuilding.Size.y) avaliable = false;

                if(avaliable && IsPlaceTaken(x, y)) avaliable = false;

                flyingBuilding.transform.position = new Vector3(x,0,y);
                flyingBuilding.SetTransparent(avaliable);

                if (avaliable && SimpleInput.GetMouseButton(0))
                {
                    PlaceFlyingBuilding(x, y);
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for(int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }

        flyingBuilding.SetNormal();
        ModeManager.Instance.ChangeMode(Modes.FreeMovement);
        flyingBuilding = null;
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new UnityEngine.Color(0.88f, 0f, 1f, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0f, y), new Vector3(1, 1, 1));
            }
        }
    }
}
