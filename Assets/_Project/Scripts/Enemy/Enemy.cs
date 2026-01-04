using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float damageCooldown = 0.5f;   //Cooldown tra attacchi

    private float lastDamageTime;
    private PlayerController _player;
    private Rigidbody2D _rb;
    private EnemyAnimation _enemyAnimation;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _player = FindAnyObjectByType<PlayerController>();
    }

    void FixedUpdate()
    {
        if (_player == null) return;

        _rb.velocity = Vector2.zero;    //Blocca le spinte del player  

        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (_player == null) return;

        Vector2 movingDirection = (_player.transform.position - transform.position).normalized; //Direzione enemy

        _enemyAnimation.SetHSpeedParam (movingDirection.x);  //Passaggio a EnemyAnimation.cs
        _enemyAnimation.SetVSpeedParam (movingDirection.y);

        _rb.MovePosition(Vector2.MoveTowards(transform.position, _player.transform.position, (_speed * Time.deltaTime)));
    }

    private void OnCollisionStay2D (Collision2D collision)
    {
        if (!collision.gameObject.CompareTag ("Player")) return;    //cio che collide != tag, return

        if (Time.time < lastDamageTime + damageCooldown) return;

        LifeController life = collision.gameObject.GetComponent<LifeController>();  //La comp. LifeController del oggetto che collido = life

        if (life != null)
        {
            life.TakeDamage (_damage);
            lastDamageTime = Time.time;
        }
    }
}