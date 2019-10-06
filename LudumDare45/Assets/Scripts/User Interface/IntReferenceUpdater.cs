using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntReferenceUpdater : MonoBehaviour
{
    [SerializeField] private IntReference _intReference;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();   
    }

    private void Update()
    {
        _text.text = _intReference.Value.ToString();
    }
}
