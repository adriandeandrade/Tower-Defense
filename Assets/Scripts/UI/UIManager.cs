using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelWinPanel;
    [SerializeField] private GameObject nodePanel;

    private Dictionary<string, GameObject> panelDictionary = new Dictionary<string, GameObject>();

    private void Awake()
    {
        panelDictionary.Add("pauseMenuPanel", pauseMenuPanel);
        panelDictionary.Add("gameOverPanel", gameOverPanel);
        panelDictionary.Add("levelWinPanel", levelWinPanel);
        panelDictionary.Add("nodePanel", nodePanel);
    }

    public void Activate(string panelName)
    {
        GameObject panel;
        if (panelDictionary.TryGetValue(panelName, out panel))
            panel.SetActive(true);
    }

    public void Deactivate(string panelName)
    {
        GameObject panel;
        if (panelDictionary.TryGetValue(panelName, out panel))
            panel.SetActive(false);
    }
}
