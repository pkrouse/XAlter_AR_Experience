using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoldController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ARExperienceManager.Instance.pointerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ARExperienceManager.Instance.pointerUp();
    }
}
