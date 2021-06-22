using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LumenBehaviour : MonoBehaviour
{

    public float maxBrightness;
    public Light pointLight;
    public bool turningOff;
    public VisualEffect effect;

    private void Start()
    {
        pointLight = transform.GetComponentInChildren<Light>();
        effect = transform.GetComponentInChildren<VisualEffect>();
    }

    public void TurnOff()
    {
        turningOff = true;
        if (pointLight.intensity > 10)
        {
            pointLight.intensity -= 100.0f * Time.deltaTime;
            effect.Stop();
        }
        if(pointLight.intensity <= 10 && effect.aliveParticleCount <= 0)
        {

            Destroy(this.gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(pointLight.intensity < maxBrightness && !turningOff)
        {
            pointLight.intensity += 100.0f * Time.deltaTime;
        }

        if (turningOff)
        {
            TurnOff();
        }







    }
}
