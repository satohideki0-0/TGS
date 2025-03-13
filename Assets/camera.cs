using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;  // �Ǐ]����Ώہi�v���C���[�j
    public float smoothSpeed = 0.125f;  // �J�����ړ��̃X���[�Y��
    public Vector3 offset;  // �J�����ƃv���C���[�̈ʒu�̃I�t�Z�b�g

    void LateUpdate()
    {
        // �v���C���[�̈ʒu�ɃI�t�Z�b�g���������ڕW�ʒu���v�Z
        Vector3 desiredPosition = player.position + offset;

        // ���݂̃J�����ʒu����ڕW�ʒu�փX���[�Y�Ɉړ�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // �J�����̈ʒu���X�V
        transform.position = smoothedPosition;
    }
}