
//using UnityEngine;

//public abstract class Pickup : MonoBehaviour
//{
//    private void OnTriggerEnter2D (Collider2D other)
//    {
//        if (!other.CompareTag("Player")) return;

//        ApplyEffect(other.gameObject);
//        Destroy(gameObject);
//    }

//    protected abstract void ApplyEffect(GameObject player);
//}

using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject _gunPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Instantiate (_gunPrefab, other.transform);
        
        Destroy(gameObject);
    }
}
