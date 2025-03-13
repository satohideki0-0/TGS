using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float moveRange = 5.0f;
    public int maxHP = 3;  // 最大HP
    private int currentHP;

    private Vector3 startPosition;
    private float moveDirection = 1f;

    void Start()
    {
        startPosition = transform.position;
        currentHP = maxHP;  // HPを初期化
    }

    void Update()
    {
        // 左右移動
        float moveDistance = moveDirection * speed * Time.deltaTime;
        transform.Translate(moveDistance, 0f, 0f);

        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveRange)
        {
            moveDirection *= -1;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"敵がダメージを受けた！ 残りHP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("敵が倒された！");
        Destroy(gameObject); // 敵を消す
    }
}