using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    [SerializeField] private int currentLevel;
    [SerializeField] private int totalLevels = 3;

    private UIManager uiManager;
    private SceneFader sceneFader;
    private WaveSpawner waveSpawner;

    private string nextLevel;

    private void Start()
    {
        GameIsOver = false;
        //nextLevel = SceneUtils.GetNextSceneName();
        sceneFader = FindObjectOfType<SceneFader>();
        uiManager = GetComponent<UIManager>();
        waveSpawner = GetComponent<WaveSpawner>();
    }

    private void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();

        if (currentLevel == totalLevels)
        {
            if(!waveSpawner.allDead && !waveSpawner.isSpawning)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        GameIsOver = true;
        uiManager.Activate("gameOverPanel");
    }

    public void WinLevel()
    {
        uiManager.Activate("levelWinPanel");
        Debug.Log("LEVEL WON!");
        
    }
}
