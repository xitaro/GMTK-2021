using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedsManager : MonoBehaviour
{
    #region Time variables
    [SerializeField] private float startTime;
    private float taskTime;
    [SerializeField] private float timeToNextGoal;
    #endregion

    [SerializeField] private Image taskImage;
    [SerializeField] private Image progressBar;

    private GameObject[] allItens;

    public GameObject goalGameObject = null;
    public string need;

    private Satisfaction dogSatisfaction;

    private bool taskInProgress;

    private void Awake()
    {
        var dog = GameObject.Find("Dog");
        dogSatisfaction = dog.GetComponent<Satisfaction>();
    }

    private void Start()
    {
        taskTime = startTime;
        
        taskImage.gameObject.SetActive(false);

        StartCoroutine(TimerToNewGoal(8));
    }



    // Update is called once per frame
    void Update()
    {
       if (taskInProgress)
        {
            //Reduce fill amount over 30 seconds
            progressBar.fillAmount -= 1.0f / taskTime * Time.deltaTime;

            if (progressBar.fillAmount <= 0)
            {
                TaskFailed();
            }
        }
    }

    private void DefineGoal()
    {
        //Get all items in scene
        //CRIAR UM OVERLAP BOX E VERIFICAR SE TEM ITENS DENTRO DELE
        //INVÉS DE ATIVO NA CENA
        allItens = GameObject.FindGameObjectsWithTag("Item");
        if (allItens.Length > 0)
        {
            //Sort some random number 
            int r = Random.Range(0, allItens.Length);

            //Define next item as goal
            goalGameObject = allItens[r];
            Interactable obj = allItens[r].GetComponent<Interactable>();
            need = obj.animation;
            taskImage.sprite = obj.sprite;

            // Activate pop up
            taskImage.gameObject.SetActive(true);
            // Start task
            taskInProgress = true;
            //Reset time
            taskTime = startTime;
        }
        else
        {
            DefineGoal();
        }

        allItens = null;
    }

    private IEnumerator TimerToNewGoal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DefineGoal();
    }

    public void TaskCompleted()
    {
        Debug.Log("Task Completed");
        taskInProgress = false;
        // Increase dog's satisfaction
        dogSatisfaction.IncreaseSatisfaction();
        // Disable pop up
        taskImage.gameObject.SetActive(false);
        //
        StartCoroutine(TimerToNewGoal(timeToNextGoal));
    }

    public void TaskFailed()
    {
        Debug.Log("Test Failed");
        taskInProgress = false;
        // Decrease dog's satisfaction
        dogSatisfaction.DecreaseSatisfaction();
        // Disable pop up
        taskImage.gameObject.SetActive(false);
        //Define new Goal
        StartCoroutine(TimerToNewGoal(timeToNextGoal));
    }
}
