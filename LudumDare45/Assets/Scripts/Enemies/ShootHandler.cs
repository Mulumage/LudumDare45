using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

//Used by the animator
    public void ShootEvent()
    {
        var go = Instantiate(_projectile);
        go.transform.position = transform.position;
    }
}
