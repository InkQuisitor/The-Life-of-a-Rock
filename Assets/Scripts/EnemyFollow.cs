using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public Transform Player;
    int MoveSpeed = 8;
    //int MaxDist = 20;
    int MinDist = 0;
    private Rigidbody enemyRb;
    int rotateSpeed = 2;
    private float gravityModifier = 1.5f;
    public bool gameOver = false;
    public TextMeshProUGUI gameOverText;
    [SerializeField] private float remainingTime = 60.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    private bool timerIsRunning = false;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        enemyRb = GetComponent<Rigidbody>();
        gameOverText.gameObject.SetActive(false);
        timerIsRunning = true;
        timerText.gameObject.SetActive(true);
        winText.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.LookAt(Player);

       if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {

             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
             //Vector3 movement = new Vector3();
             //enemyRb.AddForce(movement * rotateSpeed);
         }
        if (timerIsRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                DisplayTime(remainingTime);
            }

            if (remainingTime < 0)
            {
                Debug.Log("You Win!");
                winText.gameObject.SetActive(true);
                remainingTime = 0;
                timerIsRunning = false;
                Destroy(gameObject);
            }

        }
    }
    private void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true);
            timerIsRunning = false;
            Destroy(other.gameObject);

        }
    }
    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
