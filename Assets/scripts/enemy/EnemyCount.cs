using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public int enemyCount;
    public GameObject Won;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        //Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            Won.gameObject.SetActive(!Won.gameObject.activeSelf);
            UpdateCursorState();
        }

    }

    void UpdateCursorState()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
