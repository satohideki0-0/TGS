using UnityEngine;

public class Thief : MonoBehaviour
{
    public int hp = 100;
    private enum State { PATROL, CHASE, ATTACK }
    [SerializeField] private State currentState = State.PATROL;

    [Header("patrol setting")]
    [SerializeField] private float patrolSpeed = 1.0f;
    [SerializeField] private float patrolDistance = 4.0f;
    private Vector2 startPosition;
    private int direction = 1; // 1=âEÅA-1=ç∂

    [Header("chaseÅEattack setting")]
    [SerializeField] private GameObject player;
    [SerializeField] private float detectRange = 4.0f;
    [SerializeField] private float chaseSpeed = 2.0f;
    [SerializeField] private float attackRange = 1.0f;
    [SerializeField] private float deleyAttack = 1.0f;

    void Start()
    {
        startPosition = transform.position;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        switch (currentState)
        {
            case State.PATROL:
                Patrol();
                sr.color = Color.green;
                break;
            case State.CHASE:
                Chase();
                sr.color = Color.yellow;
                break;
            case State.ATTACK:
                Attack();
                sr.color = Color.red;
                break;
        }

        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case State.PATROL:
                if (distToPlayer < detectRange && IsFacingPlayer())
                {
                    currentState = State.CHASE;
                }
                break;
            case State.CHASE:
                if (distToPlayer < attackRange)
                {
                    currentState = State.ATTACK;
                }
                else if (distToPlayer > detectRange)
                {
                    currentState = State.PATROL;
                    startPosition = transform.position;
                }
                break;
            case State.ATTACK:
                if (distToPlayer > attackRange)
                {
                    currentState = State.CHASE;
                }
                break;
        }
    }
    private void Patrol()
    {
        transform.position += Vector3.right * direction * patrolSpeed * Time.deltaTime;
        float distanceFromStart = transform.position.x - startPosition.x;
        if (distanceFromStart >= patrolDistance)
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (distanceFromStart <= -patrolDistance)
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Chase()
    {
        transform.position += Vector3.right * direction * chaseSpeed * Time.deltaTime;
        if (transform.position.x >= player.transform.position.x)
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x <= player.transform.position.x)
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void Attack()
    {

    }
    private bool IsFacingPlayer()
    {
        float dirToPlayer = player.transform.position.x - transform.position.x;

        if (dirToPlayer > 0 && transform.localScale.x > 0) return true;
        if (dirToPlayer < 0 && transform.localScale.x < 0) return true;
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
