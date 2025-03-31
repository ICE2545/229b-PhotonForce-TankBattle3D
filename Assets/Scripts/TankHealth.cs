
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour

{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject gameOverUI; 

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar == null)
        {
            healthBar = FindObjectOfType<HealthBar>(); 
        }
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        Debug.Log("Get hit! Hp remain: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true); 
        gameObject.SetActive(false); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}

/*{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        Debug.Log("Get hit! Hp remain: " + currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Tank Destroyed!");
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.GetComponent<Slider>().value = (float)currentHealth / (float)maxHealth; 
        }
        else
        {   
            Debug.LogWarning("HealthBar Disconnected!");
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}


using UnityEngine;
using UnityEngine.UI; 

public class TankHealth : MonoBehaviour
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
        Debug.Log("TakeDamage: " + damage); 

        currentHealth -= damage;
       
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();  

        Debug.Log("เลือดปัจจุบัน: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / (float)maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player ตาย!");
        gameObject.SetActive(false);
    }
}*/
