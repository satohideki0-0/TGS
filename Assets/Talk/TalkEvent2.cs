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

        // ���߂����b���J�n����
        StartConversation();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // �C���^���N�g�͈͓��Ƀv���C���[���������Ƃ��ɕ\��
        if (distance < interactDistance && !isTalk)
        {
            interactImage.SetActive(true);
        }

        if (distance >= interactDistance && !isTalk)
        {
            interactImage.SetActive(false);
            return;
        }

        // �ʏ��E�L�[�ŉ�b��i�߂�
        if (isTalk)
        {
            if (currentTalkIndex == 0 && talkManager.HasNextMessage() && talkManager.GetTalkIndex() == talkDataArray[0].messages.Length - 2)
            {
                // �f�[�^0�̍Ō�̂ЂƂO�̃��b�Z�[�W�ɓ��B������Q�L�[�ŏI��
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    ProceedConversation();
                }
            }
            else if (Input.GetKeyDown(KeyCode.E)) // ����ȊO�̉�b��E�L�[�Ői�߂�
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
            if (currentTalkIndex == 0) // �ŏ��̉�b�f�[�^���I�������ꍇ
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

    // �f�[�^0�̍Ōオ�I��������Q�{�^���ŏI�����A�A�j���[�V�������Đ�
    private void EndTalkWithAnimation()
    {
        isTalk = false;
        talkCanvas.SetActive(false);
        interactImage.SetActive(true);

        // �A�j���[�V�������Đ�
        animator.SetTrigger("PlayAnimation");

        // �A�j���[�V�����̍Ō�Ŏ��̉�b�f�[�^���Đ������邽�߂̃A�j���[�V�����C�x���g���g�p
    }

    // �A�j���[�V�����C�x���g����Ăяo����郁�\�b�h
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
