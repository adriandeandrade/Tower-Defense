using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesKilled = 0;

    [Header("References")]
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveCountdownText;
    private GameManager gameManager;

    [Header("Variables")]
    private int enemiesToKill;
    private int waveIndex = 0;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    [HideInInspector] public bool isSpawning = false;
    [HideInInspector] public bool allDead = false;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (waveIndex == waves.Length)
        {
            if(allDead)
            {
                gameManager.WinLevel();
                this.enabled = false;
                return;
            }
        }

        if (EnemiesKilled >= enemiesToKill)
        {
            EnemiesKilled = 0;
            enemiesToKill = 0;
            allDead = true;
            
        }
        else
        {
            return;
        }

        UpdateCountdown();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        enemiesToKill = wave.count;
        allDead = false;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void UpdateCountdown()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next wave in: " + Mathf.Round(countdown).ToString();
    }
}
