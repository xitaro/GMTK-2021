using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(direction) * speed * Time.deltaTime);
    }
}