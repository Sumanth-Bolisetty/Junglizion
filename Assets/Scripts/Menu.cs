using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Menu : MonoBehaviour
{
    private void Start()
    {
    
    }
    public void PlayGame()
    {
        SoundsManager.PlaySound("buttonClick");
        SceneManager.LoadScene(1);
        
        
    }
    public void QuitGame()
    {
        SoundsManager.PlaySound("buttonClick");
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void PlayClickSound()
    {
        SoundsManager.PlaySound("buttonClick");
    }
}
