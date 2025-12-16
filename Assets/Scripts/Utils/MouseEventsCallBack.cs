using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// This class call the corresponding events for mouse enter, exit and clicked
/// when the mouse is not over a UI element.
/// </summary>
public class MouseEventsCallBack : MonoBehaviour
{
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    public UnityEvent onMouseClick;

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            onMouseEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            onMouseExit?.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            onMouseClick?.Invoke();
    }
}
