using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Satisfaction : MonoBehaviour
{
    private GameManager gm;

    private int level = 3;

    [SerializeField] private Image satisfactionImage;
    [SerializeField] private Sprite[] satisfactionSprites;
    [SerializeField] private Sprite increaseSprite;

    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        satisfactionImage.gameObject.SetActive(false);
    }

    public void DecreaseSatisfaction()
    {
        level -= 1;
        CheckSatisfaction();
        ShowCurrentSatisfaction();
        StartCoroutine(HideUI());
    }

    public void IncreaseSatisfaction()
    {
        level += 1;
        CheckSatisfaction();
        ShowIncreasingSatisfaction();
        StartCoroutine(HideUI());
    }

    private void ShowCurrentSatisfaction()
    {
        satisfactionImage.sprite = satisfactionSprites[level];
        satisfactionImage.gameObject.SetActive(true);
    }
    
    private void ShowIncreasingSatisfaction()
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
            gm.GameOver();
        }
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(1.5f);
        satisfactionImage.gameObject.SetActive(false);
    }
}
