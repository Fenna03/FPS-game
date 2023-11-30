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
    public int attacking = 1;
    private bool foundPlayer;
    private Animation anim;

    private void Awake()
    {

        //gets player, rendering and moving script
        em = GetComponent<enemyMoving>();
        //rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if enemy is close to player, change color, make it go to player, has found player and increase speed
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            em.agent.SetDestination(player.position);
            foundPlayer = true;
            em.agent.speed = 5f;
        }
        //if they didn't find player keep normal color, go to random location, has not found player and normal speed
        else if(foundPlayer)
        {
            em.newLocation();
            foundPlayer = false;
            em.agent.speed = 5f;
        }

        //if (Vector3.Distance(transform.position, player.position) <= attacking)
        //{
              //GetComponent<playerHealth>().takeDamage();
              //Debug.Log("Die player");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            GetComponent<playerHealth>().takeDamage();
            Debug.Log("Die player");
        }
    }
}
