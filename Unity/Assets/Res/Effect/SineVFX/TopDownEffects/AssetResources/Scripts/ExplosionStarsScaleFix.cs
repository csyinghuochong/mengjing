using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionStarsScaleFix : MonoBehaviour
{
    public bool updateEveryFrame = false;
    public float scalingMultiplier = 1f;
    public bool lengthScaleEnabled = false;
    public float scalingLengthMultiplier = 1f;

    private ParticleSystemRenderer psr;

    // Start is called before the first frame update
    void Start()
    {
        psr = GetComponent<ParticleSystemRenderer>();

        AutoAdjustParticleSystemScaling();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (updateEveryFrame == true)
        {
            AutoAdjustParticleSystemScaling();
        }
    }

    // Sets the Speed Scale of a Particle System based on a Lossy Scale, making the scaling of VFX more convenient.
    public void AutoAdjustParticleSystemScaling()
    {
        psr.velocityScale = (1f / this.gameObject.transform.lossyScale.x) * scalingMultiplier;
        if (lengthScaleEnabled == true)
        {
            psr.lengthScale = (1f / this.gameObject.transform.lossyScale.x) * scalingLengthMultiplier;
        }
    }

    // Sets the Speed Scale of a Particle System based on a Lossy Scale, making the scaling of VFX more convenient. Used in the Editor Window.
    public void AutoAdjustParticleSystemScalingInEditor()
    {
        ParticleSystemRenderer psrlocal = GetComponent<ParticleSystemRenderer>();
        psrlocal.velocityScale = (1f / this.gameObject.transform.lossyScale.x) * scalingMultiplier;
        if (lengthScaleEnabled == true)
        {
            psrlocal.lengthScale = (1f / this.gameObject.transform.lossyScale.x) * scalingLengthMultiplier;
        }
    }
}
