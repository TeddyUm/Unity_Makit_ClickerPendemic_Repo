using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1UI : MonoBehaviour
{
    // Time UI TEXT
    public Text populNum;
    public Enemy enemy;
    public Image populGuage;
    public Image enemyHPGuage;
    private float currentPopul;
    private float currentEnemyHP;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.maxPopul = GameManager.Instance.population;
        currentPopul = 1.0f;
        currentEnemyHP = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Time print UI evey tick
        if (GameManager.Instance.maxPopul >= GameManager.Instance.population)
        {
            populNum.text = "" + GameManager.Instance.population + "M";
        }
        else
        {
            populNum.text = "" + GameManager.Instance.maxPopul + "M";
        }

        // popul guage
        currentPopul = GameManager.Instance.population / (float)GameManager.Instance.maxPopul;
        populGuage.fillAmount = Mathf.Lerp(populGuage.fillAmount, currentPopul, Time.deltaTime * 3);
        // enemy guage
        currentEnemyHP = enemy.getEnemyHP() / (float)GameManager.Instance.maxEnemyHP;
        enemyHPGuage.fillAmount = Mathf.Lerp(enemyHPGuage.fillAmount, currentEnemyHP, Time.deltaTime * 3);
    }
}
