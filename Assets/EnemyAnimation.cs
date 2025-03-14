using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    private EnemyBase enemyScript;

    void Start()
    {
        enemyScript = GetComponent<EnemyBase>();

        if (enemyScript != null)
        {
            enemyScript.enabled = false; // 最初は敵のスクリプトを無効化
        }

        animator.SetTrigger("Appear");
    }

    public void OnAppearAnimationEnd()
    {
        if (enemyScript != null)
        {
            enemyScript.enabled = true;
            enemyScript.ActivateEnemy();
        }

        animator.SetTrigger("Idle");
    }
}