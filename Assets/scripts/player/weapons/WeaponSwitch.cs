using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int newSelectedWeapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (newSelectedWeapon >= transform.childCount - 1)
            {
                newSelectedWeapon = 0; 
            }
            else
            {
                newSelectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (newSelectedWeapon <= 0)
            {
                newSelectedWeapon = transform.childCount - 1;
            }
            else
            {
                newSelectedWeapon--;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            newSelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            newSelectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            newSelectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 4)
        {
            newSelectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 5)
        {
            newSelectedWeapon = 4;
        }

        if (newSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }

    public void selectWeapon()
    {
        selectedWeapon = newSelectedWeapon;
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == newSelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                Debug.Log("activated " + i);
            }
            
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
