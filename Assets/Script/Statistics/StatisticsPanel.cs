using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatisticsPanel : MonoBehaviour
{
    public GameObject statisticsPanel;
    public TextMeshProUGUI statisticsText;
    private StatisticsManager statisticsManager;

    void Start () {
        statisticsManager = StatisticsManager.instance;
    }

    public void UpdateStatisticsDisplay () {
        var allStats = StatisticsManager.instance.GetAllGameStatistics ();
        string statsDisplayText = "";

        for (int i = 0; i < Mathf.Min (allStats.Count, 10); i++) {
            var stat = allStats[allStats.Count - 1 - i];
            statsDisplayText += $"Stage {stat.stageReached} - {stat.totalEnemiesKilled} kills\n";
        }

        statisticsText.text = statsDisplayText;
    }

    public void HideStatistics () {
        statisticsPanel.SetActive (false);
    }
}
