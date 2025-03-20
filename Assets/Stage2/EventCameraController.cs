using UnityEngine;

public class EventCameraController : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public Transform eventTarget; // イベント時に移動するターゲット
    public float followSpeed = 5f; // プレイヤー追従時の速度
    private bool isEventActive = false; // イベント中かどうか

    private void LateUpdate()
    {
        if (!isEventActive && player != null)
        {
            // 通常時はプレイヤーを追いかける
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