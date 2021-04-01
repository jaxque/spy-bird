using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour
{
    Timer gameTimer;
    System.DateTime timerStartTime;

    bool gameTimerElapsed;

    public int CurrentScore { get { return PlayerStats.PlayerScore; } }

    // Start is called before the first frame update
    void Start()
    {

        PlayerStats.PlayerScore = 0;
        //Debug.Log("Score:" + PlayerStats.PlayerScore);

        gameTimerElapsed = false;
        gameTimer = new Timer(5000);
        gameTimer.AutoReset = true;
        gameTimer.Enabled = true;
        gameTimer.Elapsed += GameTimer_Elapsed;

        Debug.Log("Timer started");
        gameTimer.Start();
        timerStartTime = System.DateTime.Now;
    }

    private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        gameTimerElapsed = true;
        Debug.Log("Timer completed");
        

    }

    // Update is called once per frame
    void Update()
    {
        Text timerText = GameObject.Find("TimerText").GetComponent<Text>();
        System.TimeSpan timeRemaining = System.DateTime.Now - timerStartTime;
        timerText.text = System.Math.Round((timeRemaining.TotalMilliseconds / 1000), 1).ToString()
            + " / " + System.Math.Round((gameTimer.Interval / 1000), 1).ToString() + " seconds";

        if(gameTimerElapsed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
