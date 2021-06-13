using UnityEngine;

public class Collar : MonoBehaviour
{
    [SerializeField] private GameObject collarBone;
    [SerializeField] private GameObject leashBone;

    [SerializeField] private Transform collarOffset;
    [SerializeField] private Transform leashOffset;

    private void Update()
    {
        collarBone.transform.position = collarOffset.position;
        leashBone.transform.position = leashOffset.position;
    }
}
