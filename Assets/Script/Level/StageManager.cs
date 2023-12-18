using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public float spawnDistanceMin = 20f;
    public float spawnDistanceMax = 25f;
    public static StageManager instance;
    public List<StageData> stages;
    private StageData currentStage;
    private int stageNumber = 0;

    Player player;

    private int enemyCapacity = 50;
    private int enemyCurrentAmount = 0;

    private void Start () {
        instance = this;
        player = Player.instance;
        StartStage ();
    }

    public void StartStage () {
        player.GetComponent<Health> ().TakeHealing (25);
        currentStage = Instantiate(stages[stageNumber++]);
        StartCoroutine(SpawnRoutine ());
    }

    private IEnumerator SpawnRoutine () {
        while (true) {
            if (enemyCurrentAmount < enemyCapacity) {
                Transform enemy = FetchEnemyToSpawn();
                if (enemy == null) break; // No enemies left!
                SpawnEnemy (enemy);
            }

            yield return null;
        }
    }

    private Transform FetchEnemyToSpawn() {
        List<StageData.EnemySpawnData> pool = new List<StageData.EnemySpawnData>();
        foreach (StageData.EnemySpawnData esd in currentStage.enemiesToSpawn) {
            if (esd.spawnAmount > 0) pool.Add (esd);
        }

        if (pool.Count == 0) return null;

        int randomIndex = Random.Range(0, pool.Count);
        StageData.EnemySpawnData randomESD = pool[randomIndex];
        randomIndex = Random.Range (0, randomESD.enemyPrefabs.Count);
        Transform randomEnemy = randomESD.enemyPrefabs[randomIndex];
        randomESD.spawnAmount--;

        return randomEnemy;
    }

    private void SpawnEnemy ( Transform enemyPrefab ) {
        float randomAngle = Random.Range (0, 360) * Mathf.Deg2Rad;

        float randomSpawnDistance = Random.Range (spawnDistanceMin, spawnDistanceMax);
        Vector2 spawnDirection = new Vector2 (Mathf.Cos (randomAngle), Mathf.Sin (randomAngle));
        Vector2 spawnPosition = (Vector2)player.transform.position + spawnDirection * randomSpawnDistance;

        Instantiate (enemyPrefab, spawnPosition, Quaternion.identity);
        enemyCurrentAmount++;
    }

    public void EnemyDefeated () {
        enemyCurrentAmount--;
        if (enemyCurrentAmount <= 0 && !IsSpawningEnemies ()) {
            if (stageNumber >= stages.Count) {
                print ("TODO Game over");
                return;
            }
            else {
                UpgradeManager.instance.DisplayUpgrades (3);
            }
        }
    }

    private bool IsSpawningEnemies () => currentStage.enemiesToSpawn.Any (esd => esd.spawnAmount > 0);
}
