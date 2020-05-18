using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // main data
    public int population = 450;        // time
    public int money = 0;               // money
    public int playerDamage = 5;       // damage
    public int follower1Damage = 10;    // follower1 damage
    public int follower2Damage = 20;   // follower2 damage
    public int follower3Damage = 50;  // follower3 damage
    public int follower4Damage = 100; // follower4 damage
    public int currentScene = 0;        // scene number

    public int SkillControl = 2;
    public int damageSkill = 50;        // damage skill amount
    public int moneySkill = 1000;        // money skill amount
    public int healSkill;        // heal skill amount

    public int maxPopul = 1000;
    public int maxEnemyHP = 1000;

    // Shops
    public int[] shop_Player_amount = { 1, 1, 1, 1 };
    public int[] shop_Player_price = { 500, 650, 700, 850 };

    public int[] shop_Follower_amount = { 1, 1, 1, 1 };
    public int[] shop_Follower_price = { 1000, 2500, 4000, 6500 };

    // Don't destroy
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // singleton
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // scene change function
    public void SceneChange(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}

