using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private GameObject statisticsPanel;
    [SerializeField] private GameObject helpPanel;
    private StatisticsPanel statsPanelScript;

    private void Start () {
        statsPanelScript = statisticsPanel.GetComponent<StatisticsPanel>();
        statisticsPanel.SetActive (false);
        helpPanel.SetActive (false);
    }

    public void StartGame () {
        SceneManager.LoadScene (gameSceneName);
    }

    public void ShowStatistics () {
        statisticsPanel.SetActive (true);
        statsPanelScript.UpdateStatisticsDisplay ();
    }

    public void ShowHelp () {
        helpPanel.SetActive (true);
    }

    public void QuitGame () {
        #if UNITY_EDITOR
        Debug.Log ("Quit game!");
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit ();
    }
}
