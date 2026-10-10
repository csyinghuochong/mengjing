using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_CallBackParent : MonoBehaviour
{
    [SerializeField]protected Transform parentObject;

    //Particle system must have "Stop action - Callback" enabled for normal work.
    protected virtual void OnParticleSystemStopped()
    {
        if (parentObject != null)
        {
            transform.parent = parentObject;
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }
        else
            Destroy(gameObject);
    }
}
