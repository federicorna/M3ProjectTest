
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f; 

    private Rigidbody2D _rb;
    private PlayerAnimation _playerAnimation;

    private float _horizontal;
    private float _vertical;
    private Vector2 _direction;

    public Vector2 Direction => _direction;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw ("Horizontal");
        _vertical = Input.GetAxisRaw ("Vertical");

        if (_horizontal != 0 || _vertical != 0) 
        {
            _playerAnimation.SetHSpeedParam (_horizontal);
            _playerAnimation.SetVSpeedParam (_vertical);
            _playerAnimation.SetIsMovingParam (true);
        }
        else
        {
            _playerAnimation.SetIsMovingParam (false);
        }
    }

    void FixedUpdate()
    {
        _direction = new Vector2 (_horizontal, _vertical).normalized;    //UPDATE?

        _rb.MovePosition (_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
