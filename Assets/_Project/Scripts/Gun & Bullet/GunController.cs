
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float _fireRate = 2f;
    [SerializeField] private float _visionRange = 10f;
    [SerializeField] private Bullet _bulletPrefab;

    private float _lastShot = 0f;

    private void Update()
    {
        if (Time.time - _lastShot >= _fireRate)
        {
            Shoot();
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = _visionRange;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;   //.gameObject:
            }
        }
        return nearestEnemy;
    }



    private void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (!nearestEnemy) return;

        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        Vector2 bulletDirection = (nearestEnemy.transform.position - transform.position).normalized;

        bullet.SetDirection(bulletDirection);

        _lastShot = Time.time;
    }

}
