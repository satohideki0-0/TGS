using UnityEngine;
using TMPro;

public class NameView : MonoBehaviour
{
    public string npcName = "NPC Name";  // NPCの名前
    public GameObject nameTextPrefab;    // 名前表示用のTextMeshProプレハブ
    public Vector3 nameOffset = new Vector3(7, 6, 0);  // 名前の表示位置オフセット（NPCの上に表示される）
    public float fontSize = 20;           // フォントサイズ
    private GameObject nameTextObject;   // インスタンス化された名前のTextMeshProオブジェクト

    void Start()
    {
        // 名前を表示するTextMeshProオブジェクトを作成
        if (nameTextPrefab != null)
        {
            // NPCの少し上に名前を表示
            nameTextObject = Instantiate(nameTextPrefab, transform.position + nameOffset, Quaternion.identity);
            
            // TextMeshProコンポーネントを取得して名前を設定
            TextMeshPro textMeshPro = nameTextObject.GetComponent<TextMeshPro>();
            textMeshPro.text = npcName;

            // 必要であれば、テキストの設定を変更（例: フォントサイズ）
            textMeshPro.fontSize = fontSize;
        }
    }

    void Update()
    {
        // NPCが移動するたびに名前の位置を更新
        if (nameTextObject != null)
        {
            // NPCの位置に追従
            nameTextObject.transform.position = transform.position + nameOffset;
        }
    }
}