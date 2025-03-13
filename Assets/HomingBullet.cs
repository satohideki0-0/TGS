using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;            // 弾の速度
    public float rotateSpeed = 200f;    // 回転速度
    public float homingStrength = 0.5f; // ホーミング強度（0.0 ? 1.0）
    public int damage = 1;
    public float lifetime = 3f;

    private Transform target;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        FindClosestEnemy();
    }

    private void Update()
    {
        if (target == null)
        {
            FindClosestEnemy();
            return;
        }

        // 敵への方向ベクトルを計算
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        // 現在の弾の向きを補正する（ホーミング強度に応じた補正）
        Vector2 currentDirection = transform.right;
        Vector2 newDirection = Vector2.Lerp(currentDirection, direction, homingStrength).normalized;

        // 回転を制御
        float rotateAmount = Vector3.Cross(newDirection, currentDirection).z;
        GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * rotateSpeed;
        GetComponent<Rigidbody2D>().velocity = newDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy enemyScript = collision.GetComponent<enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy.transform;
            }
        }
    }
}