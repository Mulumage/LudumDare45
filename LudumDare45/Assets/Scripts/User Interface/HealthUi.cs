using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField] private IntReference _maxHealth;
    [SerializeField] private IntReference _health;
    [SerializeField] private GameObject _fullHeartPrefab;
    [SerializeField] private GameObject _emptyHeartPrefab;

    [SerializeField] private BoolReference _fullHeartUnlocked;
    [SerializeField] private BoolReference _emptyHeartUnlocked;


    private void Awake()
    {
        _fullHeartUnlocked.Value = false;
        _emptyHeartUnlocked.Value = false;
    }

    private void Update()
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            var child = transform.GetChild(i);
            Destroy(child.gameObject);
        }

        for (var i = 0; i < _maxHealth.Value; i++)
        {
            if (i < _health.Value && _fullHeartUnlocked.Value)
                Instantiate(_fullHeartPrefab, transform);
            
            else if (i >= _health.Value && _emptyHeartUnlocked.Value)
                Instantiate(_emptyHeartPrefab, transform);            
        }
    }
}