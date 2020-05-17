using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop_Player : MonoBehaviour
{
    [Header("Player Shop Information")]
    public Text[] shop_Player_level;
    public Text[] shop_Player_Des;
    private static int[] shop_Player_amount = { 1, 1, 1, 1 };
    public Text[] Player_money_text;

    // Basic price
    private static int shop_Player_1_price = 500;
    private static int shop_Player_2_price = 650;
    private static int shop_Player_3_price = 700;
    private static int shop_Player_4_price = 850;

    [Header("Sounds")]
    private string Btn_buy_sound = "buy_item";
    private string error_sound = "error";

    void Start()
    {

        shop_Player_Des[0].text = "Public anger";
        shop_Player_Des[1].text = "Breaking News";
        shop_Player_Des[2].text = "Emergency Fund";
        shop_Player_Des[3].text = "Medical Supply";
    }

    private void Update()
    {
        shop_Player_level[0].text = "Lv. " + shop_Player_amount[0];
        Player_money_text[0].text = string.Format("{0:n0}", shop_Player_1_price);

        shop_Player_level[1].text = "Lv. " + shop_Player_amount[1];
        Player_money_text[1].text = string.Format("{0:n0}", shop_Player_2_price);

        shop_Player_level[2].text = "Lv. " + shop_Player_amount[2];
        Player_money_text[2].text = string.Format("{0:n0}", shop_Player_3_price);

        shop_Player_level[3].text = "Lv. " + shop_Player_amount[3];
        Player_money_text[3].text = string.Format("{0:n0}", shop_Player_4_price);
    }

    public void shop_Player_1()
    {
        if (GameManager.Instance.money >= shop_Player_1_price)
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= shop_Player_1_price;
            shop_Player_amount[0] += 1;

            // Fix later
            shop_Player_1_price += 300;
            GameManager.Instance.playerDamage += 5;
        }
        else
        {
            Get_eroor_sound();
        }
    }

    public void shop_Player_2()
    {
        if (GameManager.Instance.money >= shop_Player_2_price)
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= shop_Player_2_price;
            shop_Player_amount[1] += 1;

            // Fix later
            shop_Player_2_price += 400;
            GameManager.Instance.SkillControl += 1;
        }
        else
        {
            Get_eroor_sound();
        }
    }

    public void shop_Player_3()
    {
        if (GameManager.Instance.money >= shop_Player_4_price)
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= shop_Player_4_price;
            shop_Player_amount[2] += 1;

            // Fix later
            shop_Player_3_price += 500;
            GameManager.Instance.moneySkill += 300;
        }
        else
        {
            Get_eroor_sound();
        }
    }

    public void shop_Player_4()
    {
        if (GameManager.Instance.money >= shop_Player_3_price)
        {
            Get_Btn_buy_sound();
            GameManager.Instance.money -= shop_Player_3_price;
            shop_Player_amount[3] += 1;

            // Fix later
            shop_Player_4_price += 600;
            GameManager.Instance.healSkill += (GameManager.Instance.population / 10);
        }
        else
        {
            Get_eroor_sound();
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
