using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Fictions/References/Int")]
public class IntReference : ScriptableObject
{
    [SerializeField] private int _value;
    [SerializeField] private int _resetValue;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChangedCallback(_value);
        } 
    }

    public event Action<int> OnValueChanged;

    protected virtual void ValueChangedCallback(int obj)
    {
        OnValueChanged?.Invoke(obj);
    }

    public void Reset()
    {
        _value = _resetValue;
    }
}