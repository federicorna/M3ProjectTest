
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string _hSpeedParamName = "hSpeed";
    private string _vSpeedParamName = "vSpeed";
    private string _isMovingParamName = "isMoving";

    private Animator _playerAnimator;

    void Awake()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
    }

//  F.NI PER SETTARE I VALORI NEL ANIMATOR
    public void SetHSpeedParam (float hSpeed)
    {
        _playerAnimator.SetFloat (_hSpeedParamName, hSpeed);
    }

    public void SetVSpeedParam (float vSpeed)
    {
        _playerAnimator.SetFloat (_vSpeedParamName, vSpeed);
    }

    public void SetIsMovingParam (bool isMoving)
    {
        _playerAnimator.SetBool (_isMovingParamName, isMoving);
    }

}
