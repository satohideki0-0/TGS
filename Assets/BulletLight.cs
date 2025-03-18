using UnityEngine;

public class BulletLight : MonoBehaviour
{
    public Transform target;  // �ǔ�����G
    public float speed = 10f; // �e�̑��x
    public int damage = 10;   // �_���[�W��
    public LineRenderer lineRenderer; // ���̃G�t�F�N�g
    public float homingStrength = 5f; // �z�[�~���O�̋���

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
            Destroy(gameObject); // �ǔ��Ώۂ����Ȃ���Ώ���
            return;
        }

        // �^�[�Q�b�g�̕������擾
        Vector3 direction = (target.position - transform.position).normalized;

        // �z�[�~���O����
        transform.position = Vector3.Lerp(transform.position, target.position, homingStrength * Time.deltaTime);

        // ���G�t�F�N�g��`��
        DrawLightningEffect();
    }

    void DrawLightningEffect()
    {
        if (lineRenderer == null) return;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, previousPosition); // ��O�̈ʒu
        lineRenderer.SetPosition(1, transform.position); // ���݈ʒu

        previousPosition = transform.position; // �ʒu���X�V
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            // �G�Ƀ_���[�W��^����
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); // �e������
        }
    }
}