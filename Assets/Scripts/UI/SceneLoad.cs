using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Asynchronous loads can do other tasks without stopping when calling up Secene.
// If the scene is called up to LoadSecene(), no other work is performed until it is completed.

/*
    operation.isDone;       // Return whether completed or not to Boolean type.
    operation.progress;     // Returns the float type 0, 1 (0 - ongoing, 1 - Progress complete)
    operation.allowSceneActivation; // If it is true, switch the screen as soon as loading is complete.
                                    // If it false, the progress stops at 0.9f.
*/

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public static string loadScene;
    public static int loadType;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadSceneHandle (string _name, int _loadType)
    {
        loadScene = _name;
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Stage1");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadtext.text = "Touch the screen!!";
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }        
    }
}
