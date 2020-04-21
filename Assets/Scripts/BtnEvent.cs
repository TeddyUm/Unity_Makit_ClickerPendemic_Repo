using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnEvent : MonoBehaviour
{
    public Transform buttoneScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttoneScale.localScale;
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
