using System.Collections;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public Transform target;  // เป้าหมาย 
    public float fireRate = 1f;  // คูลดาวน์การยิง 
    public float attackRange = 15f;  // ระยะการโจมตี
    public GameObject projectile;  // กระสุนที่ยิงออกจากป้อม
    public Transform firePoint;  // จุดที่กระสุนจะถูกยิงออกจากป้อม

    private float nextFireTime = 0f;  // เวลาถัดไปที่จะสามารถยิงได้ (คูลดาวน์)
    
    private void Update()
    {
        // ตรวจสอบว่าเป้าหมาย (target) อยู่ในระยะการโจมตี
        if (target != null && Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            RotateTurret();  // หมุนป้อมไปยังเป้าหมาย
            
            // ตรวจสอบคูลดาวน์ว่าเราสามารถยิงได้หรือยัง
            if (Time.time >= nextFireTime)
            {
                Shoot();  // เริ่มยิง
                nextFireTime = Time.time + 1f / fireRate;  // รีเซ็ตเวลาคูลดาวน์
            }
        }
    }

    // ฟังก์ชันสำหรับหมุนป้อมปืนไปยังเป้าหมาย
    private void RotateTurret()
    {
        Vector3 direction = target.position - transform.position;  // คำนวณทิศทางไปยังเป้าหมาย
        Quaternion lookRotation = Quaternion.LookRotation(direction);  // สร้างการหมุนให้หันไปที่เป้าหมาย
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 100f);  // หมุนป้อมปืน
    }

    // ฟังก์ชันสำหรับการยิงกระสุน
    private void Shoot()
    {
        // สร้างกระสุนจาก firePoint และให้กระสุนเคลื่อนที่ไปข้างหน้า
        if (projectile != null && firePoint != null)
        {
            GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * 20f, ForceMode.Impulse);  // เพิ่มแรงยิงไปในทิศทางของ firePoint
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}