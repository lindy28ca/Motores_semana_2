using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<float> movimiento;
    public static event Action<bool> saltos;
    public static event Action<float> cambiarColor;
    public void Movimiento(InputAction.CallbackContext context)
    {
        movimiento?.Invoke(context.ReadValue<float>());
    }
    public void Saltos(InputAction.CallbackContext context)
    {
        saltos?.Invoke(context.performed);
    }
    public void CambiarColor(InputAction.CallbackContext context)
    {
        cambiarColor?.Invoke(context.ReadValue<float>());
    }
}
