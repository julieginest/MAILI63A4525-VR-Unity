using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightHandler : MonoBehaviour
{
    [SerializeField] private InputAction action;
    [SerializeField] private List<Light> lights;

    private bool isLightOn;

    private void Start()
    {
        if (lights != null && lights.Count > 0 && lights[0] != null)
        {
            isLightOn = lights[0].enabled;
        }
    }

    private void Update()
    {
        if (action.WasPressedThisFrame())
        {
            isLightOn = !isLightOn;
            Debug.Log("Input Action Triggered: " + isLightOn);

            foreach (var lightItem in lights)
            {
                if (lightItem != null)
                    lightItem.enabled = isLightOn;
            }
        }
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}