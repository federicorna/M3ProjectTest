using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
    [SerializeField] protected int _maxHp = 10;
    protected int _currentHp;

    [SerializeField] protected bool _useInvincibility = false;   //Invincibilita enemy gia disattiva
    [SerializeField] protected float _invincibilityTime = 0.5f;

    private bool _isInvincible;

    protected virtual void Awake() //X override PlayerLife x attivarla
    {
        _currentHp = _maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        if (_useInvincibility && _isInvincible) return;

        _currentHp -= damage;
        _currentHp = Mathf.Clamp(_currentHp, 0, _maxHp);    //Controllo range stato vita

        if (_currentHp == 0)
        {
            Defeated();
        }
        else if (_useInvincibility)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    //public void AddHp(int healing)
    //{
    //    SetHp(_currentHp + healing);
    //}

    //public void TakeDamage(int damage)
    //{
    //    SetHp(_currentHp - damage);
    //}

    private IEnumerator InvincibilityCoroutine()    //Definizione invincibilita
    {
        Debug.Log($"IMMUNITA ATTIVA");
        
        _isInvincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _isInvincible = false;
    }

    protected virtual void Defeated()
    {
        Destroy(gameObject);
    }
}


