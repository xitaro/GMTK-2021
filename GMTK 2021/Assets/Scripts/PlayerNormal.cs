using UnityEngine;

public class PlayerNormal : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    public void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 10f, groundLayer))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.yellow);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
    
}
