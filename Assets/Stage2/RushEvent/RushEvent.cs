using UnityEngine;

public class RushEvent : MonoBehaviour
{
    public int eventIndex;
    public Rush0 enemySpawner; // このイベントに対応する EnemySpawner
    private bool hasTriggered = false; // イベントが発生済みかどうか

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered) // 初めて入った場合のみ
        {
            hasTriggered = true; // イベント発生済みにする
            Debug.Log($"プレイヤーがイベント {eventIndex} に突入");

            if (RushEventManager.Instance != null)
            {
                RushEventManager.Instance.ActivateEvent(eventIndex);
            }
        }
    }
}
