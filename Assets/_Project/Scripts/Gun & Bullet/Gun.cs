
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float shootDistance = 5f;

    private float _lastShotTime;

    void Update()
    {
        Enemy target = FindClosestEnemy();
        if (target == null) return;

        if (Time.time < _lastShotTime + _fireRate) return;

        Shoot(target.transform.position);
        _lastShotTime = Time.time;
    }

    private void Shoot(Vector2 targetPos)
    {
        GameObject bulletObj = Instantiate (_bulletPrefab, transform.position, Quaternion.identity);

        Vector2 dir = targetPos - (Vector2)transform.position;

        //bulletObj.GetComponent<Bullet>().SetDirection(dir);   troppo complesso, equivalenza sotto

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetDirection(dir);

    }

    private Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closestEnemy = null;

        float minDist = shootDistance;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance (transform.position, enemy.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
