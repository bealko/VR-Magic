using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisBehaviour : MonoBehaviour
{

    Rigidbody rb;
    BasicSpellBehaviour bsb;



    void Start()
    {
        
        bsb = GetComponent<BasicSpellBehaviour>();
        rb = GetComponentInParent<Rigidbody>();

        rb.isKinematic = true;


    }

    private void Update()
    {
        if (bsb.shouldShutdown)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            bsb.CallDestroy();
        }
    }


}
