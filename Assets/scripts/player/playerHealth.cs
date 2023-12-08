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
    public WeaponSwitch weaponSwitchScript;

    public GameObject healerVial;
    //public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();

        weaponSwitchScript = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitch>();
        //sets health
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
    public void Update()
    {
        //when you press R and you have potions and not full health you can heal +5 health, this will update everything
        if (Input.GetKeyDown(KeyCode.E) && weaponSwitchScript.newSelectedWeapon == 4)
        {
            if (health <= 49 && healAmount >= 1)
            {
                healAmount--;
                health += 5;
                healthSlider.value = health;
                Debug.Log("+5 health");
                GameObject.Find("VaccineVial_Purple").GetComponent<Animator>().Play("Healing");
            }
            else if (healAmount <= 0)
            {
                Destroy(healerVial);
                Debug.Log("You used all healing vials");
            }
            //this is shown when you have above 49 health or no health potions anymore
            else
            {
                Debug.Log("You have enough health");
            }
        }
    }
    public void takeDamage()
    {
        //if health is 0 or less than 0 it shows the dead message to try again or quit and you can use your mouse
        if (health <= 0)
        {
            Debug.Log(health);
            Dead.gameObject.SetActive(!Dead.gameObject.activeSelf);
            UpdateCursorState();
        }
        //if health is more than 0 it will decrease it by 1 and update the health bar
        else
        {
            // Health decreases by 1 and shows how much health is remaining
            health--;
            healthSlider.value = health;
            //Debug.Log(health + " Goddamn you fuckin' assholes");
        }
    }

    void UpdateCursorState()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
