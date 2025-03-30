using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.5f;
    public static List<Gravity> planetLists;
    public Transform player;
    public float detectRange = 5f;
    public float speed = 0.5f;


    [SerializeField] bool planet = false;
    [SerializeField] int orbitSpeed = 1000;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<Gravity>();
        }

        planetLists.Add(this);

        if (!planet)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }

    private void FixedUpdate()
    {
        foreach (var planet in planetLists)
        {
            if (planet != this)
                Attract(planet);
        }

        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectRange)  
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }

        void Attract(Gravity other)
        {
            Rigidbody otherRb = other.rb; 

            Vector3 direction = rb.position - otherRb.position;
            float distance = direction.magnitude;

            float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
            Vector3 finalForce = forceMagnitude * direction.normalized;

            otherRb.AddForce(finalForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
