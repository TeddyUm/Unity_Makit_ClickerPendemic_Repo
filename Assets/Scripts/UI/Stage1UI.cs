using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1UI : MonoBehaviour
{
    // Time UI TEXT
    public Text populNum;
    public Text enemyName;
    public Enemy enemy;
    public Image populGuage;
    public Image enemyHPGuage;
    public Image fadeInScreen;
    private float currentPopul;
    private float currentEnemyHP;
    private float fadeTime;
    private bool bFadeIn;

    [Header("Sounds")]
    public int StageNumber;
    public string Btn_click_sound;

    [Header("Shop Panels")]
    public GameObject PlayerShop_panel;
    public GameObject FollowerShop_panel;
    private bool PlayerShop_panel_Actived = false;
    private bool FollowerShop_panel_Actived = false;

    // Start is called before the first frame update
    void Start()
    {
        BGMManager.instance.Play(StageNumber + 1);

        GameManager.Instance.maxPopul = GameManager.Instance.population;
        currentPopul = 1.0f;
        currentEnemyHP = 1.0f;
        fadeTime = 0.0f;
        bFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Money Text
        Text money_text = GameObject.FindGameObjectWithTag("Money").GetComponentInChildren<Text>();
        if (GameManager.Instance.money <= 0)
        {
            GameManager.Instance.money = 0;
        }
        money_text.text = string.Format("{0:n0}", GameManager.Instance.money);

        // Time print UI evey tick
        if (GameManager.Instance.maxPopul >= GameManager.Instance.population)
        {
            populNum.text = "" + GameManager.Instance.population + "M";
        }
        else
        {
            populNum.text = "" + GameManager.Instance.maxPopul + "M";
        }

        // popul guage
        currentPopul = GameManager.Instance.population / (float)GameManager.Instance.maxPopul;
        populGuage.fillAmount = Mathf.Lerp(populGuage.fillAmount, currentPopul, Time.deltaTime * 3);

        // enemy guage
        currentEnemyHP = enemy.getEnemyHP() / (float)GameManager.Instance.maxEnemyHP;
        enemyHPGuage.fillAmount = Mathf.Lerp(enemyHPGuage.fillAmount, currentEnemyHP, Time.deltaTime * 3);

        // enemy name
        enemyName.text = enemy.getEnemyName();

        if (bFadeIn == true)
        {
            FadeInFunction();
        }
    }

    void FadeInFunction()
    {
        fadeTime += Time.deltaTime;
        if (fadeTime < 1.0f)
        {
            fadeInScreen.color = new Color(fadeInScreen.color.r, fadeInScreen.color.g, fadeInScreen.color.b, 1.0f - fadeTime);
        }
        else
        {
            bFadeIn = false;
            fadeInScreen.enabled = false;
        }
    }

    public void initFadeIn()
    {
        fadeTime = 0.0f;
        bFadeIn = true;
        fadeInScreen.enabled = true;
    }

    public void PlayerShop_Panel()
    {
        Get_Btn_click_sound();

        // If FollowerShop panel is opened
        if (FollowerShop_panel_Actived)
        {
            FollowerShop_panel_Actived = !FollowerShop_panel_Actived;
            FollowerShop_panel.SetActive(FollowerShop_panel_Actived);
        }
        
        PlayerShop_panel_Actived = !PlayerShop_panel_Actived;
        PlayerShop_panel.SetActive(PlayerShop_panel_Actived);
    }

    public void FollowerShop_Panel()
    {
        Get_Btn_click_sound();

        // If PlayerShop panel is opened
        if (PlayerShop_panel_Actived)
        {
            PlayerShop_panel_Actived = !PlayerShop_panel_Actived;
            PlayerShop_panel.SetActive(PlayerShop_panel_Actived);
        }
        
        FollowerShop_panel_Actived = !FollowerShop_panel_Actived;
        FollowerShop_panel.SetActive(FollowerShop_panel_Actived);
    }

    public void Get_Btn_click_sound()
    {
        AudioManager.Instance.Play(Btn_click_sound);
    }
}
