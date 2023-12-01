using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int setHealth = 20; 
    private int health;
    private int NPCHealth;
    private int NPCHealthMax = 3;
    public GameObject Explosion;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        health = setHealth;
        NPCHealth = NPCHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        //if their health is less than 10 something happens
        if(health <= 0)
        {
            //gives explosion, don't destroy explosion when enemy dies
            //Instantiate(Explosion, new Vector3(0,2,0), Quaternion.identity);
            //DontDestroyOnLoad(Instantiate(Explosion, new Vector3(0, 2, 0), Quaternion.identity));
            //destroys enemy when dead
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Die");
            StartCoroutine(Destruction());
            Debug.Log(health);

        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Hit");
            //health decreases by 1 and shows me how much the health is
            health--;
            Debug.Log(health);
        }
    }

    public void Break()
    {
        if (NPCHealth <= 0)
        {
            //destroys enemy when dead
            Destroy(gameObject);
            Debug.Log(NPCHealth);
        }
        else
        {
            //health decreases by 1 and shows me how much the health is
            NPCHealth--;
            Debug.Log(NPCHealth);
        }
    }

    IEnumerator Destruction()
    {

        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);

    }
}
