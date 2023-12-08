using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public GameObject Dead;
    public Slider healthSlider;
    public int maxHealth = 50;
    public int health;
    public float healAmount = 5;
    public float timeBetweenHits = 2f;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        // Ensure healthSlider is assigned
        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned to the PlayerHealthUI script!");
        }

        // Set the max value of the health slider
        healthSlider.maxValue = maxHealth;
        // Set the initial health value
        healthSlider.value = health;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (health <= 49 && healAmount >= 1)
            {
                healAmount--;
                health += 5;
                healthSlider.value = health;
                Debug.Log("+5 health");
            }
            else
            {
                Debug.Log("You have enough health or used all your healing potions");
            }

        }
    }
    public void takeDamage()
    {
        if (health <= 0)
        {
            // Destroys Player when dead
            // Destroy(gameObject);
            Debug.Log(health);
            Dead.gameObject.SetActive(!Dead.gameObject.activeSelf);
            UpdateCursorState();
        }
        else
        {
            // Health decreases by 1 and shows how much health is remaining
            health--;
            healthSlider.value = health;
            Debug.Log(health + " Goddamn you fuckin' assholes");
        }
    }

    void UpdateCursorState()
    {

        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
