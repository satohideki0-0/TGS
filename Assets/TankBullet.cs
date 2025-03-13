using UnityEngine;

public class TankBullet : MonoBehaviour
{
    public float lifetime = 3f;  // �e��������܂ł̎���

    void Start()
    {
        Destroy(gameObject, lifetime);  // �w�莞�Ԍ�ɍ폜
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �v���C���[�ɓ���������폜
        {
            Destroy(gameObject);
        }
    }
}