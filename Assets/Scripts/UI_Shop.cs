﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    public Text shop_Player_level;
    public Text shop_Player_Des;
    public int shop_Player_amount;
    public Text Player_money_text;
    public int shop_Player_price;

    public Text shop_Player_skill_1_level;
    public Text shop__Player_skill_1_Des;
    public int shop__Player_skill_1_amount;
    public Text skill_1_money_text;
    public int shop__Player_skill_1_price;

    public Text shop_Player_skill_2_level;
    public Text shop__Player_skill_2_Des;
    public int shop__Player_skill_2_amount;
    public Text skill_2_money_text;
    public int shop__Player_skill_2_price;

    public Text shop_Player_skill_3_level;
    public Text shop__Player_skill_3_Des;
    public int shop__Player_skill_3_amount;
    public Text skill_3_money_text;
    public int shop__Player_skill_3_price;

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
            // 각 스킬마다 올라가는 수 논의 필요.
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
            // skill 1 능력치 올리기
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
            // skill 2 능력치 올리기
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
            // skill 3 능력치 올리기
        }
    }
}
