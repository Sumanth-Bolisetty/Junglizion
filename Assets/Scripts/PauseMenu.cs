using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public Slider slider;
    public TextMeshProUGUI scoreText;
   
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    private void Start()
    {
        pauseButton.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
    void Update()
    {
       
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
        pauseButton.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void QuittingGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
     public void PauseGame()
    {
        pauseButton.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        slider.gameObject.SetActive(false);
        
    }
}
