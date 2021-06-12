using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private GravityAttractor attractor;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    private void Update()
    {
        attractor.Attract(this);
    }
}
