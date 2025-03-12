using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;  // 追従する対象（プレイヤー）
    public float smoothSpeed = 0.125f;  // カメラ移動のスムーズさ
    public Vector3 offset;  // カメラとプレイヤーの位置のオフセット

    void LateUpdate()
    {
        // プレイヤーの位置にオフセットを加えた目標位置を計算
        Vector3 desiredPosition = player.position + offset;

        // 現在のカメラ位置から目標位置へスムーズに移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // カメラの位置を更新
        transform.position = smoothedPosition;
    }
}