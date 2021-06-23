using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 direction;
    [SerializeField] private Vector3 offSet;
    private Rigidbody rb;
    [SerializeField] private float speed;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CalculateDirection();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void CalculateDirection()
    {
        direction = (target.position - transform.position) - offSet;
        direction.Normalize();
    }

    private void MoveCharacter()
    {
        rb.MovePosition(rb.position + (transform.TransformDirection(direction) * speed * Time.deltaTime));
    }
}
