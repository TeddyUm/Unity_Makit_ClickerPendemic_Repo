using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    // damage Text print
    private float timer;    // death timer
    private float cTimer;   // alpha change
    public Text textObj;    // Damage Text
    public int skillnum = 0;
    public Skill skill;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.0f;
        cTimer = 0.0f;
        // Damage Print
        if (skillnum == 0) // normal attack
        {
            textObj.text = "" + GameManager.Instance.playerDamage;
        }
        else if (skillnum == 1) // population
        {
            textObj.text = "+ population\n" + GameManager.Instance.healSkill + "M";
        }
        else if (skillnum == 2) // money
        {
            textObj.text = "+ money\n" + GameManager.Instance.moneySkill;
        }
        else if (skillnum == 3) // new attack
        {
            textObj.text = "+ Damage\n" + GameManager.Instance.damageSkill;
        }
        else if (skillnum == 4) // follower atk 1
        {
            textObj.text = "" + GameManager.Instance.follower1Damage;
        }
        else if (skillnum == 5) // follower atk 2
        {
            textObj.text = "" + GameManager.Instance.follower2Damage;
        }
        else if (skillnum == 6) // follower atk 3
        {
            textObj.text = "" + GameManager.Instance.follower3Damage;
        }
        else if (skillnum == 7) // follower atk 4
        {
            textObj.text = "" + GameManager.Instance.follower4Damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cTimer += (Time.deltaTime / 2);
        // damage print and moving to top with alpha animation
        textObj.transform.position = new Vector2(textObj.transform.position.x, textObj.transform.position.y + (Time.deltaTime * 30));
        textObj.color = new Color(textObj.color.r, textObj.color.g, textObj.color.b, 1.0f - cTimer);
        Destroy(gameObject, timer);

        if(PauseMenu.GameIsPaused == true)
        {
            textObj.text = "";
        }
    }

}
