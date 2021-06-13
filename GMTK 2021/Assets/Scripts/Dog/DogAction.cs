using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DogAction : MonoBehaviour
{
    DogMovement dogMovement;
    [SerializeField] Ground ground;
    [SerializeField] private float timePerformingAction;

    private void Start()
    {
        dogMovement = GetComponent<DogMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>(); 
        if (interactable != null)
        {
            PerformAction(interactable.animation);
            other.isTrigger = false;
        }
    }

    private void PerformAction(string animationToPerform)
    {
        // animator.CrossFade(animationToPerform);
        Debug.Log("action being performed: " + animationToPerform);
        dogMovement.isPerformingAction = true;
        ground.speed = 0;
        StartCoroutine(ground.ResetSpeed(timePerformingAction));
        StartCoroutine(EndAction(timePerformingAction));
    }

    private IEnumerator EndAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dogMovement.isPerformingAction = false;
    }
}
