using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaleMaster : MonoBehaviour
{
    public bool adjustAtStart = false;

    private RateOverDistanceScaleFix[] rateOverDistanceScaleFixScripts;
    private ExplosionStarsScaleFix[] explosionStarsScaleFixScripts;

    // Start is called before the first frame update
    void Start()
    {
        if (adjustAtStart == true)
        {
            AutoScaleAndRateFix();
        }
    }

    // Find and fix all scales and rates over distance multipliers in all child gameObjects.
    public void AutoScaleAndRateFix()
    {
        rateOverDistanceScaleFixScripts = this.gameObject.GetComponentsInChildren<RateOverDistanceScaleFix>();
        explosionStarsScaleFixScripts = this.gameObject.GetComponentsInChildren<ExplosionStarsScaleFix>();

        if (rateOverDistanceScaleFixScripts != null)
        {
            foreach (RateOverDistanceScaleFix rodsf in rateOverDistanceScaleFixScripts)
            {
                if (rodsf != null)
                {
                    rodsf.AutoAdjustParticleSystemRateOverDistanceInEditor();
                }
            }
        }

        if (explosionStarsScaleFixScripts != null)
        {
            foreach (ExplosionStarsScaleFix essf in explosionStarsScaleFixScripts)
            {
                if (essf != null)
                {
                    essf.AutoAdjustParticleSystemScalingInEditor();
                }
            }
        }
    }

    // Find and fix all scales and rates over distance multipliers in all child gameObjects. Used in the Editor Window.
    public void AutoScaleAndRateFixInEditor()
    {
        RateOverDistanceScaleFix[] rateOverDistanceScaleFixScriptsLocal = this.gameObject.GetComponentsInChildren<RateOverDistanceScaleFix>();
        ExplosionStarsScaleFix[] explosionStarsScaleFixScriptsLocal = this.gameObject.GetComponentsInChildren<ExplosionStarsScaleFix>();

        if (rateOverDistanceScaleFixScriptsLocal != null)
        {
            foreach (RateOverDistanceScaleFix rodsf in rateOverDistanceScaleFixScriptsLocal)
            {
                if (rodsf != null)
                {
                    rodsf.AutoAdjustParticleSystemRateOverDistanceInEditor();
                }
            }
        }

        if (explosionStarsScaleFixScriptsLocal != null)
        {
            foreach (ExplosionStarsScaleFix essf in explosionStarsScaleFixScriptsLocal)
            {
                if (essf != null)
                {
                    essf.AutoAdjustParticleSystemScalingInEditor();
                }
            }
        }
    }
}