using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static int money;

    private void Awake()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text Goldmoney = GameObject.FindGameObjectWithTag("Money").GetComponentInChildren<Text>();

        Goldmoney.text = string.Format("{0:n0}", money);
    }
}
