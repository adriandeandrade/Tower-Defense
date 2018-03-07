using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float startHealth = 100f;

    [HideInInspector] public float speed;
    [HideInInspector] public float health = 100f;
    [HideInInspector] public int worth = 50;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth; // Update the healthbar

        if (health <= 0f)
            Die();
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 5f);

        WaveSpawner.EnemiesKilled++;
        Destroy(gameObject);
    }
}
