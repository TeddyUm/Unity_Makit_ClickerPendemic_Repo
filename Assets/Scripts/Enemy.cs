using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int[] enemyHP;
    public Sprite[] sprites;
    public Text hpNum;
    private SpriteRenderer enemyRenderer;
    private int[] enemyMaxHP = new int[5];
    private int count;
    private float killTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
        enemyRenderer.sprite = sprites[0];
        count = 0;
        for (int i = 0; i < 5; i++)
        {
            enemyMaxHP[i] = enemyHP[i];
        }
        
    GameManager.Instance.currentScene++;
    }

    // Update is called once per frame
    void Update()
    {
        hpNum.text = "" + enemyHP[count];
        if(enemyHP[count] <= 0)
        {
            GameManager.Instance.population = 1000000000;
            enemyRenderer.sprite = sprites[count];
            count++;
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

        if (GameManager.Instance.population <= 0)
        {
            count = 0;
            enemyRenderer.sprite = sprites[0];
            GameManager.Instance.population = 1000000000;
            for (int i = 0; i < 5; i++)
            {
                enemyHP[i] = enemyMaxHP[i];
            }
        }

        killTime += Time.deltaTime;
        if(killTime > 0.01f)
        {
            GameManager.Instance.population -= 1000000;
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
