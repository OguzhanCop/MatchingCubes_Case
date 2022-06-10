using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject collector;
    public Button play;
    public Button quit;
    public Button restart;
    public Button restart2;
    public Button pause;
    public GameObject levelCompleted;
    public GameObject levelFailed;
    public void RestartButton()
    {        
        Time.timeScale = 1;        
        SceneManager.LoadScene(0);        
        
    }
    public void PauseButton()
    {
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        restart2.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Play()
    {
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        restart2.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }
    public void Finish()
    {
        Time.timeScale = 0;
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        levelCompleted.gameObject.SetActive(true);

    }
    public void PlayerDead()
    {
        Time.timeScale = 0;
        restart.gameObject.SetActive(true);
        levelFailed.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);


    }
}
