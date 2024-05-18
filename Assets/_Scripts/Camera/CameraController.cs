using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [Inject]
    private ModeManager modeManager;

    [SerializeField] private Transform target;
    private bool _move = true;
    private void OnEnable()
    {
        modeManager.OnModeChanged += HandleModeChanged;
    }
    private void OnDisable()
    {
        modeManager.OnModeChanged += HandleModeChanged;
    }
    private void HandleModeChanged(Modes modes)
    {
        switch (modes)
        {
            case Modes.Building:
                _move = false;
                break;
            case Modes.FreeMovement:
                _move = true;
                break;
        }
    }

    private void Update()
    {
        if(_move)
        {
            target.position = target.position + new Vector3(-SimpleInput.GetAxisRaw("Horizontal"), 0f, -SimpleInput.GetAxisRaw("Vertical"));
        }
    }
    private void LateUpdate()
    {
        if(_move)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        }
    }
}
