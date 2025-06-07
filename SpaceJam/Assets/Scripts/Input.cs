using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Interactions;


public class KeyboardInput : MonoBehaviour
{
    public Rocket rocket;

    int isEngineHold = 0;
    int isRotationHold = 0;

    public float engineDelta = 5f;
    public float rotationDelta = 30f;

    public void OnEngine(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isEngineHold = (int)context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            isEngineHold = (int)context.ReadValue<float>();
        }
    }

    public void OnRotation(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isRotationHold = (int)context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            isRotationHold = (int)context.ReadValue<float>();
        }
    }

    private void Update()
    {
        if (isEngineHold != 0) {
            rocket.enginePower += isEngineHold * engineDelta * Time.deltaTime;
            if (rocket.enginePower > 10f) // Limit the maximum power
            {
                rocket.enginePower = 10f;
            }
            else if (rocket.enginePower < 0f) // Prevent negative power
            {
                rocket.enginePower = 0f;
            }
        }

        if (isRotationHold != 0)
        {
            rocket.engineDirection += isRotationHold * rotationDelta * Time.deltaTime;
            if (rocket.engineDirection >= 360f) // Wrap around the angle
            {
                rocket.engineDirection -= 360f;
            }
            else if (rocket.engineDirection < 0f)
            {
                rocket.engineDirection += 360f;
            }
        }
    }
}
