using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // data
    public int[] enemyHP;                   // enemy HP
    public Sprite[] sprites;                // sprite enemy
    public Text hpNum;                      // enemy HP UI
    private SpriteRenderer enemyRenderer;   
    private int[] enemyMaxHP = new int[5];  // enemy max HP save 
    private int count;                      // order of enemies
    private float killTime = 0.0f;          // time limit timer

    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
        enemyRenderer.sprite = sprites[0];
        count = 0;

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

        // enemy HP count action
        if(enemyHP[count] <= 0)
        {
            // Money
            GameManager.Instance.money += 1000;

            // if enemy die, next enemy generate. timer reset
            GameManager.Instance.population = 1000;
            enemyRenderer.sprite = sprites[count];
            count++;
            GameManager.Instance.maxEnemyHP = enemyMaxHP[count];

            // if win 5 enemies, stage change
            if (count > 4)
            {
                switch(GameManager.Instance.currentScene)
                {
                    case 1:
                        GameManager.Instance.SceneChange("Stage2");
                        break;
                    case 2:
                        GameManager.Instance.SceneChange("Stage3");
                        break;
                    case 3:
                        GameManager.Instance.SceneChange("Stage4");
                        break;
                    case 4:
                        GameManager.Instance.SceneChange("Ending");
                        break;
                }
            }
        }

        // if times up, restart stage
        if (GameManager.Instance.population <= 0)
        {
            count = 0;
            enemyRenderer.sprite = sprites[0];
            GameManager.Instance.population = GameManager.Instance.maxPopul;
            for (int i = 0; i < 5; i++)
            {
                enemyHP[i] = enemyMaxHP[i];
            }
        }

        // kill people! timer
        killTime += Time.deltaTime;

        if(killTime > 0.01f)
        {
            GameManager.Instance.population -= 1;
            killTime = 0.0f;
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
}
