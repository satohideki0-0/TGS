using UnityEngine;
using TMPro;

public class NameView : MonoBehaviour
{
    public string npcName = "NPC Name";  // NPC�̖��O
    public GameObject nameTextPrefab;    // ���O�\���p��TextMeshPro�v���n�u
    public Vector3 nameOffset = new Vector3(7, 6, 0);  // ���O�̕\���ʒu�I�t�Z�b�g�iNPC�̏�ɕ\�������j
    public float fontSize = 20;           // �t�H���g�T�C�Y
    private GameObject nameTextObject;   // �C���X�^���X�����ꂽ���O��TextMeshPro�I�u�W�F�N�g

    void Start()
    {
        // ���O��\������TextMeshPro�I�u�W�F�N�g���쐬
        if (nameTextPrefab != null)
        {
            // NPC�̏�����ɖ��O��\��
            nameTextObject = Instantiate(nameTextPrefab, transform.position + nameOffset, Quaternion.identity);
            
            // TextMeshPro�R���|�[�l���g���擾���Ė��O��ݒ�
            TextMeshPro textMeshPro = nameTextObject.GetComponent<TextMeshPro>();
            textMeshPro.text = npcName;

            // �K�v�ł���΁A�e�L�X�g�̐ݒ��ύX�i��: �t�H���g�T�C�Y�j
            textMeshPro.fontSize = fontSize;
        }
    }

    void Update()
    {
        // NPC���ړ����邽�тɖ��O�̈ʒu���X�V
        if (nameTextObject != null)
        {
            // NPC�̈ʒu�ɒǏ]
            nameTextObject.transform.position = transform.position + nameOffset;
        }
    }
}