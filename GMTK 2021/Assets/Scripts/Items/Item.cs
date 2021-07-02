using UnityEngine;

public class Item : Interactable
{
    [SerializeField] private string need;
    public string  Need { get {return need; } }
}
