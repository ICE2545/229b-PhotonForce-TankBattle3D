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
                Debug.Log("TakeDamge: " + damage); 
                tankHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
