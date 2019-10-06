using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnlockInterface : MonoBehaviour
{
    public static EnemyUnlockInterface Instance;

    [SerializeField] private BoolReference _hasSelected;
    [SerializeField] private Transform _unlockables;

    private void Awake()
    {
        Instance = this;
    }

    public void SetEnabled(bool value)
    {    
        _unlockables.gameObject.SetActive(value);
    }

    public bool IsAllUnlocked()
    {                
        SetEnabled(true);

        var buttons = GetComponentsInChildren<Button>();
        var output = buttons.ToList().TrueForAll(b => b.IsInteractable() == false);
        
        SetEnabled(false);
        return output;
    }
}