using UnityEngine;
using System.Collections;

public class Rush0 : MonoBehaviour
{
    public GameObject[] enemies; // �z�u����G�̃��X�g
    public float[] spawnTimes;   // �e�G�̏o�����ԁi�b�j
    public int eventIndex;  // ���̃��b�V���̃C�x���g�ԍ�
    private bool isSpawning = false; // �X�|�[�����J�n���ꂽ���ǂ���
    private bool[] hasSpawned; // �e�G���X�|�[���ς݂��ǂ���

    private void Start()
    {
        // �e�G�̃X�|�[����Ԃ��Ǘ�����z���������
        hasSpawned = new bool[enemies.Length];

        // ���߂͂��ׂĂ̓G���A�N�e�B�u�ɂ��A���X�|�[����Ԃɂ���
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
            hasSpawned[i] = false; // �܂��X�|�[�����Ă��Ȃ�
        }
    }

    void Update()
    {
        // �C�x���g���L���ɂȂ�A�܂��X�|�[�����J�n����Ă��Ȃ��Ȃ�J�n����
        if (RushEventManager.Instance.eventFlags[eventIndex] && !isSpawning)
        {
            isSpawning = true;
            StartSpawning();
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            // ���łɃX�|�[�������G�͍ēx�X�|�[�������Ȃ�
            if (!hasSpawned[i])
            {
                yield return new WaitForSeconds(spawnTimes[i]); // �w��̎��ԑ҂�
                enemies[i].SetActive(true); // �G���A�N�e�B�u�ɂ���
                hasSpawned[i] = true; // �X�|�[���ς݂ɂ���
                Debug.Log($"�G {i} �� {spawnTimes[i]} �b��ɃA�N�e�B�u��");
            }
        }
    }
}