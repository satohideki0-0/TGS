using UnityEngine;
using TMPro;

public class TalkManager1 : MonoBehaviour
{
    public TMP_Text talkText; // TextMeshProを使用
    private TalkData currentTalkData;
    private int talkIndex;

    // 会話を開始する
    public void StartTalk(TalkData talkData)
    {
        currentTalkData = talkData;
        talkIndex = 0;
        gameObject.SetActive(true);
        ShowNextMessage(); // 最初のメッセージを表示
    }

    // 次のメッセージを表示
    public void ShowNextMessage()
    {
        if (currentTalkData == null || talkIndex >= currentTalkData.messages.Length)
        {
            EndTalk();
            return;
        }

        talkText.text = currentTalkData.messages[talkIndex];
        talkIndex++;
    }

    // 会話が次に進むかどうかをチェック
    public bool HasNextMessage()
    {
        return talkIndex < currentTalkData.messages.Length;
    }

    // 会話を終了する
    public void EndTalk()
    {
        gameObject.SetActive(false);
        // プレイヤーの操作を再有効化
        FindObjectOfType<Player>().EnableMovement();
    }
    // 現在のメッセージが最後かどうか判定する関数
    public bool IsLastMessage()
    {
        return talkIndex == currentTalkData.messages.Length - 1;
    }
}
