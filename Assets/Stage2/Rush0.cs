using UnityEngine;
using System.Collections;

public class Rush0 : MonoBehaviour
{
    public GameObject[] enemies; // 配置する敵のリスト
    public float[] spawnTimes;   // 各敵の出現時間（秒）

    private void Start()
    {
        // 初めはすべての敵を非アクティブにする
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
            yield return new WaitForSeconds(spawnTimes[i]); // 指定の時間待つ

            enemies[i].SetActive(true); // 敵をアクティブにする
            Debug.Log($"敵 {i} を {spawnTimes[i]} 秒後にアクティブ化");
        }
    }
}