using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public Slider hpSlider;  
    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;  
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10); 
        }

        Debug.Log("Current HP Bar Value: " + hpSlider.value);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        hpSlider.value = currentHP;

        if (currentHP <= 0)
        {
            Die();  
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");  
    }
}
