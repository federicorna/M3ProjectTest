
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _speed = 8f;
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _bulletLifeSpan = 5f;

    private Vector2 _direction;
    public Vector2 Direction => _direction;

    private Collider2D _collider;

    public void SetDirection(Vector2 dir)
    {
        _direction = dir.normalized;
    }
    void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        Destroy (gameObject, _bulletLifeSpan);
    }

    void Update()
    {
        transform.position = transform.position + (Vector3)_direction * (_speed * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        collision.collider.GetComponent<LifeController>()?.TakeDamage (_damage);

       // _bulletAnimation.SetColliderTrigger();
        _direction = Vector2.zero;
        _collider.enabled = false;
        Destroy(gameObject);
    }
}
