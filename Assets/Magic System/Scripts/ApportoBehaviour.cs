using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;
public class ApportoBehaviour : MonoBehaviour
{
    VisualEffect effect;
    public GameObject apportoTarget;

    XRControllerProperties XRCP;

    private void Start()
    {
        effect = transform.GetComponentInChildren<VisualEffect>();
        //apportoTarget = GameObject.Find("ApportoTarget");
    }

    private void Update()
    {
        //effect.SetVector3("WorldPosition", transform.parent.transform.position);
        effect.SetVector3("TargetPosition", apportoTarget.transform.position);

        

    }

}
