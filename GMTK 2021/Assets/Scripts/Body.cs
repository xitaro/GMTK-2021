using UnityEngine;

public class Body : MonoBehaviour
{
    private GravityAttractor attractor;
    public Rigidbody rb;

    private void Awake()
    {
        attractor = GameObject.Find("Ground").GetComponent<GravityAttractor>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    private void Update()
    {
        attractor.Attract(this);
    }
}
