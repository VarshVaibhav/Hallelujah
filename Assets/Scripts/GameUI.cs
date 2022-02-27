using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject quote;
    public Animator playerAnim;


    public GameObject pausePanel;
    public GameObject pauseButton;
    public Animator pauseAnim;
    public void PauseOn()
    {
        Debug.Log("clicked");
        pauseButton.SetActive(false);
        pauseAnim.SetBool("isPaused", true);
        Time.timeScale = 0;
    }
    public void PauseOff()
    {
        pauseButton.SetActive(true);
        pauseAnim.SetBool("isPaused", false);
        Time.timeScale = 1;
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
