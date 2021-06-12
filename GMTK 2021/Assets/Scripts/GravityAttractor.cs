using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    private float gravity = -9.81f;

    public void Attract(Body body)
    {
        Transform bodyTransform = body.transform;

        // Up direction of the gravity
        Vector3 gravityUp = (bodyTransform.position - transform.position).normalized;

        // The direction the body is currently facing
        Vector3 bodyUp = bodyTransform.up;

        body.rb.AddForce(gravityUp * gravity);


    }
}
