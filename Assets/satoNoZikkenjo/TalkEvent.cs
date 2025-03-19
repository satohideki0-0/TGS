using UnityEngine;

public class TalkEvent : MonoBehaviour
{

    //インタラクト距離
    public float interactDistance = 3.0f;
    public GameObject player;
    public GameObject interactImage;
    public GameObject talkCanvas;//会話用のキャンバス


    private bool isTalk = false;


    private void Start()
    {
        //プレイヤーを取得
        player = GameObject.Find("Player");

        talkCanvas.SetActive(false);
        interactImage.SetActive(false);
        isTalk = false;
    }

    void Update()
    {
        // プレイヤーとの距離を計算
        float distance = Vector2.Distance(transform.position, player.transform.position);
        interactImage.SetActive(false);
        // プレイヤーがインタラクト範囲内に入ったら
        if (distance < interactDistance)
        {
            Debug.Log("インタラクト範囲内に入りました");
            interactImage.SetActive(true);
            // インタラクトキーを押したら
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTalk = !isTalk;
                talkCanvas.SetActive(isTalk);
                Debug.Log(isTalk ? "会話イベントを開始" : "会話イベントを終了");
            }
        }
    }


    // シーンビューで範囲を可視化
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
