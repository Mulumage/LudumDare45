using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Fictions/References/Float")]
public class FloatReference : ScriptableObject
{
    [SerializeField] private float _value;

    public float Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChangedCallback(_value);
        } 
    }

    public event Action<float> OnValueChanged;

    protected virtual void ValueChangedCallback(float obj)
    {
        OnValueChanged?.Invoke(obj);
    }
}