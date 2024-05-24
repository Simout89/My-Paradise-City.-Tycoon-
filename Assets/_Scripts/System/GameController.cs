using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private EntityPath entityPath;


    [Inject]
    Entity.Factory entityFactory;

    private void Awake()
    {
        Entity newEntity = entityFactory.Create();
        newEntity.transform.position = entityPath.FirstPoint().position;
    }
}
