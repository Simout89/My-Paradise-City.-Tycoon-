using System;

interface IValueOnDisplay
{
    public event Action OnValueChanged;
    int value { get; set; }
}