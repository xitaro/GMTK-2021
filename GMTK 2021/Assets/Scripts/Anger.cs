using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Anger : MonoBehaviour
{
    private GameManager gm;

    private int level;

    [SerializeField] private Image angerImage;

    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        level = 0;
        angerImage.gameObject.SetActive(false);
    }

    public void IncreaseAnger()
    {
        level += 1;
        CheckAnger();
        ShowIncreasingAnger();
        StartCoroutine(HideUI());
    }

    private void CheckAnger()
    {
        if (level >= 4)
        {
            gm.GameOver();
        }
    }
    private void ShowIncreasingAnger()
    {
        angerImage.gameObject.SetActive(true);
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(1.5f);
        angerImage.gameObject.SetActive(false);
    }

}
