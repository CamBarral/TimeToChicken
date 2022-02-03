using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthUI healthUI;
    public LootUI lootUI;
    public GameOverMenu gameOverMenu;
    public int currentHealth;

    private int _maxHealth;

    void Start()
    {
        _maxHealth = 10;
        currentHealth = _maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, _maxHealth);

        healthUI.UpdateHealth(currentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHealth(currentHealth);
    }

    void Die()
    {
        Time.timeScale -= 2.5f * Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);

        //Display "GameOverPanel" + Score.
        lootUI.GameOver();
        gameOverMenu.Quit();
    }
}
