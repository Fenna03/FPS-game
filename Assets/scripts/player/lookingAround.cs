using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class lookingAround : MonoBehaviour
{
    public GameObject optionsMenu;
    public Transform player;

    public float lookSpeed = 3;
    public float speed = 100f;
    private float xRotation;

    private float yMouse;
    public float xMouse;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial cursor state based on the paused variable
        UpdateCursorState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           TogglePause();
        }

        if (!paused)
        {
            //gets the mouse Axis and uses it to move the player with whatever the fuck Qauternion is.
            xMouse = Input.GetAxis("Mouse X") * speed * 0.05f;
            yMouse = Input.GetAxis("Mouse Y") * speed * 0.05f;
            xRotation -= yMouse;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            player.Rotate(Vector3.up * xMouse);
        }
    }
    void UpdateCursorState()
    {
        if (paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void TogglePause()
    {
        optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        paused = !paused; // Toggle the paused state
        UpdateCursorState(); // Update the cursor state
    }
}



