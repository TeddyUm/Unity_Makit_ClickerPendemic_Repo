using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    public Text shop_Player_level;
    public Text shop_Player_Des;
    private static int shop_Player_amount = 1;
    public Text Player_money_text;
    private static int shop_Player_price = 10;

    public Text shop_Player_skill_1_level;
    public Text shop__Player_skill_1_Des;
    private static int shop__Player_skill_1_amount = 1;
    public Text skill_1_money_text;
    private static int shop__Player_skill_1_price = 20;

    public Text shop_Player_skill_2_level;
    public Text shop__Player_skill_2_Des;
    private static int shop__Player_skill_2_amount = 1;
    public Text skill_2_money_text;
    private static int shop__Player_skill_2_price = 30;

    public Text shop_Player_skill_3_level;
    public Text shop__Player_skill_3_Des;
    private static int shop__Player_skill_3_amount = 1;
    public Text skill_3_money_text;
    private static int shop__Player_skill_3_price = 40;

    private void Update()
    {
        shop_Player_level.text = "Lv. " + shop_Player_amount;
        shop_Player_Des.text = "Power up";
        Player_money_text.text = string.Format("{0:n0}", shop_Player_price);

        shop_Player_skill_1_level.text = "Lv. " + shop__Player_skill_1_amount;
        shop__Player_skill_1_Des.text = "Double attack";
        skill_1_money_text.text = string.Format("{0:n0}", shop__Player_skill_1_price);

        shop_Player_skill_2_level.text = "Lv. " + shop__Player_skill_2_amount;
        shop__Player_skill_2_Des.text = "More population";
        skill_2_money_text.text = string.Format("{0:n0}", shop__Player_skill_2_price);

        shop_Player_skill_3_level.text = "Lv. " + shop__Player_skill_3_amount;
        shop__Player_skill_3_Des.text = "Money Booster";
        skill_3_money_text.text = string.Format("{0:n0}", shop__Player_skill_3_price);
    }

    public void shop_player()
    {
        if(GameManager.Instance.money >= shop_Player_price)
        {
            GameManager.Instance.money -= shop_Player_price;
            shop_Player_amount += 1;

            // Fix later
            shop_Player_price += 20;
            GameManager.Instance.playerDamage += 10;
        }
    }

    public void shop_player_skill_1()
    {
        if (GameManager.Instance.money >= shop__Player_skill_1_price)
        {
            GameManager.Instance.money -= shop__Player_skill_1_price;
            shop__Player_skill_1_amount += 1;
            // Fix later
            shop__Player_skill_1_price += 30;
            GameManager.Instance.damageSkill += 100;
        }
    }

    public void shop_player_skill_2()
    {
        if (GameManager.Instance.money >= shop__Player_skill_2_price)
        {
            GameManager.Instance.money -= shop__Player_skill_2_price;
            shop__Player_skill_2_amount += 1;
            // Fix later
            shop__Player_skill_2_price += 40;
            GameManager.Instance.healSkill += 100;
        }
    }

    public void shop_player_skill_3()
    {
        if (GameManager.Instance.money >= shop__Player_skill_3_price)
        {
            GameManager.Instance.money -= shop__Player_skill_3_price;
            shop__Player_skill_3_amount += 1;
            // Fix later
            shop__Player_skill_3_price += 40;
            GameManager.Instance.moneySkill += 100;
        }
    }
}
