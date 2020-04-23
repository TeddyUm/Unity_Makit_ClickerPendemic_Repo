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
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.0f;
        cTimer = 0.0f;
        // Damage Print
        if(skillnum == 0)
        {
            textObj.text = "" + GameManager.Instance.playerDamage;
        }
        if (skillnum == 1)
        {
            textObj.text = "+ population\n" + GameManager.Instance.playerDamage * 1000000;
        }
        if (skillnum == 2)
        {
            textObj.text = "+ money\n" + GameManager.Instance.playerDamage * 10;
        }
        if (skillnum == 3)
            textObj.text = "" + GameManager.Instance.playerDamage * 10;
    }

    // Update is called once per frame
    void Update()
    {
        cTimer += (Time.deltaTime / 2);
        // damage print and moving to top with alpha animation
        textObj.transform.position = new Vector2(textObj.transform.position.x, textObj.transform.position.y + (Time.deltaTime * 30));
        textObj.color = new Color(textObj.color.r, textObj.color.g, textObj.color.b, 1.0f - cTimer);
        Destroy(gameObject, timer);
    }

}
