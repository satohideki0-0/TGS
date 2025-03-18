using UnityEngine;

public class BulletLight : MonoBehaviour
{
    public Transform target;  // 追尾する敵
    public float speed = 10f; // 弾の速度
    public int damage = 10;   // ダメージ量
    public LineRenderer lineRenderer; // 雷のエフェクト
    public float homingStrength = 5f; // ホーミングの強さ

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // 追尾対象がいなければ消滅
            return;
        }

        // ターゲットの方向を取得
        Vector3 direction = (target.position - transform.position).normalized;

        // ホーミング効果
        transform.position = Vector3.Lerp(transform.position, target.position, homingStrength * Time.deltaTime);

        // 雷エフェクトを描画
        DrawLightningEffect();
    }

    void DrawLightningEffect()
    {
        if (lineRenderer == null) return;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, previousPosition); // 一つ前の位置
        lineRenderer.SetPosition(1, transform.position); // 現在位置

        previousPosition = transform.position; // 位置を更新
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            // 敵にダメージを与える
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); // 弾を消す
        }
    }
}