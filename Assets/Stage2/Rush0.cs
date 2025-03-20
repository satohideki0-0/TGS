using UnityEngine;
using System.Collections;

public class Rush0 : MonoBehaviour
{
    public GameObject[] enemies; // �z�u����G�̃��X�g
    public float[] spawnTimes;   // �e�G�̏o�����ԁi�b�j

    private void Start()
    {
        // ���߂͂��ׂĂ̓G���A�N�e�B�u�ɂ���
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
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
            yield return new WaitForSeconds(spawnTimes[i]); // �w��̎��ԑ҂�

            enemies[i].SetActive(true); // �G���A�N�e�B�u�ɂ���
            Debug.Log($"�G {i} �� {spawnTimes[i]} �b��ɃA�N�e�B�u��");
        }
    }
}