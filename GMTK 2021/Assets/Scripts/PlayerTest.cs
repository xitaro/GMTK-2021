using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Transform player;
    [SerializeField] private Transform planet;
    float gravity = -9.81f;

    private void Update()
    {
        transform.GetComponent<Rigidbody>().AddForce((transform.position - planet.position).normalized * gravity);

    }

}
