using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ground ground;

    [SerializeField] private Text distanceText;

    [SerializeField] private float endGameDistance;
    [SerializeField] private float currentGameDistance;

    private void Start()
    {
        currentGameDistance = 0;
    }

    private void Update()
    {
        if (ground.speed > 0)
        {
            currentGameDistance += Time.deltaTime;
            distanceText.text = currentGameDistance.ToString();
        }

        if(currentGameDistance >= endGameDistance)
        {
            // Ganhou o level!
        }
    }
}
