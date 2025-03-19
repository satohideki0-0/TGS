using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    public float detectionRange = 5f;  // �ړG�͈�
    public float attackRange = 2f;     // �U���͈�

    public Transform player;           // �v���C���[��Transform

    private Animator animator;

    private float distanceToPlayer;

    private State currentState = State.Idle;

    private enum State
    {
        Idle, //�v���C���[�𔭌����ĂȂ��A�ҋ@
        Detect,//�v���C���[���m
        walk,//���s
        Attack,//�U��

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(State.Idle);
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        //�ҋ@���
        if (distanceToPlayer < detectionRange)
        {
            ChangeState(State.Detect);
            Debug.Log("���m");
        }


        //���m�͈͊O�ɏo��
        if (distanceToPlayer > detectionRange)
        {
            ChangeState(State.Idle);
            Debug.Log("�ҋ@");

        }


        //�U���͈͓�
        //�ҋ@���Đ����ꂽ��ɍU���Đ�
        //�U���̍Ō�̃t���[���ɃC�x���g


    }

    private void ChangeState(State newState)
    {
        if (currentState == newState) return;

        currentState = newState;


        switch (newState)
        {
            case State.Idle:
                animator.SetTrigger("Idle");
                Debug.Log("Idle");
                break;
            case State.Detect:
                animator.SetTrigger("Detect");
                Debug.Log("Detect");
                break;
            case State.walk:
                animator.SetTrigger("Walk");
                break;
            case State.Attack:

                break;
            default:
                break;
        }



    }


    // �V�[���r���[�Ŕ͈͂�����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}