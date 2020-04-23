using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // data
    public BoxCollider2D touch;
    public GameObject textObj;
    public Enemy enemy;
    public float attackTimer = 1.0f;
    private float attackCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCount += Time.deltaTime;

        if (attackCount > attackTimer)
        {
            Instantiate(textObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
            enemy.SetEnemyHP(enemy.getEnemyHP() - GameManager.Instance.playerDamage);
            attackCount = 0.0f;
        }

        // Touch and take a damage, Using Raycast
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero);

        if(rayHit.collider != null)
        {
            if (rayHit.collider == touch && Input.GetMouseButtonDown(0))
            {
                Instantiate(textObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                enemy.SetEnemyHP(enemy.getEnemyHP() - GameManager.Instance.playerDamage);
            }
        }
    }
}
