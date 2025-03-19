using UnityEngine;
using TMPro;

public class TalkManager : MonoBehaviour
{
    public TMP_Text talkText; // TextMeshPro‚ðŽg—p
    public GameObject talkCanvas;

    private TalkData currentTalkData;
    private int talkIndex = 0;

    public void StartTalk(TalkData talkData)
    {
        currentTalkData = talkData;
        talkIndex = 1;
        talkCanvas.SetActive(true);
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
        talkCanvas.SetActive(false);
        currentTalkData = null;
    }
}