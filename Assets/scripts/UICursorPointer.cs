using UnityEngine;
using UnityEngine.EventSystems;

public class UICursorPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool cursorOverUI = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursorOverUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        cursorOverUI = false;
    }
}
