using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApportoTarget : MonoBehaviour
{
    GameObject wand;

    Rigidbody rb;

    float wandVelocity;
    Vector3 previous;

    ApportoBehaviour ab;

    XRControllerProperties XRCP;
    BasicSpellBehaviour bsb;
    GameObject apportoTarget;

    bool destroyInit;
    private void Start()
    {
        wand = GameObject.Find("Wand");
        ab = wand.GetComponentInChildren<ApportoBehaviour>();
        rb = GetComponentInParent<Rigidbody>();
        XRCP = wand.GetComponentInParent<XRControllerProperties>();
        bsb = GetComponent<BasicSpellBehaviour>();




    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            destroyInit = true;
        }
    }


    void Update()
    {

        float distance = Vector3.Distance(wand.transform.position, transform.position);

        wandVelocity = ((wand.transform.position - previous).magnitude) / Time.deltaTime;
        previous = wand.transform.position;

        if (distance > 1f)
        {
            //transform.LookAt(Player.transform, Vector3.up);
            rb.useGravity = false;
            rb.AddForce((wand.transform.position - transform.position).normalized * 1f, ForceMode.Acceleration);
        }
        if (distance <= 1f || destroyInit)
        {
            rb.useGravity = true;
            Destroy(this);
        }
    }



}
