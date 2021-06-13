using UnityEngine;

public class NpcWalk : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(Vector3.back) * speed * Time.deltaTime);
    }
}
