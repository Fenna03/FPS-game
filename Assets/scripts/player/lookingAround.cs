using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lookingAround : MonoBehaviour
{
    public Transform player;
    public float xMouse;
    public float lookSpeed = 3;
    public float speed = 100f;
    private float xRotation;
    private float yMouse;

    

    // Start is called before the first frame update
    void Start()
    {
        //removes cursor from screen when screen is clicked
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
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
