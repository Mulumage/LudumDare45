using UnityEngine;

public class PongMovement : MonoBehaviour
{
    public float Speed = 5;
    
    private Vector2 _direction;
    private Rigidbody2D _rb;


    private void Awake()
    { 
        _rb = GetComponent<Rigidbody2D>();
        RandomizeDirection();
    }

    private void Update()
    {
        _rb.velocity = _direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _direction = Vector2.Reflect(_direction, other.GetContact(0).normal);
    }


    private void RandomizeDirection()
    {
        _direction.x = Random.Range(-1f, 1f);
        _direction.y = Random.Range(-1f, 1f);
        _direction = _direction.normalized;

        _direction = Vector2.right + Vector2.up;
    }
}