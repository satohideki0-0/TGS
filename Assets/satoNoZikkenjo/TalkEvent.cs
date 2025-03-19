using UnityEngine;

public class TalkEvent : MonoBehaviour
{
    // �C���^���N�g����
    public float interactDistance = 3.0f;
    public GameObject player;
    public GameObject interactImage;
    public GameObject talkCanvas; // ��b�p�̃L�����o�X

    public TalkManager talkManager;
    public TalkData talkData; // ScriptableObject�ŊǗ������b�f�[�^

    private bool isTalk = false;

    private void Start()
    {
        // �v���C���[���擾
        player = GameObject.Find("Player");

        talkCanvas.SetActive(false);
        interactImage.SetActive(false);
        isTalk = false;
    }

    void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distance = Vector2.Distance(transform.position, player.transform.position);
        interactImage.SetActive(false);

        // �v���C���[���C���^���N�g�͈͓��ɓ�������
        if (distance < interactDistance)
        {
            Debug.Log("�C���^���N�g�͈͓��ɓ���܂���");
            interactImage.SetActive(true);

            // �C���^���N�g�L�[�������ꂽ�ꍇ
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isTalk)
                {
                    isTalk = true;
                    talkManager.StartTalk(talkData);
                }
                else
                {
                    talkManager.ShowNextMessage();
                }

                Debug.Log(isTalk ? "��b�C�x���g���J�n" : "��b�C�x���g���I��");
                Debug.Log(isTalk);
            }
        }
    }

    public void EndTalk()
    {
        isTalk = false;
        talkCanvas.SetActive(false);
    }

    // �V�[���r���[�Ŕ͈͂�����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
