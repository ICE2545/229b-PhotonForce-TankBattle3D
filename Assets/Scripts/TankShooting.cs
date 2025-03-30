using UnityEngine;
using UnityEngine.Audio;

public class TankShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public AudioClip shootSound;
    public AudioSource m_ShootingAudio;

    [Header("Fire Rate")]
    public float fireCooldown = 0.5f;
    private float fireTimer = 0f;

    void Start()
    {
        m_ShootingAudio = GetComponent<AudioSource>(); 
    }


    void Update()
    {
        fireTimer += Time.deltaTime;
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && fireTimer >= fireCooldown)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }

        if (shootSound != null && m_ShootingAudio != null)
        {
            m_ShootingAudio.PlayOneShot(shootSound);
        }
    }
}
