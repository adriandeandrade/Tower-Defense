using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWinUI : MonoBehaviour
{
    private string nextLevel;
    private string menuSceneName = "MainMenu";

    private SceneFader sceneFader;
    private UIManager uiManager;

    private void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
        uiManager = GetComponent<UIManager>();
    }

    public void NextLevel()
    {
        nextLevel = SceneUtils.GetNextSceneName();
        sceneFader.FadeTo(nextLevel);
    }

    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        uiManager.Deactivate("levelWinPanel");
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        uiManager.Deactivate("levelWinPanel");
    }
}
