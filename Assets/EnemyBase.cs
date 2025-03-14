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

        Debug.Log($"�G�Ƀ_���[�W��^�����I�c��:{currentHP}");

        if(currentHP <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        Debug.Log("�G������");
        Destroy(gameObject);
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }
}
