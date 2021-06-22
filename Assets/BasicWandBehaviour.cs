using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWandBehaviour : MonoBehaviour
{
    GameObject Wand;
    Transform WandTip;
    TrailRenderer Trail;
    [Header("Combat Spell")]
    public GameObject CombatSpell;

    XRControllerProperties XRCP;
    Vector3 velocity;

    //Spell Cast variables
    Vector3 velocityDirection;

    Vector3 lastvelocity;
    public bool velocityReached;
    float lastCasted;
    void Awake()
    {
        Wand = GameObject.Find("Wand");
        XRCP = GetComponentInParent<XRControllerProperties>();
        WandTip = Wand.transform.GetChild(0).Find("WandTip");
        Trail = WandTip.GetComponentInChildren<TrailRenderer>();
    }

    private void Start()
    {
        lastvelocity = XRCP.controllerVelocity;
    }


    // Update is called once per frame
    void Update()
    {

        velocityDirection = XRCP.controllerVelocity.normalized;
        velocity = XRCP.controllerVelocity;

        if (velocity.magnitude > 1f)
        {
            Trail.emitting = true;
        }
        else
        {
            Trail.emitting = false;
        }

        Debug.DrawRay(WandTip.transform.position, velocityDirection);


        float velDifference = Mathf.Abs((velocity - lastvelocity).magnitude) / Time.deltaTime;


        if (velocity.magnitude > 3f)
        {
            velocityReached = true;
        }

        if (velocityReached && velDifference > 2f)
        {
            velocityReached = false;
            if (Time.time - lastCasted > 0.25f)
            {
                lastCasted = Time.time;
                Vector3 castDirection = velocityDirection + WandTip.forward;
                GameObject CombatSpellCopy = Instantiate(CombatSpell, WandTip.transform.position, Quaternion.LookRotation(castDirection));
                velocityReached = false;
            }
            else
            {
                velocityReached = false;
            }
        }
        else
        {
            velocityReached = false;
        }




    }
}
