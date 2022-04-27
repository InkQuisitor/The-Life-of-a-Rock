using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    [SerializeField] private float remainingTime = 60.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    private bool timerIsRunning = false;
    public TextMeshProUGUI gameOverText;
    public bool gameOver = false;


    void Start()
    {
        timerIsRunning = true;
        timerText.gameObject.SetActive(true);
        winText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (remainingTime > 0) {
                remainingTime -= Time.deltaTime;
                DisplayTime(remainingTime); }

            if (remainingTime < 0)
            {
                Debug.Log("You Win!");
                winText.gameObject.SetActive(true);
                remainingTime = 0;
                timerIsRunning = false;
            }

        }

        if (gameOver == true)
        {
            timerIsRunning = false;
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
