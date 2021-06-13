using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    #region Time variables
    [SerializeField] private float startTime;
    private float taskTime;
    [SerializeField] private float timeToNextGoal;
    #endregion

    [SerializeField] private GameObject taskImage;
    [SerializeField] private Image progressBar;

    public GameObject goalGameObject = null;

    private States dogStates;

    private bool taskInProgress;

    private void Awake()
    {
        var dog = GameObject.Find("Dog");
        dogStates = dog.GetComponent<States>();
    }

    private void Start()
    {
        taskTime = startTime;
        
        taskImage.SetActive(false);

        StartCoroutine(TimerToNewGoal(10));
    }



    // Update is called once per frame
    void Update()
    {
       if (taskInProgress)
        {
            taskTime -= Time.deltaTime;

            if (taskTime <= 0)
            {
                TaskFailed();
            }
        }
    }

    private void DefineGoal()
    {
        //Get all items in scene
        GameObject[] allItens = GameObject.FindGameObjectsWithTag("Item");
        //Sort some random number 
        int r = Random.Range(0, allItens.Length);
        //Define next item as goal
        goalGameObject = allItens[r];
        // Activate pop up
        taskImage.SetActive(true);
        // Start task
        taskInProgress = true;
        //Reset time
        taskTime = startTime;
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
        dogStates.IncreaseState();
        // Disable pop up
        taskImage.SetActive(false);
        //
        StartCoroutine(TimerToNewGoal(timeToNextGoal));
    }

    public void TaskFailed()
    {
        Debug.Log("Test Failed");
        taskInProgress = false;
        // Decrease dog's satisfaction
        dogStates.DecreaseState();
        // Disable pop up
        taskImage.SetActive(false);
        //Define new Goal
        StartCoroutine(TimerToNewGoal(timeToNextGoal));
    }
}
