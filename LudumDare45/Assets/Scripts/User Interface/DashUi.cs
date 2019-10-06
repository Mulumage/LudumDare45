using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUi : MonoBehaviour
{
    [SerializeField] private Transform _dashTransform;
    [SerializeField] private FloatReference _dashTime;
    [SerializeField] private FloatReference _currentDashTime;

    private void OnEnable()
    {
        _currentDashTime.OnValueChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _currentDashTime.OnValueChanged -= UpdateBar;
    }

    private void UpdateBar(float value)
    {
        var distance = _currentDashTime.Value / _dashTime.Value;
        var scale = _dashTransform.localScale;
        scale.x = distance;
        _dashTransform.localScale = scale;
    }
}
