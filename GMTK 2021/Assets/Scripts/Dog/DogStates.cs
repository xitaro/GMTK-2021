using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogStates : MonoBehaviour
{
    private int state;

    [SerializeField] private Image stateImage;
    [SerializeField] private Sprite[] stateSprites;

    private void Start()
    {
        state = 3;
        stateImage.gameObject.SetActive(false);
    }

    // Call on animation event
    public void IncreaseState()
    {
        ShowStateUI();
        state += 1;
        if (state >= 3)
        {
            state = 3;
        }
    }

    // Call on animation event
    public void DecreaseState()
    {
        ShowStateUI();
        state -= 1;
        CheckState();
    }

    private void CheckState()
    {
        if (state == 0)
        {
            //Game Over
        }
    }

    private void ShowStateUI()
    {
        switch (state)
        {
            case 3:
                // Change State Image
                stateImage.sprite = stateSprites[3];
                stateImage.color = Color.green;
                break;
            case 2:
                // Change State Image
                stateImage.sprite = stateSprites[2];
                stateImage.color = Color.yellow;
                break;
            case 1:
                // Change State Image
                stateImage.sprite = stateSprites[1];
                stateImage.color = Color.red;
                break;
            case 0:
                // Change State Image
                stateImage.sprite = stateSprites[0];
                stateImage.color = Color.black;
                break;
        }

        stateImage.gameObject.SetActive(true);
    }
}
