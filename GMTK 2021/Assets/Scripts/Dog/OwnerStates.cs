using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnerStates : MonoBehaviour
{
    private int state;

    [SerializeField] private Image stateImage;

    [SerializeField] private GameManager gm;

    private void Start()
    {
        state = 0;
        stateImage.gameObject.SetActive(false);
    }

    // Call on animation event
    public void IncreaseAnger()
    {
        ShowStateUI();
        state += 1;
        StartCoroutine(HideUI());
        CheckState();
    }

    private void CheckState()
    {
        if (state > 3)
        {
            //Game Over
            gm.GameOver();
        }
    }

    private void ShowStateUI()
    {
        stateImage.gameObject.SetActive(true);
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(1.5f);
        stateImage.gameObject.SetActive(false);
    }
}
