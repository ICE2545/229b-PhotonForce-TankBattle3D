using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GetHit: " + other.name); 

        if (other.CompareTag("Tank_4.1"))
        {
            Debug.Log("Hit!"); 

            TankHealth tankHealth = other.GetComponent<TankHealth>();

            if (tankHealth != null)
            {
                Debug.Log("TakeDamage: " + damage); 
                tankHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");

            Turret_behavior enemy = other.GetComponent<Turret_behavior>();

            if (enemy != null)
            {
                Debug.Log("TakeDamage: " + damage);
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Enemy Not Found " + other.name);
            }

            Destroy(gameObject);
        }
    }
}
