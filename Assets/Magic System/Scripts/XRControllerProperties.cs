using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
public class XRControllerProperties : MonoBehaviour
{
    public InputActionProperty controllerVelocityInput;

    public Vector3 controllerVelocity { get; private set; }= Vector3.zero;
    
    public InputActionProperty angularVelocityInput;

    public Vector3 angularVelocity{ get; private set; }= Vector3.zero;


    void Update()
    {
        controllerVelocity = controllerVelocityInput.action.ReadValue<Vector3>();
        angularVelocity = angularVelocityInput.action.ReadValue<Vector3>();

        //Debug.Log("controllerVelocity" + controllerVelocityInput + ":" + controllerVelocity);


    }
}
