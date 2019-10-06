using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hog : MonoBehaviour
{
    public float Speed = 75;

    private Vector2 _direction;
    private Rigidbody2D _rb;
    
     [SerializeField] private SpriteRenderer _sr;

    private void Awake()
    {
        var random = Random.Range(0, 2);
        _direction = random == 0 ? Vector2.left : Vector2.right;
        _sr.flipX = _direction.x > 0;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = _direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        FlipDirection();
    }

    private void FlipDirection()
    {
        _direction *= -1;
        _sr.flipX = _direction.x > 0;
    }
}