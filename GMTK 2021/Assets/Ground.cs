using UnityEngine;

public class Ground : MonoBehaviour
{
    // The speed the planet will rotate
    [SerializeField] private float speed;    

    private void Update()
    {
        // Spin the object around the target at (speed) degrees/second.
        transform.RotateAround(transform.position, Vector3.left, speed * Time.deltaTime);
    }
}
