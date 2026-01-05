using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
    [SerializeField] protected int _maxHp;
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
        Debug.Log ($"{gameObject}, danno pari a: {damage},  vita avversario: {_currentHp}");

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

    //-------------------------------------------
    private void SetHp (int hp) => hp = _currentHp ;
    public void AddHp (int healing)
    {
        SetHp (_currentHp + healing);
    }
    //--------------------------------------------

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


