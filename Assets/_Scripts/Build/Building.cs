using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Renderer[] MainRenderer;
    public Vector2Int Size = Vector2Int.one;

    public void SetTransparent(bool avalibale)
    {
        if (avalibale)
            foreach (var renderer in MainRenderer)
            {
                renderer.material.color = Color.green;
            }
        else
            foreach (var renderer in MainRenderer)
            {
                renderer.material.color = Color.red;
            }
    }

    public void SetNormal()
    {
        foreach (var renderer in MainRenderer)
        {
            renderer.material.color = Color.white;
        }
    }

    private void OnDrawGizmosSelected()
    {
        for(int x = 0; x < Size.x; x++)
        {
            for(int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0f, y), new Vector3 (1,1,1));
            }
        }
    }
}
