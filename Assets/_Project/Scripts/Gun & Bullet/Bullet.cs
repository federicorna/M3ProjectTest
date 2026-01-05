
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _lifeTime = 2f;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy (gameObject, _lifeTime);
    }

    public void SetDirection (Vector2 direction)
    {
        _rb.velocity = direction.normalized * _speed;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        LifeController life = other.GetComponent<LifeController>();

        if (life != null)
        {
            life.TakeDamage (_damage);
            Destroy (gameObject);
            return;
        }

        if (other.CompareTag ("Wall"))
        {
            Destroy (gameObject);
        }
    }
}
