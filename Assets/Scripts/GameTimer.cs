using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeValue = 120;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        DisplayTime(timeValue);
    }
    void DisplayTime(float timerDisplay)
    {
        if(timerDisplay < 0)
        {
            timerDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timerDisplay / 60);
        float seconds = Mathf.FloorToInt(timerDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
