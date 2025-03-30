using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25; // ดาเมจของกระสุน

    private void OnTriggerEnter(Collider other)
    {
        // ถ้ากระสุนชน Player
        if (other.CompareTag("Player"))
        {
            TankHealth playerHealth = other.GetComponent<TankHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // ทำลายกระสุนเมื่อโดนตัว Player
        }
    }
}
