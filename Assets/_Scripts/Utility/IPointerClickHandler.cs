using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickHandler : MonoBehaviour, IPointerClickHandler
{
    public bool isRaycastBlocking = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Логика, если необходимо, чтобы определённый UI элемент блокировал Raycast
        if (isRaycastBlocking)
        {
            Debug.Log("UI элемент блокирует Raycast.");
        }
        else
        {
            Debug.Log("UI элемент не блокирует Raycast.");
        }
    }
}
