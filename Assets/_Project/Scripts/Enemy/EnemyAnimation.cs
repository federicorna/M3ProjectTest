using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private string _hSpeedParamName = "hSpeed";
    private string _vSpeedParamName = "vSpeed";

    private Animator _enemyAnimator;

    void Awake()
    {
        _enemyAnimator = GetComponentInChildren<Animator>();
    }

    public void SetHSpeedParam (float hSpeed)
    {
        _enemyAnimator.SetFloat (_hSpeedParamName, hSpeed);

    }
    public void SetVSpeedParam (float vSpeed)
    {
        _enemyAnimator.SetFloat (_vSpeedParamName, vSpeed);
    }
}