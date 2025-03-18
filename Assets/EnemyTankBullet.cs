using UnityEngine;

public class EnemyTankBullet : MonoBehaviour
{
    public GameObject mortarPrefab;  // �����C�e�̃v���n�u
    public Transform target;  // �ڕW�n�_�i�v���C���[�Ȃǁj
    public float fireRate = 3f;  // �C���̊Ԋu
    public float launchAngle = 45f;  // ���ˊp�x�i�x�P�ʁj

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            //FireMortar();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireMortar()
    {
        if (target == null) return;

        // �����C�e�𐶐�
        GameObject mortar = Instantiate(mortarPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = mortar.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target.position);

            // �K�v�ȏ������v�Z�i�����������g�p�j
            float angleRad = launchAngle * Mathf.Deg2Rad;
            float speed = Mathf.Sqrt(distance * Physics2D.gravity.magnitude / Mathf.Sin(2 * angleRad));

            // �����x��ݒ�
            Vector2 velocity = new Vector2(direction.x * speed, Mathf.Abs(direction.y * speed));
            rb.linearVelocity = velocity;
        }
    }
}