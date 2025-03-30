
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
        currentHealth -= damage;
        Debug.Log("Get hit! Hp remain: " + currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();

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
        else
        {
            Debug.LogWarning("HealthBar Disconnected!");
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
    }
}

/*
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
