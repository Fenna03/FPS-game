using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject OGenemy;
    public int enemyMax;
    // Start is called before the first frame update
    void Start()
    {
        start2();
    }
    public void start2()
    {
        //gives amount of enemies
        for (int i = 0; i < enemyMax; i++)
        {
            //gives spawnpoint of enemies
            GameObject enemy = Instantiate(OGenemy, transform.position, Quaternion.identity);

        }
    }


}
