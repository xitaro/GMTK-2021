using UnityEngine;

public class ObstacleNormal : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform Ground;

    private void Awake()
    {
        Ground = GameObject.Find("Ground").transform;
    }

    private void Start()
    {
        transform.SetParent(Ground);
    }
    
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
