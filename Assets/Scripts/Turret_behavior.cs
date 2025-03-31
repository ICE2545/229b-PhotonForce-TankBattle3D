using UnityEngine;
using UnityEngine.UI;

public class Turret_behavior : MonoBehaviour
{    
    public Transform target;  
    public float fireRate = 3f;  
    public float attackRange = 15f;  
    public GameObject projectile;  
    public Transform firePoint;
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    private float nextFireTime = 3f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            RotateTurret(); 

            if (Time.time >= nextFireTime)
            {
                Shoot();  // ‡√‘Ë¡¬‘ß
                nextFireTime = Time.time + 3f / fireRate; 
            }
        }
    }

    private void RotateTurret()
    {
        Vector3 direction = target.position - transform.position;  
        Quaternion lookRotation = Quaternion.LookRotation(direction);  
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 100f);  
    }

    private void Shoot()
    {
        if (projectile != null && firePoint != null)
        {
            GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * 20f, ForceMode.Impulse);  
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }   


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Gethit! EnemyHP Remain: " + currentHealth);

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar(); // Õ—ª‡¥µ HP Bar

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

