using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    public int setHealth = 20;
    private int health;

    private int NPCHealth;
    private int NPCHealthMax = 3;

    public GameObject Explosion;
    public GameObject enemy;

    private Animator anim;

    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = setHealth;
        NPCHealth = NPCHealthMax;

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
            anim.Play("TakeDamage.002");
            // health decreases by 1 and shows me how much the health is
            health--;
            Debug.Log(health);
        }
    }
    public void Break()
    {
        if (NPCHealth <= 0)
        {
            // destroys enemy when dead
            Destroy(gameObject);
            Debug.Log(NPCHealth);
        }
        else
        {
            // health decreases by 1 and shows me how much the health is
            NPCHealth--;
            Debug.Log(NPCHealth);
        }
    }
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }

    IEnumerator Explosie()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
    }
}
