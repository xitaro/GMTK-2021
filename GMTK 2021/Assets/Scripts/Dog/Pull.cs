using UnityEngine;

public class Pull : MonoBehaviour
{
    private Transform owner;
    [SerializeField] private Rigidbody ownerRb;
    [SerializeField] private float maxDistance;
    [SerializeField] private float pullForce;
    private void Awake()
    {
        owner = GameObject.Find("Owner").transform;
        ownerRb = owner.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(owner.position, transform.position);

        if (distance > maxDistance)
        {
            ContinuousPull();
        }
    }

    private void ContinuousPull()
    {
        Vector3 pullDirection = (transform.position - owner.position).normalized;
        ownerRb.AddForce(pullDirection * pullForce , ForceMode.Impulse);
    }
}
