using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DogAction : MonoBehaviour
{
    DogMovement dogMovement;
    [SerializeField] Ground ground;
    [SerializeField] private float timePerformingAction;
    [SerializeField] Animator anim;

    [SerializeField] TaskManager taskManager;

    private void Start()
    {
        dogMovement = GetComponent<DogMovement>();
        anim = GetComponentInChildren<Animator>();
        ground = GameObject.Find("Ground").GetComponent<Ground>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == taskManager.goalGameObject)
        {
            taskManager.TaskCompleted();
        }
        
        Interactable interactable = other.GetComponent<Interactable>(); 
        if (interactable != null)
        {
            PerformAction(interactable.animation);
            other.isTrigger = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void PerformAction(string animationToPerform)
    {
        anim.CrossFade(animationToPerform, 0.2f);
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
