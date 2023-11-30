using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMoving : MonoBehaviour
{
    public float squareOfMovement = 200f;
    public NavMeshAgent agent;

    private float xMin;
    private float zMin;
    private float xMax;
    private float zMax;

    private float xPos;
    private float yPos;
    private float zPos;

    public float closeEnough = 2f;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        //gives the square of where they can walk
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        // if they get close enough to their location they get a new location to go to
        if(Vector3.Distance(transform.position, new Vector3(xPos, yPos, zPos)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        //gets random cordinates to walk to
        xPos = Random.Range(xMin, xMax);
        yPos = transform.position.y;
        zPos = Random.Range(zMin, zMax);

        agent.SetDestination(new Vector3(xPos, yPos, zPos));
        anim.Play("Walk");
    }

}
