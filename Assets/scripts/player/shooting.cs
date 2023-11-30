using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Camera fpsCam;
    public GameObject enemy;
    public GameObject NPC;

    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        //with left mouse click
        if(Input.GetButtonDown("Fire1"))
        {
            //shoot in direction camera is looking, if hit enemy or NPC go to enemyHealth and grab the methods from that script
            ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag.Equals("NPC"))
                {
                    hit.collider.GetComponent<Enemyhealth>().Break();

                }
                if (hit.collider.tag.Equals("enemy"))
                {
                    hit.collider.GetComponent<Enemyhealth>().Die();
                }
            }
        }
    }
}
