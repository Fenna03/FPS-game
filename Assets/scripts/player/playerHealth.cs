using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if (health <= 0)
        {
            //destroys Player when dead
            //Destroy(gameObject);
            Debug.Log(health);
        }
        else
        {
            //health decreases by 1 and shows me how much the health is
            health--;
            Debug.Log(health + "Goddamn you fuckin' assholes");
        }
    }
}
