using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLoading : MonoBehaviour
{
    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        BGMManager.instance.Play(1);

        switch (GameManager.Instance.currentScene)
        {
            case 1:
                loadingText.text = "Black Death is defeated.\nBut next pandemic is coming...";
                break;
            case 2:
                loadingText.text = "Spain flu is defeated.\nBut next pandemic is coming...";
                break;
            case 3:
                loadingText.text = "SARS is defeated.\nBut next pandemic is coming...";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            switch (GameManager.Instance.currentScene)
            {
                case 1:
                    GameManager.Instance.population = 2000;
                    GameManager.Instance.SceneChange("Stage2");
                    break;
                case 2:
                    GameManager.Instance.population = 6500;
                    GameManager.Instance.SceneChange("Stage3");
                    break;
                case 3:
                    GameManager.Instance.population = 8000;
                    GameManager.Instance.SceneChange("Stage4");
                    break;
                default:
                    break;
            }
            BGMManager.instance.Stop();
        }

    }
}
