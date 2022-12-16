using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTimer : MonoBehaviour
{

    private GameObject _gameUI;
    private GameObject _gameOverUI;

    //variables for score
    private Text scoreUI;
    private string scoreText = "Punktestand: ";
    private int currentScore = 0;
    public int addScore = 1;
    public int winScore = 5;

    // variables for timer
    private Text timerUI;
    public string timerText = "Countdown: ";
    public float countRemaining = 10f;
    private bool countingDown = true;

    //variables for result UI
    private Text resultUI;
    public string resultLost = "You Lost!";
    public string resultWin = "You won!";

    //variables for GameOver
    public bool gameOver;
    private bool gameWon;
    private bool gameLost;


    // Start is called before the first frame update
    void Start()
    {
        _gameUI = GameObject.Find("Game");
        _gameOverUI = GameObject.Find("GameOver");

        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentScore += addScore;
            scoreUI.text = scoreText + currentScore;
        }
    }

    private void CountdownTimer()
    {
        if(countingDown)
        {
            if(countRemaining > 0)
            {
                countRemaining -= Time.deltaTime;
                timerUI.text = timerText + Mathf.Round(countRemaining).ToString();
            }
            else 
            {
                countRemaining = 0;
                timerUI.text = timerText + countRemaining;
                countingDown = false;

                CheckGameOver();
            }
        }
    }

    private void CheckGameOver()
    {
        //GameOver WIN
        if(currentScore >= winScore){
            gameWon = true;
            resultUI.text = resultWin;
            resultUI.color = Color.green;
        }
        //GameOver LOST
        else if (currentScore < winScore && !countingDown)
        {
            gameWon = false;

            resultUI.text = resultLost;
            resultUI.color = Color.red;
            
        }

        if(gameOver)
        {
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }

        
    }
}
