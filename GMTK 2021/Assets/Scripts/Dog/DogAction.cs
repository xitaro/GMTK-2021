using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DogAction : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>(); 
        if (interactable != null)
        {
            interactable.action.Invoke();
        }
    }

    public void Bark()
    {
        Debug.Log("Bark");
    }

    public void Pee()
    {
        Debug.Log("Pee");
    }

    public void Poop()
    {
        Debug.Log("Poop");
    }

    public void PokeAround()
    {
        Debug.Log("Poke");
    }

    public void DrinkWater()
    {
        Debug.Log("Drink");
    }
}
