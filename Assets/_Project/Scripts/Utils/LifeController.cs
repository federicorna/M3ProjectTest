
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHp = 10;
    [SerializeField] private int _maxHp = 10;

    public void SetHp (int hp)
    {
        hp = Mathf.Clamp (hp, 0, _maxHp);

        if (_currentHp != hp)
        {
            _currentHp = hp;

            if (_currentHp == 0)
            {
                Defeated();
            }
        }
    }

    public void AddHp (int healing)
    {
        SetHp (_currentHp + healing);
    }

    public void TakeDamage (int damage)
    {
        SetHp (_currentHp - damage);
    }

    public void Defeated()
    {
        Destroy (gameObject);
        Debug.Log ("You died!");
    }
}
