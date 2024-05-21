using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Checks for button input on an input action
/// </summary>
public class OnButtonPress : MonoBehaviour
{
    [Tooltip("Actions to check")]
    public InputAction action = null;

    // When the button is pressed
    public UnityEvent OnPress1 = new UnityEvent();

    public UnityEvent OnPress2 = new UnityEvent();

    // When the button is released
    public UnityEvent OnRelease = new UnityEvent();

    private void Awake()
    {
        action.started += Pressed1;
        action.canceled += Pressed2;
        action.canceled += Released;
    }

    private void OnDestroy()
    {
        action.started -= Pressed1;
        action.canceled -= Pressed2;
        action.canceled -= Released;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Pressed1(InputAction.CallbackContext context)
    {
        OnPress1.Invoke();
    }

    private void Pressed2(InputAction.CallbackContext context)
    {
        OnPress2.Invoke();
    }

    private void Released(InputAction.CallbackContext context)
    {
        OnRelease.Invoke();
    }
}
