using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _damage = 1f;

    private EnemyAnimation _enemyAnimation;
    private PlayerController _player;
    private Rigidbody2D _rb;

    void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _rb = GetComponent<Rigidbody2D>();
        _player = FindAnyObjectByType<PlayerController>();
    }

    void FixedUpdate()
    {
        if (_player == null) return;

        // blocca le spinte fisiche
        _rb.velocity = Vector2.zero;

        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (_player == null) return;

        Vector2 movingDirection = (_player.transform.position - transform.position).normalized;
        _enemyAnimation.SetHSpeedParam(movingDirection.x);
        _enemyAnimation.SetVSpeedParam(movingDirection.y);

        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
