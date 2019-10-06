using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
    public float Speed = 100;
   
    private Vector2 _direction;
    private Rigidbody2D _rb;

    [SerializeField] private GameObject _spikePS;
    [SerializeField] private GameObject _hitAudio;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = Player.Instance.transform.position - transform.position;
        transform.up = _direction;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(_hitAudio);
        var go = Instantiate(_spikePS);
        go.transform.position = transform.position;
        Destroy(this.gameObject);
    }

    private void Update()
    {
        _rb.velocity = _direction.normalized * Speed;
    }
}
