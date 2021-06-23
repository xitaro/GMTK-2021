using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Satisfaction : MonoBehaviour
{
    private int level = 3;

    [SerializeField] private Image satisfactionImage;
    [SerializeField] private Sprite[] satisfactionSprites;
    [SerializeField] private Sprite increaseSprite;

    private void Start()
    {
        satisfactionImage.gameObject.SetActive(false);
    }

    public void DecreaseSatisfaction()
    {
        level -= 1;
        CheckSatisfaction();
        ShowCurrentState();
        StartCoroutine(HideUI());
    }

    public void IncreaseSatisfaction()
    {
        level += 1;
        CheckSatisfaction();
        ShowIncreasingState();
        StartCoroutine(HideUI());
    }

    private void ShowCurrentState()
    {
        satisfactionImage.sprite = satisfactionSprites[level];
        satisfactionImage.gameObject.SetActive(true);
    }
    
    private void ShowIncreasingState()
    {
        satisfactionImage.sprite = increaseSprite;
        satisfactionImage.gameObject.SetActive(true);
    }

    private void CheckSatisfaction()
    {
        if (level >= 3)
        {
            level = 3;
        }
        else if (level <= 0)
        {
            //GameOver
        }
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(1.5f);
        satisfactionImage.gameObject.SetActive(false);
    }
}
