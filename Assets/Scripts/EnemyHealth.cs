using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Gethit! EnemyHP Remain: " + currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar(); // �ѻവ HP Bar

        if (currentHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / (float)maxHealth;
        }
        else
        {
            Debug.LogWarning("HealthBar Disconnected!");
        }
    }

    void Die()
    {
        Debug.Log("Clear!");
        gameObject.SetActive(false);
    }
}
