using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public int population = 1000000000;
    public int doller = 0;
    public int playerDamage = 10;
    public int followerDamage = 0;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int getPlayerDamage()
    {
        return playerDamage;
    }
    public void setPlayerDamage(int addDamage)
    {
        playerDamage += addDamage;
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}

