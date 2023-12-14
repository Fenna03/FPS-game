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

    public float closeEnough = 5f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //gives the square of where they can walk
        xMin = -236;
        xMax = 209;
        zMin = 174;
        zMax = -290;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(xPos, zPos)));
        // if they get close enough to their location they get a new location to go to
        if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(xPos, yPos, zPos)) <= closeEnough)
        {
            Debug.Log("New location");
            newLocation();
        }
    }

    public void newLocation()
    {
        // gets random coordinates to walk to
        xPos = Random.Range(xMin, xMax);
        yPos = Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0f, zPos));
        zPos = Random.Range(zMin, zMax);
        agent.SetDestination(new Vector3(xPos, yPos, zPos));
        anim.Play("Walk");
        //Debug.Log($"Setting new destination: xPos={xPos}, yPos={yPos}, zPos={zPos}");
    }
}
