using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Ground")
        {
            Destroy(col.gameObject);
        }
    }
}
