using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private InputAction action;

    [SerializeField] private List<GameObject> sphereObj;

    private bool isLightOn = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (action.triggered)
        {
            isLightOn = !isLightOn;
            Debug.Log("Input Action Triggered: " + isLightOn);
            foreach (var item in sphereObj)
            {
                item.SetActive(isLightOn);
            }
        }
    }

    public void OnEnable()
    {
        action.Enable();
    }

    public void OnDisable()
    {
        action.Disable();
    }
}