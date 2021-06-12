using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public bool foward, backward, right, left;
    private Rigidbody rigidBody;
    
    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        CheckInputs();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void CheckInputs() {
        /*Input.GetKey("d")*/
        if (Input.GetKey(KeyCode.W))
            foward = true;
        if (Input.GetKey(KeyCode.S))
            backward = true;
        if (Input.GetKey(KeyCode.A))
            left = true;
        if (Input.GetKey(KeyCode.D))
            right = true;
    }

    public void Move() {
        if (foward) {
            rigidBody.AddForce(Vector3.forward * speed);
            foward = false;
        }
        if (backward)
        {
            rigidBody.AddForce(Vector3.back * speed);
            backward = false;
        }
        if (right)
        {
            rigidBody.AddForce(Vector3.right * speed);
            right = false;
        }
        if (left)
        {
            rigidBody.AddForce(Vector3.left * speed);
            left = false;
        }
    }

}
