using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Interactions;


public class KeyboardInput : MonoBehaviour
{
    public Rocket rocket;

    int isRotationHold = 0;

    public float rotationDelta = 180f;

    public void OnEngine(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            Debug.Log("Engine started");
            rocket.isEngineOn = true;
        }
        else if (context.canceled)
        {
            Debug.Log("Engine stopped");
            rocket.isEngineOn = false;
        }
    }

    public void OnRotation(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isRotationHold = (int)context.ReadValue<float>();
            rocket.isRotating = true;
        }
        else if (context.canceled)
        {
            isRotationHold = (int)context.ReadValue<float>();
            rocket.isRotating = false;
        }
    }

    private void Update()
    {
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
