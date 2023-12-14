using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    //sets enemy health
    public int setHealth = 20;
    private int health;
    public Slider healthSlider;

    //sets block health
    private int NPCHealth;
    private int NPCHealthMax = 3;

    //gameObjects which are needed
    public GameObject Explosion;
    public GameObject enemy;

    //so animations play
    private Animator anim;

    //booleans
    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        //gets the animator, and sets health amount for npc and enemy
        anim = GetComponent<Animator>();
        health = setHealth;
        NPCHealth = NPCHealthMax;

        // Set the max value of the health slider
        healthSlider.maxValue = setHealth;
        // Set the initial health value
        healthSlider.value = health;
    }
    public void Die()
    {
        // if their health is less than or equal to 0 something happens
        if (health <= 0 && !hasExploded)
        {
            // gives explosion
            hasExploded = true; 
            // destroys enemy when dead
            anim.Play("Death");
            StartCoroutine(Destruction());
            StartCoroutine(Explosie());
            Debug.Log(health);
        }
        else
        {
            //play animation
            anim.Play("TakeDamage.002");
            // health decreases by 1 and shows me how much the health is
            health--;
            Debug.Log(health);
            healthSlider.value = health;
        }
    }
    public void Break()
    {
        if (NPCHealth <= 0)
        {
            // destroys enemy when dead
            Destroy(gameObject);
            //Debug.Log(NPCHealth);
            
        }
        else
        {
            // health decreases by 1 and shows me how much the health is
            NPCHealth--;
            //Debug.Log(NPCHealth);
            
        }
    }
    IEnumerator Destruction()
    {
        //after waiting for 1.4 seconds it will destroy the gameobject
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }

    IEnumerator Explosie()
    {
        //after waiting for 0.4 seconds it will give an explosion
        yield return new WaitForSeconds(0.4f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }
}
