using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image skillNews;
    public Image skillFund;
    public Image skillMedical;
    public Button buttonNews;
    public Button buttonFund;
    public Button buttonMedical;

    public GameObject textObj;
    public GameObject healObj;
    public GameObject moneyObj;
    public Enemy enemy;

    public float newsCooltime = 10.0f;
    public float fundCooltime = 10.0f;
    public float medicalCooltime = 10.0f;

    private float newsLeftTime = 0;
    private float fundLeftTime = 0;
    private float medicalLeftTime = 0;

    private bool newsIsClicked = false;
    private bool fundIsClicked = false;
    private bool medicalIsClicked = false;

    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        newsLeftTime = newsCooltime;
        newsIsClicked = true;
        if (buttonNews)
            buttonNews.enabled = false;

        fundLeftTime = fundCooltime;
        fundIsClicked = true;
        if (buttonFund)
            buttonFund.enabled = false;

        medicalLeftTime = medicalCooltime;
        medicalIsClicked = true;
        if (buttonMedical)
            buttonMedical.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(newsIsClicked)
        {
            if(newsLeftTime> 0)
            {
                newsLeftTime -= Time.deltaTime * speed;
                if(newsLeftTime < 0)
                {
                    newsLeftTime = 0;
                    if(buttonNews)
                    {
                        buttonNews.enabled = true;
                    }
                    newsIsClicked = true;
                }
                float ratio = 1.0f - (newsLeftTime / newsCooltime);
                if (skillNews)
                    skillNews.fillAmount = ratio;
            }
        }
        if (fundIsClicked)
        {
            if (fundLeftTime > 0)
            {
                fundLeftTime -= Time.deltaTime * speed;
                if (fundLeftTime < 0)
                {
                    fundLeftTime = 0;
                    if (buttonFund)
                    {
                        buttonFund.enabled = true;
                    }
                    fundIsClicked = true;
                }
                float ratio = 1.0f - (fundLeftTime / fundCooltime);
                if (skillFund)
                    skillFund.fillAmount = ratio;
            }
        }
        if (medicalIsClicked)
        {
            if (medicalLeftTime > 0)
            {
                medicalLeftTime -= Time.deltaTime * speed;
                if (medicalLeftTime < 0)
                {
                    medicalLeftTime = 0;
                    if (buttonMedical)
                    {
                        buttonMedical.enabled = true;
                    }
                    medicalIsClicked = true;
                }
                float ratio = 1.0f - (medicalLeftTime / medicalCooltime);
                if (skillMedical)
                    skillMedical.fillAmount = ratio;
            }
        }
    }
    public void NewsStartCoolTime()
    {
        newsLeftTime = newsCooltime;
        newsIsClicked = true;
        if (buttonNews)
            buttonNews.enabled = false;
        Damage();
    }
    public void FundStartCoolTime()
    {
        fundLeftTime = fundCooltime;
        fundIsClicked = true;
        if (buttonFund)
            buttonFund.enabled = false;
        Money();
    }
    public void MedStartCoolTime()
    {
        medicalLeftTime = medicalCooltime;
        medicalIsClicked = true;
        if (buttonMedical)
            buttonMedical.enabled = false;
        Heal();
    }
    void Damage()
    {
         Instantiate(textObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
         enemy.SetEnemyHP(enemy.getEnemyHP() - GameManager.Instance.playerDamage * 10);
    }
    void Heal()
    {
        Instantiate(healObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        GameManager.Instance.population += (100 * (1 + GameManager.Instance.currentScene));
    }
    void Money()
    {
        Instantiate(moneyObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        GameManager.Instance.money += (GameManager.Instance.playerDamage * 10);
    }
}
