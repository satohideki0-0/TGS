using UnityEngine;

[CreateAssetMenu(fileName = "TalkData", menuName = "Scriptable Objects/TalkData")]
public class TalkData : ScriptableObject
{
    [TextArea(3, 5)]
    public string[] messages; // ��b�̕��́i�����s�Ή��j  
}
