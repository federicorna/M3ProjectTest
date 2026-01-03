using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private EnemyAnimation _enemyAnimation;
    private PlayerController _player;

    void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (_player)
        {
            EnemyMovement();
        }
    }

    public void EnemyMovement()
    {
        Vector3 movingDirection = (_player.transform.position - transform.position).normalized;
        _enemyAnimation.SetHSpeedParam(movingDirection.x);
        _enemyAnimation.SetVSpeedParam(movingDirection.y);
        transform.position = transform.position + movingDirection * (_speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            if (player.TryGetComponent<LifeController>(out var playerLifeController))
            Destroy(_player.gameObject);
        }

    }

}
