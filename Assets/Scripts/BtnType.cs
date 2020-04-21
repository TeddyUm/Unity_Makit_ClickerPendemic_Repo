using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttoneScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    private void Start()
    {
        defaultScale = buttoneScale.localScale;
    }

    bool isSound;

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                Debug.Log("Start");
                SceneLoad.LoadSceneHandle("Play", 0);
                break;

            case BTNType.Option:
                Debug.Log("Option");
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;

            case BTNType.Credits:
                Debug.Log("Credits");
                break;

            case BTNType.Sound:
                if (isSound)
                {
                    Debug.Log("Sound OFF");
                }
                else
                {
                    Debug.Log("Sound ON");
                }
                isSound = !isSound;
                break;

            case BTNType.Back:
                Debug.Log("Back");
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup); 
                break;

            case BTNType.Quit:
                Application.Quit();
                Debug.Log("Quit");
                break;
        }
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttoneScale.localScale = defaultScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttoneScale.localScale = defaultScale;
    }
}
