using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
