using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SkillUIController : MonoBehaviour
{
    public Image[] skillImages; // 3�̃X�L���摜
    private int selectedIndex = 0; // ���݂̑I���C���f�b�N�X

    private Vector3 normalScale = new Vector3(1f, 1f, 1f);
    private Vector3 selectedScale = new Vector3(1.5f, 1.5f, 1.5f);

    void Start()
    {
        UpdateSkillSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex = (selectedIndex - 1 + skillImages.Length) % skillImages.Length;
            UpdateSkillSelection();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex = (selectedIndex + 1) % skillImages.Length;
            UpdateSkillSelection();
        }
    }

    void UpdateSkillSelection()
    {
        for (int i = 0; i < skillImages.Length; i++)
        {
            skillImages[i].rectTransform.localScale = (i == selectedIndex) ? selectedScale : normalScale;
        }
    }
}