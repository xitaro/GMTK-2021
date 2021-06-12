using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class Ground : MonoBehaviour
{
    // The speed the planet will rotate
    [HideInInspector]
    public float speed;
    [SerializeField] private float startSpeed;


    private void Start()
    {
        speed = startSpeed;
    }

    private void Update()
    {
        // Spin the object around the target at (speed) degrees/second.
        transform.RotateAround(transform.position, Vector3.left, speed * Time.deltaTime);
    }
    public IEnumerator ResetSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        speed = startSpeed;
    }
}
