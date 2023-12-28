using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    #if UNITY_EDITOR
    public bool testMode = false;
    #endif
    public float spawnDistanceMin = 20f;
    public float spawnDistanceMax = 25f;
    public static StageManager instance;
    public List<StageData> stages;
    private StageData currentStage;
    private int stageNumber;

    Player player;

    private int enemyCapacity = 50;
    private int enemyCurrentAmount = 0;
    private int enemiesKilled;

    private void Start () {
        instance = this;
        player = Player.instance;

        StatisticsManager.instance.ResetStatsForNewGame ();
        enemiesKilled = 0;
        stageNumber = 0;

        #if UNITY_EDITOR
        if (testMode) return;
        #endif
        StartStage ();
    }

    public void StartStage () {
        Health hp = player.GetComponent<Health>();
        hp.TakeHealing (hp.maxHealth);
        currentStage = Instantiate(stages[stageNumber++]);
        MessageText.instance.DisplayMessage ("Wave - " + stageNumber);
        if(currentStage.music != null) AudioManager.instance.PlayMusic (currentStage.music);
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
    }

    public void EnemyDefeated () {
        enemyCurrentAmount--;
        enemiesKilled++;
        if (currentStage == null) return;

        if (enemyCurrentAmount <= 0 && !IsSpawningEnemies ()) {
            CheatCommand.instance.KillAllEnemies ();
            if (stageNumber >= stages.Count) {
                HandleWinGame ();
                return;
            }
            else {
                UpgradeManager.instance.DisplayUpgrades (5);
            }
        }
    }

    public void RegisterNewEnemy () => enemyCurrentAmount++;

    private void HandleWinGame() {
        MessageText.instance.DisplayMessage ("All threats have been vanquished!", 8f);

        StatisticsManager.instance.RecordGameStats (stageNumber, enemiesKilled);
        StartCoroutine (LoadMainMenuAfterDelay (8));
    }

    public void HandleLoseGame() {
        if(stageNumber >= 11) MessageText.instance.DisplayMessage ("Thy heroic stand will not be forgotten. For the while.", 8f);
        else if (stageNumber >= 6) MessageText.instance.DisplayMessage ("Your efforts were admirable, however in vain they may have been.", 8f);
        else if (stageNumber > 1) MessageText.instance.DisplayMessage ("Victory is never guaranteed, but with this performance the defeat was.", 8f);
        else MessageText.instance.DisplayMessage ("Pitiful.", 8f);

        StatisticsManager.instance.RecordGameStats (stageNumber, enemiesKilled);
        StartCoroutine (LoadMainMenuAfterDelay (8));
    }

    private bool IsSpawningEnemies () => currentStage.enemiesToSpawn.Any (esd => esd.spawnAmount > 0);

    IEnumerator LoadMainMenuAfterDelay ( float delay ) {
        yield return new WaitForSeconds (delay); // Wait for the specified delay
        AudioManager.instance.PlayMenuMusic ();
        SceneManager.LoadScene ("MainMenu"); // Replace "MainMenu" with the actual name of your main menu scene
    }
}
