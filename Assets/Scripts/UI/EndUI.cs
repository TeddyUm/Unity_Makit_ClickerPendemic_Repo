using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MainScreen()
    {
        Debug.Log("test");
        GameManager.Instance.SceneChange("MainScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
