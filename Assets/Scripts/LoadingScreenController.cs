using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    AsyncOperation async;
   
    public void LoadScene()
    {

        SoundsManager.PlaySound("buttonClick");
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        while(async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 100;
                new WaitForSeconds(20);
                async.allowSceneActivation = true;
            }
            yield return null; 
        }
    }
}
