using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifetime); // ˆê’èŠÔŒã‚É’e‚ğÁ‚·
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
            Destroy(gameObject); // ’e‚ğÁ‚·
        }
    }
}
