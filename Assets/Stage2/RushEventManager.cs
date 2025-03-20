using UnityEngine;

public class RushEventManager : MonoBehaviour
{
    public static RushEventManager Instance; // シングルトン（どこからでもアクセス可能）

    public bool[] eventFlags = new bool[5]; // 5つのイベントのフラグ

    private void Awake()
    {
        // シングルトンの設定
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = true;
            Debug.Log("イベント " + eventIndex + " が有効になりました！");
        }
    }
}