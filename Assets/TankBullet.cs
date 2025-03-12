using UnityEngine;

public class TankBullet : MonoBehaviour
{
    public float lifetime = 3f;  // 弾が消えるまでの時間

    void Start()
    {
        Destroy(gameObject, lifetime);  // 指定時間後に削除
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // プレイヤーに当たったら削除
        {
            Destroy(gameObject);
        }
    }
}