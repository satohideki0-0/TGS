using UnityEngine;

public class RushEventManager : MonoBehaviour
{
    public static RushEventManager Instance; // シングルトン（どこからでもアクセス可能）

    public bool[] eventFlags = new bool[5]; // 5つのイベントのフラグ
    public GameObject playerCamera;
    public GameObject eventCamera;

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
    void Start()
    {
        // イベントカメラを非表示にする
        eventCamera.SetActive(false);
    }
    public void ActivateEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = true;
            Debug.Log("イベント " + eventIndex + " が有効になりました！");
            eventCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
    public void EndEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = false;
            Debug.Log("イベント " + eventIndex + " が終了しました！");
            eventCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
    }
}