using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Fictions/References/Bool")]
public class BoolReference : ScriptableObject
{
    [SerializeField] private bool _value;

    public bool Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChangedCallback(_value);
        } 
    }

    public event Action<bool> OnValueChanged;

    protected virtual void ValueChangedCallback(bool obj)
    {
        OnValueChanged?.Invoke(obj);
    }
}