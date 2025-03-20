using UnityEngine;

public class RushEvent : MonoBehaviour
{
    public int eventIndex;
    public Rush0 enemySpawner; // ���̃C�x���g�ɑΉ����� EnemySpawner

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"�v���C���[���C�x���g {eventIndex} �ɓ˓�");

            if (RushEventManager.Instance != null)
            {
                RushEventManager.Instance.ActivateEvent(eventIndex);
            }
        }
    }
}
