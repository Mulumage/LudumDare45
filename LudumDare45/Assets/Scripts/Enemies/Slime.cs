using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private GameObject _slimePs;

    private Rigidbody2D _rb;
    private float _waitTime;
    private float _moveTime;

    private bool _isWalking;
    public float Speed = 100;

    private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    //Get's called by the animator
    public void StepEvent()
    {
        SpawnParticle();
    }

    private void Update()
    {
        if (_isWalking == false && _waitTime > 0)
        {
            _rb.velocity = Vector2.zero;
            _waitTime -= Time.deltaTime;
            return;
        }
        
        if (_waitTime <= 0)
        {
            _isWalking = false;
            _animator.SetBool(IsWalking, false);
            _waitTime = Random.Range(0.5f, 3f);
            _moveTime = Random.Range(0.5f, 1.75f);
        }

        MoveTowardsPlayer();
        _moveTime -= Time.deltaTime;

        if (_moveTime <= 0)
        {
            _isWalking = false;
            _animator.SetBool(IsWalking, false);
        }
    }

    private void MoveTowardsPlayer()
    {
        var direction = Player.Instance.transform.position - transform.position;
        _rb.velocity = direction.normalized * Speed * Time.deltaTime;
        _isWalking = true;
        _animator.SetBool(IsWalking, true);
    }


    private void SpawnParticle()
    {
        var ps = Instantiate(_slimePs);
        ps.transform.position = transform.position;
    }
}