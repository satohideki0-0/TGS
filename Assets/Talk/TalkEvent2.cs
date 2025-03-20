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
    private Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        talkCanvas.SetActive(false);
        interactImage.SetActive(false);
        isTalk = false;

        // 初めから会話を開始する
        StartConversation();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // インタラクト範囲内にプレイヤーが入ったときに表示
        if (distance < interactDistance && !isTalk)
        {
            interactImage.SetActive(true);
        }

        if (distance >= interactDistance && !isTalk)
        {
            interactImage.SetActive(false);
            return;
        }

        // 通常はEキーで会話を進める
        if (isTalk)
        {
            if (currentTalkIndex == 0 && talkManager.HasNextMessage() && talkManager.GetTalkIndex() == talkDataArray[0].messages.Length - 2)
            {
                // データ0の最後のひとつ前のメッセージに到達したらQキーで終了
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    ProceedConversation();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E)) // それ以外の会話はEキーで進める
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
            if (currentTalkIndex == 0) // 最初の会話データが終了した場合
            {
                EndTalkWithAnimation();
            }
            else
            {
                EndTalk();
            }
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

    // データ0の最後が終了したらQボタンで終了し、アニメーションを再生
    private void EndTalkWithAnimation()
    {
        isTalk = false;
        talkCanvas.SetActive(false);
        interactImage.SetActive(true);

        // アニメーションを再生
        animator.SetTrigger("PlayAnimation");

        // アニメーションの最後で次の会話データを再生させるためのアニメーションイベントを使用
    }

    // アニメーションイベントから呼び出されるメソッド
    public void PlayNextConversation()
    {
        if (currentTalkIndex + 1 < talkDataArray.Length)
        {
            currentTalkIndex++;
            StartConversation();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
