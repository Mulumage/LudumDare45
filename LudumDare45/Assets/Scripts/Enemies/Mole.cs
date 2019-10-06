using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float Speed = 100;

    private bool _directionSet;
    private bool _isMoving;

    private float _movementTime;
    private float _waitTime;
    private float _maxWaitTime = 2;

    private Vector2 _direction;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
}
