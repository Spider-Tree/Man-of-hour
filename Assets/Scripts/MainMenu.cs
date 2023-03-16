using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour {
  
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void PlayGame ()
    {

        scenesToLoad.Add(SceneManager.LoadSceneAsync(1));
        scenesToLoad.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));

    }

     public void BackMenu ()
    {
        SceneManager.LoadScene(0);
    }


    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }
}
