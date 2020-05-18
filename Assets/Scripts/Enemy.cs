using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // timer reset
    private int reset_population;

    // data
    public int[] enemyHP;                   // enemy HP
    public string[] enemyName;              // enemy name
    public Sprite[] sprites;                // sprite enemy
    public Text hpNum;                      // enemy HP UI
    public Stage1UI stage;
    private SpriteRenderer enemyRenderer;   // enemy image renderer
    private int[] enemyMaxHP = new int[5];  // enemy max HP save 
    private int count;                      // order of enemies (boss == 4)

    private float killTime = 0.0f;          // time limit timer
    public int KillSpeedControl = 1;

    public int enemy_money = 1000;
    public int Boss_money = 3000;

    // Start is called before the first frame update
    void Start()
    {
        reset_population = GameManager.Instance.population;

        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
        count = 0;
        enemyRenderer.sprite = sprites[0];
  
        // init max enemy HP
        for (int i = 0; i < 5; i++)
        {
            enemyMaxHP[i] = enemyHP[i];
        }
        GameManager.Instance.maxEnemyHP = enemyMaxHP[count];
        GameManager.Instance.currentScene++;
    }

    // Update is called once per frame
    void Update()
    {
        // enemy HP print
        hpNum.text = "" + enemyHP[count];

        enemyRenderer.sprite = sprites[count];
        GameManager.Instance.maxEnemyHP = enemyMaxHP[count];

        // if times up, restart the enemy
        if (GameManager.Instance.population <= 0)
        {
            count = 0;
            GameManager.Instance.population = GameManager.Instance.maxPopul;
            for (int i = 0; i < 5; i++)
            {
                enemyHP[i] = enemyMaxHP[i];
            }
        }

        // enemy HP count action
        if (enemyHP[count] <= 0)
        {
            // Money
            if (count == 4) //  Boss
            {
                GameManager.Instance.money += Boss_money;
            }
            else
            {
                GameManager.Instance.money += enemy_money;
            }

            // if enemy die, next enemy generate. timer reset
            GameManager.Instance.population = reset_population;
            count++;

            // if win 5 enemies, stage change
            if (count > 4)
            {
                // stage change action
                switch(GameManager.Instance.currentScene)
                {
                    case 1:
                        GameManager.Instance.SceneChange("StageLoading");
                        break;
                    case 2:
                        GameManager.Instance.SceneChange("StageLoading");
                        break;
                    case 3:
                        GameManager.Instance.SceneChange("StageLoading");
                        break;
                    case 4:
                        GameManager.Instance.SceneChange("Ending");
                        break;
                }
            }
        }

        // kill people! timer
        killTime += Time.deltaTime;

        // stage change speed
        if (count == 4) // Boss
        {
            if (killTime > 0.05) // More Fast
            {
                GameManager.Instance.population -= KillSpeedControl;
                killTime = 0.0f;
            }
        }
        else
        {
            if (killTime > 0.08)
            {
                GameManager.Instance.population -= KillSpeedControl;
                killTime = 0.0f;
            }
        }
    }        

    public void SetEnemyHP(int HP)
    {
        enemyHP[count] = HP;
    }
    public int getEnemyHP()
    {
        return enemyHP[count];
    }
    public string getEnemyName()
    {
        return enemyName[count];
    }
}
