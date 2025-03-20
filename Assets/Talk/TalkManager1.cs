using UnityEngine;
using TMPro;

public class TalkManager1 : MonoBehaviour
{
    public TMP_Text talkText; // TextMeshPro���g�p
    private TalkData currentTalkData;
    private int talkIndex;

    // ��b���J�n����
    public void StartTalk(TalkData talkData)
    {
        currentTalkData = talkData;
        talkIndex = 0;
        gameObject.SetActive(true);
        ShowNextMessage(); // �ŏ��̃��b�Z�[�W��\��
    }

    // ���̃��b�Z�[�W��\��
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

    // ��b�����ɐi�ނ��ǂ������`�F�b�N
    public bool HasNextMessage()
    {
        return talkIndex < currentTalkData.messages.Length;
    }

    // ��b���I������
    public void EndTalk()
    {
        gameObject.SetActive(false);
        // �v���C���[�̑�����ėL����
        FindObjectOfType<Player>().EnableMovement();
    }
    // ���݂̃��b�Z�[�W���Ōォ�ǂ������肷��֐�
    public bool IsLastMessage()
    {
        return talkIndex == currentTalkData.messages.Length - 1;
    }
}
