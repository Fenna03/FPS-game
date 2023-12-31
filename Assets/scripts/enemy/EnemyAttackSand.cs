using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

public class EnemyAttackSand : MonoBehaviour
{
    public enemyMoving em;
    private Transform player;

    private Renderer rend;
    public float attackRange = 15f;
    public float killRange = 3f;
    public bool foundPlayer;
    private Animator anim;
    private bool hasAttacked; // Flag to track whether an attack has been initiated

    private Vector2 playerXZ;
    private Vector2 enemyXZ;

    private float attackTimer;
    private float attackRate = 1f;

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
        attackTimer += Time.deltaTime;
        playerXZ = new Vector2(player.transform.position.x, player.transform.position.z);
        enemyXZ = new Vector2(transform.position.x, transform.position.z);

        // if enemy is close to player, change color, make it go to the player, has found player and increase speed
        if (Vector2.Distance(enemyXZ, playerXZ) <= attackRange)
        {
            em.agent.SetDestination(player.position);
            foundPlayer = true;
            em.agent.speed = 5f;
            //Debug.Log("Ya found the player");
        }
        // if they didn't find the player go to a random location, has not found the player and normal speed
        else if (foundPlayer)
        {
            em.newLocation();
            foundPlayer = false;
            em.agent.speed = 5f;
            Debug.Log("Ya lost the player");
        }

        // Attack the player when within killRange
        if (Vector2.Distance(enemyXZ, playerXZ) <= killRange)
        {
            //Debug.Log("Ya very close to player");
            // Check if an attack has already been initiated
            if (attackTimer > attackRate)
            {
                anim.Play("Attack_2"); //plays attack
                player.GetComponent<playerHealth>().takeDamage(); //gets the health from player to do damage
                attackTimer = 0; //resets timer
                //Debug.Log("Ya attacked bitch");
            }
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
