using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private UIManager uiManager;
    private SceneFader sceneFader;

    private bool showing = false;
    [SerializeField] private string menuSceneName = "MainMenu";

    private void Start()
    {
        uiManager = GetComponent<UIManager>();
        sceneFader = FindObjectOfType<SceneFader>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (showing)
                HidePauseMenu();
            else
                ShowPauseMenu();
        }
    }

    void ShowPauseMenu()
    {
        showing = true;
        uiManager.Activate("pauseMenuPanel");
        Time.timeScale = 0f;
    }

    void HidePauseMenu()
    {
        showing = false;
        uiManager.Deactivate("pauseMenuPanel");
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        HidePauseMenu();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        HidePauseMenu();
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        HidePauseMenu();
    }
}
