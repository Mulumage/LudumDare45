using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private IntReference _startHealth;
    [SerializeField] private IntReference _health;

    [SerializeField] private BoolReference _isInvincible;
    [SerializeField] private AudioElement _hitAudio;
    [SerializeField] private GameObject _playerPS;
    
    
    private float _invisibleTime = 1.5f;
    private float _currentInvisibleTime;
    private AudioSource _audioSource;

    
    private void Awake()
    {
        _health.Value = _startHealth.Value;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_isInvincible.Value)
            return;

        _currentInvisibleTime += Time.deltaTime;

        if (_currentInvisibleTime < _invisibleTime)
            return;

        _currentInvisibleTime = 0;
        _isInvincible.Value = false;    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isInvincible.Value)
            return;

        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
            return;

        TakeDamage(enemy.DamageAmount);
        _hitAudio.Play(_audioSource);
        _isInvincible.Value = true;
    }

    private void TakeDamage(int value)
    {
        _health.Value -= value;
        CameraShake.Instance.Shake();

        var go = Instantiate(_playerPS);
        go.transform.position = transform.position;

        if (_health.Value <= 0)
            OnDeath();
    }

    private void OnDeath()
    {
        SceneManager.LoadScene("GameOver");
    }
}