using UnityEngine;

public class NewBulletShoter : MonoBehaviour
{
    public GameObject lightningBulletPrefab; // 雷の球のプレハブ
    public Transform firePoint; // 発射位置

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーで発射
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(lightningBulletPrefab, firePoint.position, Quaternion.identity);
        BulletLight lightning = bullet.GetComponent<BulletLight>();

        // 一番近い敵をターゲットにする
        EnemyBase closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            lightning.target = closestEnemy.transform;
        }
    }

    EnemyBase FindClosestEnemy()
    {
        EnemyBase[] enemies = FindObjectsOfType<EnemyBase>();
        float minDistance = Mathf.Infinity;
        EnemyBase closest = null;

        foreach (EnemyBase enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}