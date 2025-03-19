using UnityEngine;
using TMPro;

public class TalkManager : MonoBehaviour
{
    public TMP_Text talkText; // TextMeshPro���g�p
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
        // TalkEvent �N���X�� isTalk �� false �ɐݒ肷��
        FindObjectOfType<TalkEvent>().EndTalk();
    }
}