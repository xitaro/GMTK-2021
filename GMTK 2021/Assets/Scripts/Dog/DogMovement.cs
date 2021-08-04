using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float pullForce;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform owner;
    private Vector3 direction;

    public bool isPerformingAction;

    private Rigidbody rb;
    [SerializeField]
    private Transform playerModel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //RotateForward();
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
  
    // Rotate player to face direction of movement
    private void RotateForward()
    {
        Vector3 dir = direction;
        // calculate angle and rotation
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        // only update rotation if direction greater than zero
        if (Vector3.Magnitude(dir) > 0.0f)
        {
            playerModel.localRotation = targetRotation;
        }
    }
}