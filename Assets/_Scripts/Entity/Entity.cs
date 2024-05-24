using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private float Speed;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float ChangeDistanceLenght = 1;

    private bool move = true;

    private Transform selectedPoint;

    private EntityPath _entityPath;

    [Inject]
    public void Construct(EntityPath entityPath)
    {
        _entityPath = entityPath;
    }

    private void Awake()
    {
        GetPoint();
        
    }
    private void FixedUpdate()
    {
        CheckDistance();
        Move();
    }

    private void GetPoint()
    {
        if(_entityPath.LastPoint(transform))
            selectedPoint = _entityPath.GetNextPoint(transform);
        else
            move = false;

    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, selectedPoint.position) < ChangeDistanceLenght)
        {
            GetPoint();
        }
    }

    private void Move()
    {
        if(move)
        {

            Vector3 direction = (selectedPoint.position - transform.position).normalized;

            Vector3 newPosition = transform.position + direction * Speed * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * Speed);

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

        }    
    }

    public class Factory : PlaceholderFactory<Entity>
    {

    }
}
