using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPath : MonoBehaviour
{
    [SerializeField] private Transform[] pathPoints;


    public Transform GetNextPoint(Transform transform)
    {
        Transform nearestPoint = pathPoints[0];
        int PathIndex = 0;

        for (int i = 0;i < pathPoints.Length; i ++)
        {
            if (Vector3.Distance(transform.position, nearestPoint.position) > Vector3.Distance(transform.position, pathPoints[i].position))
            {
                nearestPoint = pathPoints[i];
                PathIndex = i;
            }
        }

        return pathPoints[PathIndex + 1];
    }

    public bool LastPoint(Transform transform)
    {
        Transform nearestPoint = pathPoints[0];
        int PathIndex = 0;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (Vector3.Distance(transform.position, nearestPoint.position) > Vector3.Distance(transform.position, pathPoints[i].position))
            {
                nearestPoint = pathPoints[i];
                PathIndex = i;
            }
        }

        if(PathIndex + 1 >= pathPoints.Length)
            return false;
        else
            return true;
    }

    public Transform FirstPoint()
    {
        return pathPoints[0];
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            if (pathPoints[i + 1] == null)
                return;

            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }
    }
}
