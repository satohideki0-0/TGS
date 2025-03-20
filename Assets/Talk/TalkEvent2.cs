using UnityEngine;

public class TalkEvent2 : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public GameObject player;
    public GameObject interactImage;
    public GameObject talkCanvas;
    public TalkManager talkManager;
    public TalkData[] talkDataArray;

    private bool isTalk = false;
    private int currentTalkIndex = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
        talkCanvas.SetActive(false);  // ゲーム開始時にアクティブ
        interactImage.SetActive(false);  // インタラクト画像も表示
        isTalk = false;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance >= interactDistance && !isTalk)
        {
            interactImage.SetActive(false);
            return;
        }

        interactImage.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalk)
            {
                StartConversation();
            }
            else
            {
                ProceedConversation();
            }
        }
    }

    private void StartConversation()
    {
        if (currentTalkIndex < talkDataArray.Length)
        {
            isTalk = true;
            interactImage.SetActive(false);
            talkCanvas.SetActive(true);
            talkManager.StartTalk(talkDataArray[currentTalkIndex]);
        }
    }

    private void ProceedConversation()
    {
        if (talkManager.HasNextMessage())
        {
            talkManager.ShowNextMessage();
        }
        else
        {
            EndTalk();
        }
    }

    public void EndTalk()
    {
        isTalk = false;
        talkCanvas.SetActive(false);
        interactImage.SetActive(true);

        currentTalkIndex++;
        if (currentTalkIndex >= talkDataArray.Length)
        {
            currentTalkIndex = talkDataArray.Length - 1;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}

