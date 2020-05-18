using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Pause Information")]
    public GameObject pauseMenuUI;
    public GameObject OptionMenuUI;
    private bool OptionMenu_Actived = false;

    [Header("Sounds")]
    private string Btn_click_sound = "Button";

    public GameObject Slider_BGM;
    public GameObject Slider_Sound;

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

    private void Start()
    {
        Slider_BGM.GetComponent<Slider>().value = BGMManager.instance.BGM_Volume;
        Slider_Sound.GetComponent<Slider>().value = AudioManager.Instance.Stage_Sound_Volume;
    }

    public void SetBGMVolum(float _volumn)
    {
        BGMManager.instance.BGM_Volume = _volumn;
    }

    public void SetSoundVolum(float _volumn)
    {
        AudioManager.Instance.SetVolum(_volumn);
    }

    public void Get_Btn_click_sound()
    {
        AudioManager.Instance.Play(Btn_click_sound);
    }
}
