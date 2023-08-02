using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> SliderHandler = null;
    public void OnPointerClick(PointerEventData eventData) // Ŭ������ �� �̺�Ʈ �������̽�
    {
        if(OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (SliderHandler != null)
        {
            SliderHandler.Invoke(eventData);
        }
    }
}
