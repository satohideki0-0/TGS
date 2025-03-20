using UnityEngine;

public class RushEventManager : MonoBehaviour
{
    public static RushEventManager Instance; // �V���O���g���i�ǂ�����ł��A�N�Z�X�\�j

    public bool[] eventFlags = new bool[5]; // 5�̃C�x���g�̃t���O

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

    public void ActivateEvent(int eventIndex)
    {
        if (eventIndex >= 0 && eventIndex < eventFlags.Length)
        {
            eventFlags[eventIndex] = true;
            Debug.Log("�C�x���g " + eventIndex + " ���L���ɂȂ�܂����I");
        }
    }
}