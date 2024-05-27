using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickHandler : MonoBehaviour, IPointerClickHandler
{
    public bool isRaycastBlocking = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        // ������, ���� ����������, ����� ����������� UI ������� ���������� Raycast
        if (isRaycastBlocking)
        {
            Debug.Log("UI ������� ��������� Raycast.");
        }
        else
        {
            Debug.Log("UI ������� �� ��������� Raycast.");
        }
    }
}
