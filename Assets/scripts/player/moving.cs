using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class moving : MonoBehaviour
{
    //gives the speed
    public float speed = 8f;

    //gives begin positions
    public float xPosition = 0f;
    public float yPosition = 30f;
    public float zPosition = -10f;

    //gives vector3 jump and the jumpforce
    public Vector3 jump;
    public float jumpForce = 2.0f;

    //boolean if it's true or false and short rigidbody for easy typing
    public bool isGrounded;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //gets actual rigidbody and jump
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        //says player is on ground
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //makes it so the player can jump in game
        Moving();
    }

    //makes player move all ways in code so it can be called in script
    public void Moving()
    {
        //with left shift you can speedrun or not, just to 12 speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (speed < 12f)
            {
                Debug.Log("Running");
                speed = speed + 4f;
            }
            else
            {
                speed = 12f;
            }

        }
        //if no left shift speed is normal
        else
        {
            speed = 8f;
        }
        //if you press any WASD key it goes that direction
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        //if space is pressed and the plaeyr is on the ground you can jump 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    //checks if player is grounded
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "Die")
        {
            xPosition = 0f;
            yPosition = 30f;
            zPosition = -10f;
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
