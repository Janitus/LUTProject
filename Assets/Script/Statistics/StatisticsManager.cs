using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager instance;
    private GameStatistics stats;
    private List<GameStatistics> allGameStatistics = new List<GameStatistics> ();
    private string statsFilePath;

    private void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad (gameObject);
            statsFilePath = Path.Combine (Application.persistentDataPath, "gameStats.json");
            LoadStatistics ();
        }
    }

    public void ResetStatsForNewGame () {
        stats = new GameStatistics ();
        stats.totalEnemiesKilled = 0;
        stats.stageReached = 0;
    }

    public void RecordGameStats ( int stageNumber, int enemiesKilled ) {
        stats.totalEnemiesKilled = enemiesKilled;
        stats.stageReached = stageNumber;
        stats.lastGameDateTime = DateTime.Now.ToString ();
        allGameStatistics.Add (stats);
        SaveStatistics ();
    }

    private void SaveStatistics () {
        try {
            #if UNITY_EDITOR
            Debug.Log ("Saving stats to: " + statsFilePath);
            #endif
            string json = JsonUtility.ToJson (new GameStatisticsList { allGameStatistics = this.allGameStatistics }, true);
            File.WriteAllText (statsFilePath, json);
        } catch (Exception e) {
            Debug.LogError ("An error occurred while saving statistics: " + e.Message);
        }
    }

    private void LoadStatistics () {
        if (File.Exists (statsFilePath)) {
            try {
                string json = File.ReadAllText (statsFilePath);
                GameStatisticsList loadedStatsList = JsonUtility.FromJson<GameStatisticsList> (json);
                allGameStatistics = loadedStatsList.allGameStatistics ?? new List<GameStatistics> ();
            } catch (Exception e) {
                Debug.LogError ("An error occurred while loading statistics: " + e.Message);
                allGameStatistics = new List<GameStatistics> (); // Reset or handle as needed
            }
        }
        else {
            allGameStatistics = new List<GameStatistics> (); // Initialize if file doesn't exist
        }
    }

    public List<GameStatistics> GetAllGameStatistics () {
        int count = allGameStatistics.Count;
        int start = Mathf.Max (0, count - 10);
        return allGameStatistics.GetRange (start, count - start);
    }


    [Serializable]
    public class GameStatistics
    {
        public int totalEnemiesKilled;
        public int stageReached;
        public string lastGameDateTime;
    }

    [Serializable]
    public class GameStatisticsList
    {
        public List<GameStatistics> allGameStatistics = new List<GameStatistics> ();
    }
}
