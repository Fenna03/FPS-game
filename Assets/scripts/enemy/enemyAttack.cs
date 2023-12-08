using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

public class enemyAttack : MonoBehaviour
{
    public enemyMoving em;
    private Transform player;

    private Renderer rend;
    public float attackRange = 15f;
    public float killRange = 3f;
    private bool foundPlayer;
    private Animator anim;
    private bool hasAttacked; // Flag to track whether an attack has been initiated

    private void Awake()
    {
        // gets player, rendering, and moving script
        em = GetComponent<enemyMoving>();
        // rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        hasAttacked = false; // Initialize the flag
    }

    // Update is called once per frame
    void Update()
    {
        // if enemy is close to player, change color, make it go to the player, has found player and increase speed
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            em.agent.SetDestination(player.position);
            foundPlayer = true;
            em.agent.speed = 5f;
        }
        // if they didn't find the player keep normal color, go to a random location, has not found the player and normal speed
        else if (foundPlayer)
        {
            em.newLocation();
            foundPlayer = false;
            em.agent.speed = 5f;
        }

        // Attack the player when within killRange
        if (Vector3.Distance(transform.position, player.position) <= killRange)
        {
            // Check if an attack has already been initiated
            if (!hasAttacked)
            {
                anim.Play("Attack1");
                player.GetComponent<playerHealth>().takeDamage();
                hasAttacked = true; // Set the flag to true to prevent continuous attacks
            }
        }
        else
        {
            // Reset the flag when the player is out of killRange
            hasAttacked = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            player.GetComponent<playerHealth>().takeDamage();
            //Debug.Log("Die player");
        }
    }
}

