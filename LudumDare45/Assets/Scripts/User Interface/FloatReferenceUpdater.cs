using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatReferenceUpdater : MonoBehaviour
{
    [SerializeField] private FloatReference _floatReference;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        var time = (int) _floatReference.Value;
        _text.text = time.ToString();
    }
}
