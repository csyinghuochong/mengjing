using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateOverDistanceScaleFix : MonoBehaviour
{
    public bool updateEveryFrame = false;
    public bool rateWithCurve = true;
    public float rateMultiplier = 1f;

    private ParticleSystem ps;
    private ParticleSystem.EmissionModule psem;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        psem = ps.emission;

        AutoAdjustParticleSystemRateOverDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateEveryFrame == true)
        {
            AutoAdjustParticleSystemRateOverDistance();
        }
    }

    // Sets the Speed Scale of a Particle System based on a Lossy Scale, making the scaling of VFX more convenient.
    public void AutoAdjustParticleSystemRateOverDistance()
    {
        if (rateWithCurve == true)
        {
            psem.rateOverDistanceMultiplier = (1f / this.gameObject.transform.lossyScale.x) * rateMultiplier;
        }
        else
        {
            psem.rateOverDistance = (1f / this.gameObject.transform.lossyScale.x) * rateMultiplier;
        }
    }

    // Sets the Speed Scale of a Particle System based on a Lossy Scale, making the scaling of VFX more convenient.
    public void AutoAdjustParticleSystemRateOverDistanceInEditor()
    {
        ParticleSystem pslocal = GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule psemlocal = pslocal.emission;
        if (rateWithCurve == true)
        {
            psemlocal.rateOverDistanceMultiplier = (1f / this.gameObject.transform.lossyScale.x) * rateMultiplier;
        }
        else
        {
            psemlocal.rateOverDistance = (1f / this.gameObject.transform.lossyScale.x) * rateMultiplier;
        }
    }
}
