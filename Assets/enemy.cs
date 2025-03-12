using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float moveRange = 5.0f;
    public int maxHP = 3;  // �ő�HP
    private int currentHP;

    private Vector3 startPosition;
    private float moveDirection = 1f;

    void Start()
    {
        startPosition = transform.position;
        currentHP = maxHP;  // HP��������
    }

    void Update()
    {
        // ���E�ړ�
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
        Debug.Log($"�G���_���[�W���󂯂��I �c��HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("�G���|���ꂽ�I");
        Destroy(gameObject); // �G������
    }
}