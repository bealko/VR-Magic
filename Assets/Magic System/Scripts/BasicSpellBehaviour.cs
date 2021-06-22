using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BasicSpellBehaviour : MonoBehaviour
{
    VisualEffect effect;
    public bool destroyInTime;
    public float timeToDestroy;

    public bool shouldShutdown;

    private void Start()
    {
        if (destroyInTime)
        {
            Destroy(this.gameObject, timeToDestroy);
        }
        effect = transform.GetComponentInChildren<VisualEffect>();
    }


    private void Update()
    {
        if (shouldShutdown)
        {
            CallDestroy();
        }
    }


    public void CallDestroy()
    {
        effect.Stop();
        if (effect.aliveParticleCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    


}
