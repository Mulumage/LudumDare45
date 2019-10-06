using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private BoolReference _walkingReference;
    [SerializeField] private BoolReference _invisibleReference;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsInvincible = Animator.StringToHash("IsInvincible");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _walkingReference.OnValueChanged += SetWalking;
        _invisibleReference.OnValueChanged += SetInvisible;
    }

    private void OnDisable()
    {
        _walkingReference.OnValueChanged -= SetWalking;
        _invisibleReference.OnValueChanged -= SetInvisible;
    }


    private void SetWalking(bool value)
    {
        _animator.SetBool(IsWalking, value);
    }

    private void SetInvisible(bool value)
    {
        _animator.SetBool(IsInvincible, value);
    }
}