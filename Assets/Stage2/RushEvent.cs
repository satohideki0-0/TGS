using UnityEngine;

public class RushEvent : MonoBehaviour
{
    public int eventIndex;
    public Rush0 enemySpawner; // このイベントに対応する EnemySpawner

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"プレイヤーがイベント {eventIndex} に突入");

            if (RushEventManager.Instance != null)
            {
                RushEventManager.Instance.ActivateEvent(eventIndex);
            }
        }
    }
}
