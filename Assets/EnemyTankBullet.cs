using UnityEngine;

public class EnemyTankBullet : MonoBehaviour
{
    public GameObject mortarPrefab;  // 迫撃砲弾のプレハブ
    public Transform target;  // 目標地点（プレイヤーなど）
    public float fireRate = 3f;  // 砲撃の間隔
    public float launchAngle = 45f;  // 発射角度（度単位）

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireMortar();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireMortar()
    {
        if (target == null) return;

        // 迫撃砲弾を生成
        GameObject mortar = Instantiate(mortarPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = mortar.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            // 必要な初速を計算（投擲公式を使用）
            float angleRad = launchAngle * Mathf.Deg2Rad;
            float speed = Mathf.Sqrt(distance * Physics2D.gravity.magnitude / Mathf.Sin(2 * angleRad));

            // 初速度を設定
            Vector2 velocity = new Vector2(direction.x * speed, Mathf.Abs(direction.y * speed));
            rb.velocity = velocity;
        }
    }
}