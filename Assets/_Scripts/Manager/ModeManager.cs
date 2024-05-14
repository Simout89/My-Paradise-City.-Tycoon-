using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ModeManager : Singleton<ModeManager>
{
    public event Action<Modes> OnModeChanged;

    private Modes _mode = Modes.FreeMovement;

    public void ChangeMode(Modes mode)
    {
        _mode = mode;
        OnModeChanged?.Invoke(_mode);
    }
}



public enum Modes
{
    Building,
    FreeMovement
}
