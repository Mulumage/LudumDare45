using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public IntReference Score;

    [SerializeField] private IntReference _health;
    [SerializeField] private IntReference _maxHealth;

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       var heart = other.gameObject.GetComponent<Heart>();
       
       if (heart == null)
           return;

       var health = _health.Value + heart.HealValue;
       if (health > _maxHealth.Value)
           health = _maxHealth.Value;

       _health.Value = health;
       Destroy(heart.gameObject);
    }
}