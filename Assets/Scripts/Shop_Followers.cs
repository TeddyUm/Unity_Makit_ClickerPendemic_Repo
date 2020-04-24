using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Followers : MonoBehaviour
{
    public Text shop_Follower_1_level;
    public Text shop_Follower_1_Des;
    private static int shop_Follower_1_amount = 1;
    public Text Follower_1_money_text;
    private static int shop_Follower_1_price = 100;

    public Text shop_Follower_2_level;
    public Text shop_Follower_2_Des;
    private static int shop_Follower_2_amount = 1;
    public Text Follower_2_money_text;
    private static int shop_Follower_2_price = 200;

    public Text shop_Follower_3_level;
    public Text shop_Follower_3_Des;
    private static int shop_Follower_3_amount = 1;
    public Text Follower_3_money_text;
    private static int shop_Follower_3_price = 300;

    private void Update()
    {
        shop_Follower_1_level.text = "Lv. " + shop_Follower_1_amount;
        shop_Follower_1_Des.text = "Power up";
        Follower_1_money_text.text = string.Format("{0:n0}", shop_Follower_1_price);

        shop_Follower_2_level.text = "Lv. " + shop_Follower_2_amount;
        shop_Follower_2_Des.text = "Power up";
        Follower_2_money_text.text = string.Format("{0:n0}", shop_Follower_2_price);

        shop_Follower_3_level.text = "Lv. " + shop_Follower_3_amount;
        shop_Follower_3_Des.text = "Power up";
        Follower_3_money_text.text = string.Format("{0:n0}", shop_Follower_3_price);
    }

    public void shop_Follower_1()
    {
        if (GameManager.Instance.money >= shop_Follower_1_price)
        {
            GameManager.Instance.money -= shop_Follower_1_price;
            shop_Follower_1_amount += 1;

            // Fix later
            shop_Follower_1_price += 100;
            GameManager.Instance.follower1Damage += 10; 
        }
    }

    public void shop_Follower_2()
    {
        if (GameManager.Instance.money >= shop_Follower_2_price)
        {
            GameManager.Instance.money -= shop_Follower_2_price;
            shop_Follower_2_amount += 1;

            // Fix later
            shop_Follower_2_price += 100;
            GameManager.Instance.follower2Damage += 20;
        }
    }

    public void shop_Follower_3()
    {
        if (GameManager.Instance.money >= shop_Follower_3_price)
        {
            GameManager.Instance.money -= shop_Follower_3_price;
            shop_Follower_3_amount += 1;

            // Fix later
            shop_Follower_3_price += 100;
            GameManager.Instance.follower3Damage += 20;
        }
    }

}
