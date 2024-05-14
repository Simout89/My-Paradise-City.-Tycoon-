using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public event Action OnTick;

    [SerializeField] private float UpdatePerTime = 1f;
    private float time;

    private void Start()
    {
        time = UpdatePerTime;
    }

    private void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if(time <= 0)
        {
            OnTick?.Invoke();
            time = UpdatePerTime;
        }
    }
}
