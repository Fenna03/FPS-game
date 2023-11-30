using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject OGBlock;
    public int blockMax;
    private float radius = 200f;


    // Start is called before the first frame update
    void Start()
    {
       //gives amount of blocks
        for (int i = 0; i < blockMax; i++)
        {
            //spawns blocks in random places in the circle
            GameObject NPC = Instantiate(OGBlock, Random.insideUnitSphere * radius + transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
