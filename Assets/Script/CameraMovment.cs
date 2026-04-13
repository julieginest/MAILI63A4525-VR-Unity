using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovment : MonoBehaviour
{
    /*[SerializeField] private InputAction left;
    [SerializeField] private InputAction right;
    [SerializeField] private InputAction frontward;
    [SerializeField] private InputAction backward;

    [SerializeField] private Transform cameraTransform;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0F;*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*int movmentHorizontal=0, movmentVertical=0;
        Vector3 hMoveDir = cameraTransform.right * movmentHorizontal;
        Vector3 vMoveDir = cameraTransform.forward * movmentVertical;
        Vector3 moveDir = vMoveDir + hMoveDir;
        lookRotation = Quaternion.LookRotation(moveDir);*/
        
    }

    /*public void OnEnable()
    {
        left.Enable();
        right.Enable();
        frontward.Enable();
        backward.Enable();
    }

    public void OnDisable()
    {
        left.Disable();
        right.Disable();
        frontward.Disable();
        backward.Disable();
    }*/


}
