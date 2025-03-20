using UnityEngine;
using System.Collections;

public class Rush0 : MonoBehaviour
{
    public GameObject[] enemies; // 配置する敵のリスト
    public float[] spawnTimes;   // 各敵の出現時間（秒）
    public int eventIndex;  // このラッシュのイベント番号
    private bool isSpawning = false; // スポーンが開始されたかどうか
    private bool[] hasSpawned; // 各敵がスポーン済みかどうか

    private void Start()
    {
        // 各敵のスポーン状態を管理する配列を初期化
        hasSpawned = new bool[enemies.Length];

        // 初めはすべての敵を非アクティブにし、未スポーン状態にする
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
            hasSpawned[i] = false; // まだスポーンしていない
        }
    }

    void Update()
    {
        // イベントが有効になり、まだスポーンが開始されていないなら開始する
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
            // すでにスポーンした敵は再度スポーンさせない
            if (!hasSpawned[i])
            {
                yield return new WaitForSeconds(spawnTimes[i]); // 指定の時間待つ
                enemies[i].SetActive(true); // 敵をアクティブにする
                hasSpawned[i] = true; // スポーン済みにする
                Debug.Log($"敵 {i} を {spawnTimes[i]} 秒後にアクティブ化");
            }
        }
    }
}