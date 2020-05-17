using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("MainScreen Information")]
    public GameObject Option_Panel;
    private bool Option_Panel_Actived = false;
    public GameObject Credit_Panel;
    private bool Credit_Panel_Actived = false;

    [Header("Sounds")]
    public string Btn_click_sound;

    void Start()
    {
        BGMManager.instance.Play(0);
    }

    public void PlayGame()
    {
        Get_Btn_click_sound();
        BGMManager.instance.Stop();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Loading");
    }

    public void Btn_Option()
    {
        Get_Btn_click_sound();
        Option_Panel_Actived = !Option_Panel_Actived;
        Option_Panel.SetActive(Option_Panel_Actived);
    }

    public void Btn_Credits()
    {
        Get_Btn_click_sound();
        Credit_Panel_Actived = !Credit_Panel_Actived;
        Credit_Panel.SetActive(Credit_Panel_Actived);
    }

    public void QuitGame()
    {
        Get_Btn_click_sound();
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Get_Btn_click_sound()
    {
        AudioManager.Instance.Play(Btn_click_sound);
    }
}
