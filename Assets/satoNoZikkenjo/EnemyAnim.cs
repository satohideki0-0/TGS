using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    public float detectionRange = 5f;  // ÚGÍÍ
    public float attackRange = 2f;     // UÍÍ

    public Transform player;           // vC[ÌTransform

    private Animator animator;

    private float distanceToPlayer;

    private State currentState = State.Idle;

    private enum State
    {
        Idle, //vC[ð­©µÄÈ¢AÒ@
        Detect,//vC[m
        walk,//às
        Attack,//U

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(State.Idle);
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        //Ò@óÔ
        if (distanceToPlayer < detectionRange)
        {
            ChangeState(State.Detect);
            Debug.Log("m");
        }


        ////mÍÍàÉüÁ½
        //if (distanceToPlayer < attackRange)
        //{
        //    ChangeState(State.Attack);
        //    Debug.Log("Ò@");

        //}

        //mÍÍOÉo½
        if (distanceToPlayer > detectionRange)
        {
            ChangeState(State.Idle);
            Debug.Log("Ò@");

        }


        //UÍÍà

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


    // V[r[ÅÍÍðÂ»
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}