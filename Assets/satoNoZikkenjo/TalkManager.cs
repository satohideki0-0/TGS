using UnityEngine;
using TMPro;

public class TalkManager : MonoBehaviour
{
    public TMP_Text talkText; // TextMeshProを使用
    private TalkData currentTalkData;
    private int talkIndex;

    public void StartTalk(TalkData talkData)
    {
        currentTalkData = talkData;
        talkIndex = 0;
        gameObject.SetActive(true);
        ShowNextMessage();
    }

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

    public void EndTalk()
    {
        gameObject.SetActive(false);
        // TalkEvent クラスの isTalk を false に設定する
        FindObjectOfType<TalkEvent>().EndTalk();
    }
}