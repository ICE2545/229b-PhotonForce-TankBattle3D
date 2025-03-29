using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;          // กระสุนที่ยิงออกไป
    public Transform firePoint;              // จุดที่กระสุนจะถูกสร้าง (ปากกระบอกปืน)
    public float bulletForce = 20f;          // ความแรงของกระสุน

    [Header("Fire Rate")]
    public float fireCooldown = 0.5f;        // เวลาระหว่างการยิงแต่ละครั้ง
    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        // เช็คว่าเรากดปุ่มยิง (คลิกซ้ายหรือ spacebar)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && fireTimer >= fireCooldown)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        // สร้างกระสุนที่ตำแหน่ง firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // เพิ่มแรงผลักให้กระสุนไปข้างหน้า
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}
