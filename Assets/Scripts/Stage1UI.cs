using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1UI : MonoBehaviour
{
    // Time UI TEXT
    public Text populNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time print UI evey tick
        populNum.text = ""+ GameManager.Instance.population;
    }
}
