using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatReference _speed;
    [SerializeField] private FloatReference _dashSpeed;
    [SerializeField] private FloatReference _dashTime;
    [SerializeField] private FloatReference _currentDashTime;

    [SerializeField] private BoolReference _isWalking;
    [SerializeField] private GameObject _dashParticleSystem;
    
    [SerializeField] private AudioElement _audioElement;
    private AudioSource _audioSource;

    private bool _isDashing = true;
    private float _dashWaitTime;

    private Vector3 _direction;
    private Vector3 _nextPosition;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _currentDashTime.Value = _dashTime.Value;
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isDashing)
        {
            DashTick();
            return;
        }
        
        SetDirection();
        
        if (!_isDashing)
            Dash();
        
        Move();
    }

    private void SetDirection()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        _isWalking.Value = _direction != Vector3.zero;
    }

    private void Move()
    {
        _rb.velocity = _direction * _speed.Value;
    }

    private void DashTick()
    {
        if (_currentDashTime.Value > 0)
        {
            _rb.velocity = _direction * _dashSpeed.Value;
            _currentDashTime.Value -= Time.deltaTime;
            return;
        }

        _currentDashTime.Value = _dashTime.Value;
        _isDashing = false;
    }

    private void Dash()
    {
        if (_direction == Vector3.zero)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        _audioElement.Play(_audioSource);
        var dashObject = Instantiate(_dashParticleSystem);
        dashObject.transform.position = transform.position;
        _isDashing = true;
    }
}