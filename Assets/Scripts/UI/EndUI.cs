using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndUI : MonoBehaviour
{
    [Header("Sounds")]
    private string Btn_click_sound = "Button";


    public GameObject quit_Panel;

    void Start()
    {
        BGMManager.instance.Play(6);
    }

    public void MainScreen()
    {
        // init data
        GameManager.Instance.population = 450;      
        GameManager.Instance.money = 0;             
        GameManager.Instance.playerDamage = 5;      
        GameManager.Instance.follower1Damage = 10;  
        GameManager.Instance.follower2Damage = 20;  
        GameManager.Instance.follower3Damage = 50;  
        GameManager.Instance.follower4Damage = 100; 
        GameManager.Instance.currentScene = 0;      

        GameManager.Instance.SkillControl = 2;
        GameManager.Instance.damageSkill = 50;      
        GameManager.Instance.moneySkill = 1000;     

        GameManager.Instance.maxPopul = 1000;
        GameManager.Instance.maxEnemyHP = 1000;

        // Shops
        for(int i = 0; i< GameManager.Instance.shop_Player_amount.Length; i++)
        {
            GameManager.Instance.shop_Player_amount[i] = 1;
        }

        for (int i = 0; i < GameManager.Instance.shop_Follower_amount.Length; i++)
        {
            GameManager.Instance.shop_Follower_amount[i] = 1;
        }

        for (int i = 0; i < GameManager.Instance.shop_Player_price.Length; i++)
        {
            switch (i)
            {
                case 0:
                    GameManager.Instance.shop_Player_price[0] = 500;
                    break;

                case 1:
                    GameManager.Instance.shop_Player_price[1] = 650;
                    break;

                case 2:
                    GameManager.Instance.shop_Player_price[2] = 700;
                    break;

                case 3:
                    GameManager.Instance.shop_Player_price[3] = 850;
                    break;
            }
            
        }

        for (int i = 0; i < GameManager.Instance.shop_Follower_price.Length; i++)
        {
            switch (i)
            {
                case 0:
                    GameManager.Instance.shop_Follower_price[0] = 1000;
                    break;

                case 1:
                    GameManager.Instance.shop_Follower_price[1] = 2500;
                    break;

                case 2:
                    GameManager.Instance.shop_Follower_price[2] = 4000;
                    break;

                case 3:
                    GameManager.Instance.shop_Follower_price[3] = 6500;
                    break;
            }

        }

        Get_Btn_click_sound();
        GameManager.Instance.SceneChange("MainScreen");
    }

    public void QuitGame()
    {
        Get_Btn_click_sound();
        quit_Panel.SetActive(true);
    }
    public void QuitConfirmGame()
    {
        Get_Btn_click_sound();
        BGMManager.instance.Stop();
        Application.Quit();
    }
    public void QuitCancelGame()
    {
        quit_Panel.SetActive(false);
    }
    public void Get_Btn_click_sound()
    {
        AudioManager.Instance.Play(Btn_click_sound);
    }
}
