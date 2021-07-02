using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ground ground;

    [SerializeField] private Text distanceText;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private float endGameDistance;
    [SerializeField] private float currentGameDistance;

    private void Start()
    {
        currentGameDistance = 0;
        gameOverPanel.SetActive(false);
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
            Debug.Log("Ganhou");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Perder = Restart");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
