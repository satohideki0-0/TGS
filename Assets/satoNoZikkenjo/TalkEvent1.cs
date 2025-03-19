using UnityEngine;

public class TalkEvent1 : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public GameObject player;
    public GameObject interactImage;
    public TalkManager talkManager;
    public TalkData talkData; // ScriptableObjectで管理する会話データ

    private bool wasInRange = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player オブジェクトが見つかりません。");
            enabled = false;
            return;
        }

        interactImage.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool inRange = distance < interactDistance;

        if (inRange != wasInRange)
        {
            interactImage.SetActive(inRange);
            wasInRange = inRange;
        }

        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!talkManager.gameObject.activeSelf)
            {
                talkManager.StartTalk(talkData);
            }
            else
            {
                talkManager.ShowNextMessage();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
