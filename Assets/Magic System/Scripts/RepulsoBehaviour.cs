using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class RepulsoBehaviour : MonoBehaviour
{
    GameObject wand;
    VisualEffect effect { get { return GetComponent<VisualEffect>(); } }

    float Force = 1000.0f;

    private void Start()
    {
        wand = GameObject.Find("PineWoodWand");
        GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * 2000.0f));
    }


    private void OnCollisionEnter(Collision collision)
    {

        Vector3 collisionPoint = collision.contacts[0].point;
        
        Vector3 direction = collisionPoint - wand.transform.position;
        direction = direction.normalized;

        if (collision.transform.GetComponent<Rigidbody>())
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(direction * Force);
        }

        effect.Stop();
        if (effect.aliveParticleCount <= 0)
        {
            Destroy(this.gameObject);
        }


    }
}
