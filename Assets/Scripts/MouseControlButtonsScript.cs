using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControlButtonsScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManagerScript.instance.ToHand();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManagerScript.instance.ToPointer();
    }
}
