using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    public float detectionRange = 5f;  // 接敵範囲
    public float attackRange = 2f;     // 攻撃範囲

    public Transform player;           // プレイヤーのTransform

    private Animator animator;

    private float distanceToPlayer;

    private State currentState = State.Idle;

    private enum State
    {
        Idle, //プレイヤーを発見してない、待機
        Detect,//プレイヤー検知
        walk,//歩行
        Attack,//攻撃

    }
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(State.Idle);
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        //待機状態
        if (distanceToPlayer < detectionRange)
        {
            ChangeState(State.Detect);
            Debug.Log("検知");
        }


        //検知範囲外に出た
        if (distanceToPlayer > detectionRange)
        {
            ChangeState(State.Idle);
            Debug.Log("待機");

        }


        //攻撃範囲内
        //待機が再生された後に攻撃再生
        //攻撃の最後のフレームにイベント


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


    // シーンビューで範囲を可視化
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}