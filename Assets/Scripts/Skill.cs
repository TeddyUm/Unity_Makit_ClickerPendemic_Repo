using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // skill image, button and text
    public Image skillNews;
    public Image skillFund;
    public Image skillMedical;

    public Button buttonNews;
    public Button buttonFund;
    public Button buttonMedical;

    public GameObject textObj;
    public GameObject healObj;
    public GameObject moneyObj;

    public GameObject skillEffect;
    public Enemy enemy;

    // skill cool time
    public float newsCooltime = 10.0f;
    public float fundCooltime = 10.0f;
    public float medicalCooltime = 10.0f;

    // skill lifetime check
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
        // init skill func
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

    void Update()
    {
        // damage skill cooltime check and active
        if (newsIsClicked)
        {
            if (newsLeftTime > 0)
            {
                newsLeftTime -= Time.deltaTime * speed;
                if (newsLeftTime < 0)
                {
                    newsLeftTime = 0;
                    if (buttonNews)
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
        // money skill cooltime check and active
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
        // heal skill cooltime check and active
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
    // damage skill cooltime
    public void NewsStartCoolTime()
    {
        newsLeftTime = newsCooltime;
        newsIsClicked = true;
        if (buttonNews)
            buttonNews.enabled = false;
        Damage();
    }
    // money skill cooltime
    public void FundStartCoolTime()
    {
        fundLeftTime = fundCooltime;
        fundIsClicked = true;
        if (buttonFund)
            buttonFund.enabled = false;
        Money();
    }
    // heal skill cooltime
    public void MedStartCoolTime()
    {
        medicalLeftTime = medicalCooltime;
        medicalIsClicked = true;
        if (buttonMedical)
            buttonMedical.enabled = false;
        Heal();
    }
    // Skill breaking news
    public void Damage()
    {
        // damage skill
        Instantiate(textObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        enemy.SetEnemyHP(enemy.getEnemyHP() - GameManager.Instance.damageSkill);
    }
    public void Heal()
    {
        // heal skill
        Instantiate(healObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        GameManager.Instance.population += GameManager.Instance.healSkill;

        // max cap
        if (GameManager.Instance.population > GameManager.Instance.maxPopul)
            GameManager.Instance.population = GameManager.Instance.maxPopul;
    }
    public void Money()
    {
        // money skill
        Instantiate(moneyObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        GameManager.Instance.money += GameManager.Instance.moneySkill;
    }
}