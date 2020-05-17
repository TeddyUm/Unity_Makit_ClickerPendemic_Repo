using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Pause Information")]
    public GameObject pauseMenuUI;
    public GameObject OptionMenuUI;
    private bool OptionMenu_Actived = false;

    [Header("Sounds")]
    public string Btn_click_sound;

    public void Resume()
    {
        Get_Btn_click_sound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        Get_Btn_click_sound();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OptionMenu()
    {
        Get_Btn_click_sound();
        OptionMenu_Actived = !OptionMenu_Actived;
        OptionMenuUI.SetActive(OptionMenu_Actived);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void Get_Btn_click_sound()
    {
        AudioManager.Instance.Play(Btn_click_sound);
    }
}
