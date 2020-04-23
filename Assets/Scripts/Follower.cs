using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Enemy enemy;
    public GameObject textObj;
    public int followerNum;
    public float attackDelay;
    private float attackCount;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        attackCount = 0;
        switch(followerNum)
        {
            case 1:
                damage = GameManager.Instance.follower1Damage;
            break;
            case 2:
                damage = GameManager.Instance.follower2Damage;
                break;
            case 3:
                damage = GameManager.Instance.follower3Damage;
                break;
            case 4:
                damage = GameManager.Instance.follower4Damage;
                break;
            default:
            break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        attackCount += Time.deltaTime;
        if(attackCount > attackDelay)
        {
            enemy.SetEnemyHP(enemy.getEnemyHP() - damage);
            Instantiate(textObj, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
            attackCount = 0;
        }
    }
}
