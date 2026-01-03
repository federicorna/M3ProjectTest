using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    [SerializeField] private string _colliderTriggerParamName = "hasCollided";

    private Animator _bulletAnimator;

    void Awake()
    {
        _bulletAnimator = GetComponentInChildren<Animator>();
    }

    public void SetColliderTrigger() => _bulletAnimator.SetTrigger(_colliderTriggerParamName);
}
