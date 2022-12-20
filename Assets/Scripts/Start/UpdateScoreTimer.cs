using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTimer : MonoBehaviour
{
    // variable for GameUIs
    private GameObject _gameUI;
    private GameObject _gameOverUI;

    // variables for score
    private Text scoreUI;
    public string scoreText = "Punktestand: ";
    private int currentScore = 0;
    public int addScore = 1;
    public int winScore = 5;

    //gameOver Variables for Score
    private Text scoreGameOverUI;

    // variables for timer
    private Text timerUI;
    public string timerText = "Countdown: ";
    public float countRemaining = 30f;
    private bool countingDown = true;

    // variables for result ui
    private Text resultUI;
    public string resultLost = "You lost!";
    public string resultWin = "You won!";

    // variables for game over
    public bool gameOver = false;
    private bool gameWon;
    private bool gameLost;


    void Start()
    {
        _gameUI = GameObject.Find("Game");
        _gameOverUI = GameObject.Find("GameOver");

        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        resultUI = GameObject.Find("Result").GetComponent<Text>();

        scoreGameOverUI = GameObject.Find("ScoreGameOver").GetComponent<Text>();

        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }

    void Update()
    {
        CountdownTimer();

        if (gameOver && Input.GetKeyDown("r"))
        {
            restartValues();
            gameOver = false;
        }

        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     currentScore += addScore;
        //     scoreUI.text = scoreText + currentScore.ToString();            
        // }
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
                timerUI.text = timerText + countRemaining.ToString();
                countingDown = false;

                CheckGameOver();
            }
        }
    }



    private void CheckGameOver()
    {
        // GameOver WIN
        if(currentScore >= winScore)
        {
            gameWon = true;
            gameOver = true;

            resultUI.text = resultWin;
            resultUI.color = Color.green;
        }
        // GameOver LOST
        else if(currentScore < winScore && !countingDown)
        {
            gameLost = true;
            gameOver = true;

            resultUI.text = resultLost;
            resultUI.color = Color.red;
        }

        scoreGameOverUI.text = scoreText + currentScore.ToString();

        // Change the UI to display the GameOver screen
        if(gameOver)
        {
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }

    }

    public void addOne()
    {
        currentScore += addScore;
        scoreUI.text = scoreText + currentScore.ToString();
    }

    private void restartValues()
    {
        currentScore = 0;
        countRemaining = 30f;
        countingDown = true;

        gameLost = false;
        gameWon = false;

        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);

        scoreUI.text = scoreText + currentScore.ToString();
    }


}