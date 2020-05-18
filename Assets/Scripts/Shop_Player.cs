using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Shop_Player : MonoBehaviour
{
    [Header("Player Shop Information")]
    public Text[] shop_Player_level;
    public Text[] shop_Player_Des;
    public Text[] Player_money_text;
    private static int[] shop_Player_lv_max = { 50, 30, 25, 30 };

    // Btn
    public GameObject[] shop_Player_Max;
    public GameObject[] shop_Player_buy_btn;

    [Header("Sounds")]
    private string Btn_buy_sound = "buy_item";
    private string error_sound = "error";

    void Start()
    {
        shop_Player_Des[0].text = "Player Tab Damage";
        shop_Player_Des[1].text = "Clinical Strike";
        shop_Player_Des[2].text = "Support Fund";
        shop_Player_Des[3].text = "Support Timer";
    }

    private void Update()
    {
        // Text 
        for (int i = 0; i < shop_Player_level.Length; i++)
        {
            shop_Player_level[i].text = "Lv. " + GameManager.Instance.shop_Player_amount[i];
            Player_money_text[i].text = string.Format("{0:n0}", GameManager.Instance.shop_Player_price[i]);
        }

        // Max lv Btn
        for(int i = 0; i < shop_Player_lv_max.Length; i++)
        {
            if (GameManager.Instance.shop_Player_amount[i] >= shop_Player_lv_max[i])
            {
                shop_Player_buy_btn[i].SetActive(false);
                shop_Player_Max[i].SetActive(true);
            }
        }

        // Price Btn Deactivation
        for (int i = 0; i < GameManager.Instance.shop_Player_price.Length; i++)
        {
            if (GameManager.Instance.money < GameManager.Instance.shop_Player_price[i])
            {
                shop_Player_buy_btn[i].GetComponent<Button>().interactable = false;
                shop_Player_buy_btn[i].GetComponent<Image>().color = new Color(255, 255, 255, 200);
            }
            else
            {
                shop_Player_buy_btn[i].GetComponent<Button>().interactable = true;
                shop_Player_buy_btn[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }

    public void shop_Player_1()
    {
        // Price
        if (GameManager.Instance.money >= GameManager.Instance.shop_Player_price[0])
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= GameManager.Instance.shop_Player_price[0];
            GameManager.Instance.shop_Player_amount[0] += 1;

            // Fix later
            GameManager.Instance.shop_Player_price[0] += 550;
            GameManager.Instance.playerDamage += 5;
        }
    }

    public void shop_Player_2()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Player_price[1])
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= GameManager.Instance.shop_Player_price[1];
            GameManager.Instance.shop_Player_amount[1] += 1;

            // Fix later
            GameManager.Instance.shop_Player_price[1] += 400;
            GameManager.Instance.SkillControl += 1;
        }
    }

    public void shop_Player_3()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Player_price[2])
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= GameManager.Instance.shop_Player_price[2];
            GameManager.Instance.shop_Player_amount[2] += 1;

            // Fix later
            GameManager.Instance.shop_Player_price[2] += 500;
            GameManager.Instance.moneySkill += 300;
        }
    }

    public void shop_Player_4()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Player_price[3])
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= GameManager.Instance.shop_Player_price[3];
            GameManager.Instance.shop_Player_amount[3] += 1;

            // Fix later
            GameManager.Instance.shop_Player_price[3] += 600;
            GameManager.Instance.healSkill += (GameManager.Instance.population / 10);
        }
    }

    public void Get_Btn_buy_sound()
    {
        AudioManager.Instance.Play(Btn_buy_sound);
    }

    public void Get_eroor_sound()
    {
        AudioManager.Instance.Play(error_sound);
    }
}
