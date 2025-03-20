using UnityEngine;

[CreateAssetMenu(fileName = "TalkData", menuName = "Scriptable Objects/TalkData")]
public class TalkData : ScriptableObject
{
    [TextArea(3, 5)]
    public string[] messages; // 会話の文章（複数行対応）  
}
