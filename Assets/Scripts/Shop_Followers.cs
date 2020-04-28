using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Followers : MonoBehaviour
{
    public Text[] shop_Follower_level;
    public Text[] shop_Follower_Des;
    private static int[] shop_Follower_amount = { 1, 1, 1, 1 };
    public Text[] Follower_money_text;

    // Basic price
    private static int shop_Follower_1_price = 1000;
    private static int shop_Follower_2_price = 2500;
    private static int shop_Follower_3_price = 4000;
    private static int shop_Follower_4_price = 6500;
    
    void Start()
    {
        shop_Follower_Des[0].text = "black Death doctor";
        shop_Follower_Des[1].text = "Flue doctor";
        shop_Follower_Des[2].text = "Operating doctor";
        shop_Follower_Des[3].text = "Veiled doctor";
    }

    private void Update()
    {
        shop_Follower_level[0].text = "Lv. " + shop_Follower_amount[0];
        Follower_money_text[0].text = string.Format("{0:n0}", shop_Follower_1_price);

        shop_Follower_level[1].text = "Lv. " + shop_Follower_amount[1];
        Follower_money_text[1].text = string.Format("{0:n0}", shop_Follower_2_price);

        shop_Follower_level[2].text = "Lv. " + shop_Follower_amount[2];
        Follower_money_text[2].text = string.Format("{0:n0}", shop_Follower_3_price);

        shop_Follower_level[3].text = "Lv. " + shop_Follower_amount[3];
        Follower_money_text[3].text = string.Format("{0:n0}", shop_Follower_4_price + 1);
    }

    public void shop_Follower_1()
    {
        if (GameManager.Instance.money >= shop_Follower_1_price)
        {
            GameManager.Instance.money -= shop_Follower_1_price;
            shop_Follower_amount[0] += 1;

            // Fix later
            shop_Follower_1_price += 200;
            GameManager.Instance.follower1Damage += 15;
        }
    }

    public void shop_Follower_2()
    {

        if (GameManager.Instance.money >= shop_Follower_2_price)
        {
            GameManager.Instance.money -= shop_Follower_2_price;
            shop_Follower_amount[1] += 1;

            // Fix later
            shop_Follower_2_price += 350;
            GameManager.Instance.follower2Damage += 20;
        }

    }

    public void shop_Follower_3()
    {
        if (GameManager.Instance.money >= shop_Follower_3_price)
        {
            GameManager.Instance.money -= shop_Follower_3_price;
            shop_Follower_amount[2] += 1;

            // Fix later
            shop_Follower_3_price += 500;
            GameManager.Instance.follower3Damage += 25;
        }
    }

    public void shop_Follower_4()
    {
        if (GameManager.Instance.money >= shop_Follower_4_price)
        {
            GameManager.Instance.money -= shop_Follower_4_price;
            shop_Follower_amount[3] += 1;

            // Fix later
            shop_Follower_4_price += 700;
            GameManager.Instance.follower4Damage += 30;
        }
    }
}
