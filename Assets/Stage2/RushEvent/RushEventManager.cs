using UnityEngine;

public class RushEventManager : MonoBehaviour
{
    public static RushEventManager Instance; // �V���O���g���i�ǂ�����ł��A�N�Z�X�\�j

    public bool[] eventFlags = new bool[5]; // 5�̃C�x���g�̃t���O
    public GameObject playerCamera;
    public GameObject eventCamera;

    private void Awake()
    {
        // �V���O���g���̐ݒ�
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        // �C�x���g�J�������\���ɂ���
        eventCamera.SetActive(false);
    }
    public void ActivateEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = true;
            Debug.Log("�C�x���g " + eventIndex + " ���L���ɂȂ�܂����I");
            eventCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
    public void EndEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = false;
            Debug.Log("�C�x���g " + eventIndex + " ���I�����܂����I");
            eventCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
    }
}