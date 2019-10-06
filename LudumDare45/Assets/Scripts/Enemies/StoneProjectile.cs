using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneProjectile : MonoBehaviour
{
    public float Speed = 50;

    private Rigidbody2D _rb;

    [SerializeField] private GameObject _stonePS;
    [SerializeField] private GameObject _hitAudio;
    
    private void Start()
    {
        var direction = Player.Instance.transform.position - transform.position;
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = direction.normalized * Speed;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(_hitAudio);
        var go = Instantiate(_stonePS);
        go.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
