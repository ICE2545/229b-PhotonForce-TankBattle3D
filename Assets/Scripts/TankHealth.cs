/*
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Get hit Hp remain: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Game Over!");
        gameObject.SetActive(false);
    }
}
*/

using UnityEngine;
using UnityEngine.UI; // ใช้สำหรับ UI

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100000;
    private int currentHealth;

    public Slider healthBar; // เชื่อมต่อกับ UI

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(); // อัปเดตค่า HP Bar ตอนเริ่มเกม
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthBar(); // อัปเดต HP Bar หลังจากโดนดาเมจ

        Debug.Log("โดนยิง! เลือดเหลือ: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // ปรับค่า Slider ตามเลือดที่เหลือ
        }
    }

    void Die()
    {
        Debug.Log("Player ตาย!");
        gameObject.SetActive(false);
    }
}
