using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public GameObject CurrentWand;

    LayerMask PlayerLayer { get { return LayerMask.GetMask("Player"); } }
    Transform wandTip;

    public GameObject[] SpellPrefabs;
    public GameObject[] AttachSpellPrefabs;
    //public Dictionary<string, GameObject> SpellPrefabs = new Dictionary<string, GameObject>();

    XRControllerProperties XRCP;

    private void Awake()
    {

        XRCP = CurrentWand.GetComponentInParent<XRControllerProperties>();
        CurrentWand = GameObject.Find("Wand");
        wandTip = CurrentWand.transform.GetChild(0).Find("WandTip");

    }


    public void Spell_Lumen()
    {
        if (!wandTip.transform.Find("Lumen Spell(Clone)")) 
        { 
            GameObject LumenSpellCopy = Instantiate(SpellPrefabs[0], wandTip);
            LumenSpellCopy.transform.localPosition = Vector3.zero;
            LumenSpellCopy.transform.SetParent(wandTip);

        }
    }

    public void Spell_Obscuro()
    {
        if (wandTip.transform.Find("Lumen Spell(Clone)"))
        {
            wandTip.transform.Find("Lumen Spell(Clone)").GetComponent<LumenBehaviour>().TurnOff();
        }
    }
    public void Spell_Vulnus()
    {
        GameObject VulnusCopy = Instantiate(SpellPrefabs[1], wandTip.position, wandTip.rotation);
    }

    public void Spell_Apporto()
    {
        RaycastHit hit;

        if (Physics.SphereCast(CurrentWand.transform.position, 0.5f, CurrentWand.transform.TransformDirection(Vector3.forward), out hit, 500f, ~PlayerLayer))
        {
            
            if (hit.transform.GetComponent<Rigidbody>())
            {
                GameObject ApportoCopy = Instantiate(SpellPrefabs[2], wandTip.position, wandTip.rotation);
                ApportoCopy.transform.SetParent(wandTip);
                hit.transform.gameObject.AddComponent<BasicSpellBehaviour>();

                GameObject ApportoTargetCopy = Instantiate(AttachSpellPrefabs[0], hit.transform.position, hit.transform.rotation);
                ApportoTargetCopy.transform.SetParent(hit.transform);
                ApportoCopy.GetComponent<ApportoBehaviour>().apportoTarget = ApportoTargetCopy;
                //ApportoTargetCopy.GetComponent<ApportoBehaviour>().apportoTarget = ApportoTargetCopy;
                
            }
            
            Debug.Log("Hit:" + hit.transform.name);
            
        }
    }

    public void Spell_Repulso()
    {

        GameObject RepulsoCopy = Instantiate(SpellPrefabs[3], wandTip.position, wandTip.rotation);
        //RepulsoCopy.GetComponent<Rigidbody>().AddForce(CurrentWand.transform.TransformDirection(Vector3.forward * 2000.0f));


    }

    public void Spell_Finis()
    {


        BasicSpellBehaviour[] bsbs = CurrentWand.transform.GetComponentsInChildren<BasicSpellBehaviour>();

        foreach (BasicSpellBehaviour BSB in bsbs)
        {
            BSB.CallDestroy();
        }
    }

    public void Spell_Pendeo()
    {
        RaycastHit hit;

        if (Physics.SphereCast(CurrentWand.transform.position, 0.5f, CurrentWand.transform.TransformDirection(Vector3.forward), out hit, 500f, ~PlayerLayer))
        {

            if (hit.transform.GetComponent<Rigidbody>())
            {

                GameObject PendeoCopy = Instantiate(SpellPrefabs[4], hit.transform.position, hit.transform.rotation);
                PendeoCopy.transform.SetParent(hit.transform);


            }
        }

    }

    public void Spell_Statis()
    {
        RaycastHit hit;

        if (Physics.SphereCast(CurrentWand.transform.position, 0.5f, CurrentWand.transform.TransformDirection(Vector3.forward), out hit, 500f, ~PlayerLayer))
        {

            if (hit.transform.GetComponent<Rigidbody>())
            {

                GameObject PendeoCopy = Instantiate(SpellPrefabs[5], hit.transform.position, hit.transform.rotation);
                PendeoCopy.transform.SetParent(hit.transform);



            }
        }

    }


    public void Spell_Libera()
    {
        RaycastHit hit;

        if (Physics.SphereCast(CurrentWand.transform.position, 0.5f, CurrentWand.transform.TransformDirection(Vector3.forward), out hit, 500, ~PlayerLayer))
        {

            if (hit.transform.GetComponentInChildren<BasicSpellBehaviour>())
            {
                hit.transform.GetComponentInChildren<BasicSpellBehaviour>().shouldShutdown = true;
            }
            Debug.Log("Hit:" + hit.transform.name);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(CurrentWand.transform.position, CurrentWand.transform.TransformDirection(Vector3.forward));
    }

    
}
