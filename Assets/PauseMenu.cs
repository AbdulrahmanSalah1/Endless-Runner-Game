using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
       
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        GM.coinTotal = 0;
        GM.timeTotal = 0;
        GM.gameover = false;
        SceneManager.LoadScene("levelComp");
        Time.timeScale = 1;

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        GM.coinTotal = 0;
        GM.timeTotal = 0;
        GM.gameover = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
      
    }
}
