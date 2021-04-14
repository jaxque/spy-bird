using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    // Use this for initialization
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                Debug.Log(index);
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Space pressed");
            // New Game
            if(index == 0)
            {
                SceneManager.LoadScene("GameScene");
            }

            // How To Play
            if(index == 1)
            {
                SceneManager.LoadScene("HowToPlayScene");
            }

            // Quit Game
            if (index == 2)
            {
                Debug.Log("QUIT!");
                Application.Quit();
            }
        }
    }

}
