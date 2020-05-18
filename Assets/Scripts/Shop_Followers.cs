using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Followers : MonoBehaviour
{
    [Header("Follower Shop Information")]
    public Text[] shop_Follower_level;
    public Text[] shop_Follower_Des;
    public Text[] Follower_money_text;
    private static int[] shop_Follower_lv_max = { 50, 45, 40, 30 };

    // Btn
    public GameObject[] shop_Follower_Max;
    public GameObject[] shop_Follower_buy_btn;

    [Header("Sounds")]
    private string Btn_buy_sound = "buy_item";
    private string error_sound = "error";

    void Start()
    {
        shop_Follower_Des[0].text = "black Death doctor";
        shop_Follower_Des[1].text = "Flue doctor";
        shop_Follower_Des[2].text = "Operating doctor";
        shop_Follower_Des[3].text = "Veiled doctor";
    }

    private void Update()
    {
        for (int i = 0; i < shop_Follower_level.Length; i++)
        {
            shop_Follower_level[i].text = "Lv. " + GameManager.Instance.shop_Follower_amount[i];
            Follower_money_text[i].text = string.Format("{0:n0}", GameManager.Instance.shop_Follower_price[i]);
        }

        // Max lv Btn
        for (int i = 0; i < shop_Follower_buy_btn.Length; i++)
        {
            if (GameManager.Instance.shop_Follower_amount[i] >= shop_Follower_lv_max[i])
            {
                shop_Follower_buy_btn[i].SetActive(false);
                shop_Follower_Max[i].SetActive(true);
            }
        }

        // Price Btn Deactivation
        for (int i = 0; i < GameManager.Instance.shop_Follower_price.Length; i++)
        {
            if (GameManager.Instance.money < GameManager.Instance.shop_Follower_price[i])
            {
                shop_Follower_buy_btn[i].GetComponent<Button>().interactable = false;
                shop_Follower_buy_btn[i].GetComponent<Image>().color = new Color(255, 255, 255, 200);
            }
            else
            {
                shop_Follower_buy_btn[i].GetComponent<Button>().interactable = true;
                shop_Follower_buy_btn[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }

    public void shop_Follower_1()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Follower_price[0])
        {
            Get_Btn_buy_sound();

            GameManager.Instance.money -= GameManager.Instance.shop_Follower_price[0];
            GameManager.Instance.shop_Follower_amount[0] += 1;

            // Fix later
            GameManager.Instance.shop_Follower_price[0] += 200;
            GameManager.Instance.follower1Damage += 15;
        }
    }

    public void shop_Follower_2()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Follower_price[1])
        {
            Get_Btn_buy_sound();

            GameManager.Instance.money -= GameManager.Instance.shop_Follower_price[1];
            GameManager.Instance.shop_Follower_amount[1] += 1;

            // Fix later
            GameManager.Instance.shop_Follower_price[1] += 350;
            GameManager.Instance.follower2Damage += 20;
        }
    }

    public void shop_Follower_3()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Follower_price[2])
        {
            Get_Btn_buy_sound();

            GameManager.Instance.money -= GameManager.Instance.shop_Follower_price[2];
            GameManager.Instance.shop_Follower_amount[2] += 1;

            // Fix later
            GameManager.Instance.shop_Follower_price[2] += 500;
            GameManager.Instance.follower3Damage += 25;
        }
    }

    public void shop_Follower_4()
    {
        if (GameManager.Instance.money >= GameManager.Instance.shop_Follower_price[3])
        {
            Get_Btn_buy_sound();

            GameManager.Instance.money -= GameManager.Instance.shop_Follower_price[3];
            GameManager.Instance.shop_Follower_amount[3] += 1;

            // Fix later
            GameManager.Instance.shop_Follower_price[3] += 700;
            GameManager.Instance.follower4Damage += 30;
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
