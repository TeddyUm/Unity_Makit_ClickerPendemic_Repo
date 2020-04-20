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

    private void Start()
    {
        defaultScale = buttoneScale.localScale;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                Debug.Log("Start");

                SceneManager.LoadScene("Loading");
                break;

            case BTNType.Option:
                Debug.Log("Option");
                break;

            case BTNType.Credits:
                Debug.Log("Credits");
                break;

            case BTNType.Sound:
                Debug.Log("Sound");
                break;

            case BTNType.Back:
                Debug.Log("Back");
                break;

            case BTNType.Quit:
                Debug.Log("Quit");
                break;
        }
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
