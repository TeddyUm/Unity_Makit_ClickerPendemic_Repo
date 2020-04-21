using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1UI : MonoBehaviour
{
    public Text populNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        populNum.text = ""+ GameManager.Instance.population;
    }
}
