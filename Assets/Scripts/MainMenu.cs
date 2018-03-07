using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] private string levelToLoad = "MainLevel";

    private SceneFader sceneFader;

    private void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();

    }
}
