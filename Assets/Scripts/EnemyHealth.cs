using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;
    public static int enemyCount = 0;
    public GameObject victoryUI;
    public GameObject victoryPanel;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        enemyCount++;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Hit! HP Remain: " + currentHealth);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            DestroyEnemy();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Defeated!");
        enemyCount--; 

        if (enemyCount <= 0)
        {
            PlayerWin();
        }

        Destroy(gameObject);
    }

    void PlayerWin()
    {
        Debug.Log("You're Alive!");
        victoryPanel.SetActive(true); 
    }

    void DestroyEnemy()
    {
        enemyCount--;
        Destroy(gameObject);
        CheckVictory();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / (float)maxHealth;
        }
    }

    void CheckVictory()
    {
        if (enemyCount <= 0)
        {
            Debug.Log("Victory! You're Alive!");
            victoryUI.SetActive(true);
        }      
    }
}
/*{
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
}*/
