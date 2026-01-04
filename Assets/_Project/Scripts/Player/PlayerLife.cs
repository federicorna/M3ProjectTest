using UnityEngine;

public class PlayerLife : LifeController
{
    protected override void Awake()
    {
        _useInvincibility = true;
        base.Awake();
    }

    protected override void Defeated()
    {
        Debug.Log("Player morto");
        Destroy(gameObject);
    }
}
