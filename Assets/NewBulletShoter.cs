using UnityEngine;

public class NewBulletShoter : MonoBehaviour
{
    public GameObject lightningBulletPrefab; // ���̋��̃v���n�u
    public Transform firePoint; // ���ˈʒu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �X�y�[�X�L�[�Ŕ���
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(lightningBulletPrefab, firePoint.position, Quaternion.identity);
        BulletLight lightning = bullet.GetComponent<BulletLight>();

        // ��ԋ߂��G���^�[�Q�b�g�ɂ���
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