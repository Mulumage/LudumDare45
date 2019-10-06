using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUnlockInterface : MonoBehaviour
{
    public static DungeonUnlockInterface Instance;

    [SerializeField] private BoolReference _hasSelected;
    [SerializeField] private Transform _unlockables;

    private void Awake()
    {
        Instance = this;
    }

    public void SetEnabled(bool value)
    {
        _unlockables.gameObject.SetActive(value);
        
        var buttons = GetComponentsInChildren<Button>();

        if (buttons.ToList().TrueForAll(b => b.IsInteractable() == false))
            _hasSelected.Value = true;
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