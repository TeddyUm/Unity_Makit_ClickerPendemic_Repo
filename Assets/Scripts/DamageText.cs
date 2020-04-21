using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private float timer;
    private float cTimer;
    public Text textObj;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.0f;
        cTimer = 0.0f;
        textObj.text = "" + GameManager.Instance.getPlayerDamage();
    }

    // Update is called once per frame
    void Update()
    {
        cTimer += (Time.deltaTime / 2);
        textObj.transform.position = new Vector2(textObj.transform.position.x, textObj.transform.position.y + (Time.deltaTime * 30));
        textObj.color = new Color(1.0f, 0.0f, 0.0f, 1.0f - cTimer);
        Destroy(gameObject, timer);
    }

}
