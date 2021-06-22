using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PendeoBehaviour : MonoBehaviour
{
    public Vector3 movementDirection;
    private Vector3 movementSpeed;
    Rigidbody rb;
    BasicSpellBehaviour bsb;

    private InputActionProperty controllerVelocity;

    public GameObject wandHand;

    XRControllerProperties xrcp;

    void Start()
    {
        //wandHand = GameObject.Find("Wand").par

        xrcp = GameObject.Find("Wand").GetComponentInParent<XRControllerProperties>();

        bsb = GetComponent<BasicSpellBehaviour>();
        rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = false;


    }

    void Update()
    {

        movementDirection = xrcp.controllerVelocity.normalized;

        rb.AddForce(movementDirection);





        if (bsb.shouldShutdown)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            bsb.CallDestroy();
        }

    }
}
