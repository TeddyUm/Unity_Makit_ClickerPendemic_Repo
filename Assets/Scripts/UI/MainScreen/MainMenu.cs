using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("MainScreen Information")]
    public GameObject Option_Panel;
    private bool Option_Panel_Actived = false;
    public GameObject Credit_Panel;
    private bool Credit_Panel_Actived = false;

    [Header("Sounds")]
    public string Btn_click_sound;

    public GameObject Slider_BGM;
    public GameObject Slider_Sound;
    public GameObject quit_Panel;

    void Start()
    {
        Slider_BGM.GetComponent<Slider>().value = BGMManager.instance.BGM_Volume;
        Slider_Sound.GetComponent<Slider>().value = AudioManager.Instance.Stage_Sound_Volume;

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
        quit_Panel.SetActive(true);
    }

    public void QuitConfirmGame()
    {
        Get_Btn_click_sound();
        Application.Quit();
    }
    public void QuitCancelGame()
    {
        quit_Panel.SetActive(false);
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
