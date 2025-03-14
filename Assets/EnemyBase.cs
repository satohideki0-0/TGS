using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int maxHP = 3;
    protected int currentHP;

    protected bool isActive = false;
    protected Animator animator;

    protected virtual void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(int damage)
    {
        if(!isActive)return;
//--------------------------------------------------------------
        currentHP -= damage;

        Debug.Log($"ìGÇ…É_ÉÅÅ[ÉWÇó^Ç¶ÇΩÅIécÇË:{currentHP}");

        if(currentHP <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        Debug.Log("ìGÇ™éÄÇÒÇæ");
        Destroy(gameObject);
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }
}
