using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pullForce;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform owner;
    private Vector3 direction;

    public bool isPerformingAction;

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
        //CheckDistance();
        if (!isPerformingAction)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(direction) * speed * Time.deltaTime);
        }
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(owner.position, transform.position);

        if(distance > maxDistance)
        {
            Vector3 pullDirection = (transform.position - owner.position).normalized;
            Rigidbody ownerRb = owner.GetComponent<Rigidbody>();
            ownerRb.AddForce(pullDirection * pullForce, ForceMode.Impulse);
        }
    }
}