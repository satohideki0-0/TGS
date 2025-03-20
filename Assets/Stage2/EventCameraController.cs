using UnityEngine;

public class EventCameraController : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public Transform eventTarget; // �C�x���g���Ɉړ�����^�[�Q�b�g
    public float followSpeed = 5f; // �v���C���[�Ǐ]���̑��x
    private bool isEventActive = false; // �C�x���g�����ǂ���

    private void LateUpdate()
    {
        if (!isEventActive && player != null)
        {
            // �ʏ펞�̓v���C���[��ǂ�������
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }

    public void MoveToEventTarget()
    {
        if (eventTarget != null)
        {
            isEventActive = true;
            transform.position = new Vector3(eventTarget.position.x, eventTarget.position.y, transform.position.z);
        }
    }

    public void ReturnToPlayer()
    {
        isEventActive = false;
    }
}