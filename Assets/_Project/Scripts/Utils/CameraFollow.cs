
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void LateUpdate()
    {
        Vector3 cameraDistance = new Vector3 (_target.transform.position.x, _target.transform.position.y, -10);
        gameObject.transform.position = cameraDistance;
    }
}
