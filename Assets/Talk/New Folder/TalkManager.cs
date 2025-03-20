using UnityEngine;
using TMPro;

public class TalkManager : MonoBehaviour
{
    public TMP_Text talkText;
    private TalkData currentTalkData;
    private int talkIndex;

    public void StartTalk(TalkData talkData)
    {
        if (talkData == null || talkData.messages.Length == 0)
        {
            Debug.LogError("TalkDataが設定されていないか、メッセージがありません");
            return;
        }

        currentTalkData = talkData;
        talkIndex = 0;
        gameObject.SetActive(true);
        ShowNextMessage();
    }

    public void ShowNextMessage()
    {
        if (currentTalkData == null)
        {
            Debug.LogError("TalkDataが設定されていません");
            return;
        }

        if (talkIndex >= currentTalkData.messages.Length)
        {
            EndTalk();
            return;
        }

        talkText.text = currentTalkData.messages[talkIndex];
        talkIndex++;
    }

    public bool HasNextMessage()
    {
        return currentTalkData != null && talkIndex < currentTalkData.messages.Length;
    }

    public void EndTalk()
    {
        gameObject.SetActive(false);
        currentTalkData = null;
        talkIndex = 0;
        FindObjectOfType<Player>().EnableMovement();
    }
    public int GetTalkIndex()
    {
        return talkIndex;
    }
    public TalkData GetCurrentTalkData()
    {
        return currentTalkData;
    }
}
