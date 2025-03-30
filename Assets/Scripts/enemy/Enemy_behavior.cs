using System;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_behavior : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private LayerMask ground, target;
    
    //for enemy
    public int health;
    
    //for attacking
    public float cooldown = .5f;
    bool attack;
    public GameObject projectile;
    
    //for states
    public float attackRange;
    public bool playerInSight, playerInRange;

    private void Awake()
    {
        player = GameObject.Find("Tank_4.1").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //check for sight and attack
        playerInRange = Physics.CheckSphere(transform.position, attackRange, target);

        chasing();
        //if player in attackrange = attacking
        if (playerInRange)
        {
            attacking();
        }
    }

    void chasing()
    {
        enemy.SetDestination(player.position);
    }

    private void attacking()
    {
        //make enemy stop moving
        enemy.SetDestination(transform.position);
        
        //make enemy look at player
        transform.LookAt(player);
        
        //cooldown
        if (!attack)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            attack = true;
            Invoke(nameof(Resetattack), cooldown);
        }
    }

    private void Resetattack()
    {
        attack = false;
    }

    void takedamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}


