using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

namespace INab.Dissolve
{
    [RequireComponent(typeof(Dissolver))]
    [ExecuteInEditMode]
    public class DissolverVFX : MonoBehaviour
    {
        private Dissolver dissolver;
        public VisualEffect dissolveEffect;
        public VisualEffect materializeEffect;
        public Material materialToCopyFrom;

        public enum VfxType
        {
            OnlyDissolve,
            OnlyMaterialize,
            Both
        }

        public VfxType vfxType;

        public enum DissolveType
        {
            Standard,Axis
        }

        public DissolveType dissolveType;

        private void OnEnable()
        {
            if (dissolver == null) dissolver = GetComponent<Dissolver>();
            dissolver.OnPropertyUpdate += UpdateDissolveAmount;
            dissolver.OnDissolveStateChange += SendEvents;
        }

        private void OnDisable()
        {
            dissolver.OnPropertyUpdate -= UpdateDissolveAmount;
            dissolver.OnDissolveStateChange -= SendEvents;
        }

        public void Start()
        {
            //StopEffects();
        }

        private void CheckGraphsNulls()
        {
            switch (vfxType)
            {
                case VfxType.OnlyDissolve:
                    if (dissolveEffect == null)
                    {
                        Debug.LogWarning("There is no dissolve visual effect graph in Dissolver VFX.");
                        return;
                    }

                    break;
                case VfxType.OnlyMaterialize:
                    if (materializeEffect == null)
                    {
                        Debug.LogWarning("There is no materialize visual effect graph in Dissolver VFX.");
                        return;
                    }

                    break;
                case VfxType.Both:
                    if (dissolveEffect == null)
                    {
                        Debug.LogWarning("There is no dissolve visual effect graph in Dissolver VFX.");
                        return;
                    }

                    if (materializeEffect == null)
                    {
                        Debug.LogWarning("There is no materialize visual effect graph in Dissolver VFX.");
                        return;
                    }

                    break;
                default:
                    break;
            }
        }

        private void SendEvents(bool start,bool materialize)
        {
            CheckGraphsNulls();

            if (vfxType == VfxType.OnlyDissolve || vfxType == VfxType.Both)
            {
                if (!materialize)
                {
                    if (start)
                        dissolveEffect.SendEvent("OnPlay");
                    else
                        dissolveEffect.SendEvent("OnStop");
                }
            }

            if (vfxType == VfxType.OnlyMaterialize || vfxType == VfxType.Both)
            {
                if (materialize)
                {
                    if (start)
                    {
                        materializeEffect.SendEvent("OnPlay");
                    }
                    else
                    {
                        materializeEffect.SendEvent("OnStop");
                    }
                }
            }
        }

        private void UpdateDissolveAmount(float value)
        {
            CheckGraphsNulls();

            if(dissolveEffect) dissolveEffect.SetFloat("Dissolve Amount", value);
            if(materializeEffect) materializeEffect.SetFloat("Dissolve Amount", value);
        }
        
        /// <summary>
        /// Copies all needed properties from the first material from Materials list to the selected vfx graph.
        /// </summary>
        public void CopyProperties()
        {
            CheckGraphsNulls();

            Material material = materialToCopyFrom;

            if(material == null)
            {
                if (dissolver == null) dissolver = GetComponent<Dissolver>();

                if (dissolver.materials.Count == 0)
                {
                    Debug.LogWarning("There is no materials in Dissolver and materialToCopyFrom wasn't specified.");
                    return;
                }

                material = dissolver.materials[0];
            }

            if (dissolveEffect)
            {
                CopyStandardProperties(material, dissolveEffect);

                if (dissolveType == DissolveType.Axis)
                {
                    CopyAxisProperties(material, dissolveEffect);
                }
            }

            if (materializeEffect)
            {
                CopyStandardProperties(material, materializeEffect);

                if (dissolveType == DissolveType.Axis)
                {
                    CopyAxisProperties(material, materializeEffect);
                }
            }
        }

        /// <summary>
        /// Stops all VFX effects attached to the script.
        /// </summary>
        public void StopEffects()
        {
            if(materializeEffect) materializeEffect.SendEvent("OnStop");
            if (dissolveEffect) dissolveEffect.SendEvent("OnStop");
        }

        private void CopyStandardProperties(Material material, VisualEffect visualEffect)
        {
            visualEffect.SetFloat("Dissolve Amount", material.GetFloat("_DissolveAmount"));
            if (material.GetTexture("_GuideTexture"))
            {
                visualEffect.SetTexture("Guide Texture", material.GetTexture("_GuideTexture"));
            }
            else
            {
                Debug.LogWarning("There is no guide texture in dissolve material. Please, make sure to set Visual Effect Graphs Guide Texture property to white texture (Particle_6).");
            }
            visualEffect.SetFloat("Guide Tilling", material.GetFloat("_GuideTilling"));
        }

        private void CopyAxisProperties(Material material, VisualEffect visualEffect)
        {
            visualEffect.SetFloat("Guide Strength", material.GetFloat("_GuideStrength"));

            if (material.IsKeywordEnabled("INVERT_DIRECTION_ON"))
            {
                visualEffect.SetBool("Invert Direction", true);
            }
            else
            {
                visualEffect.SetBool("Invert Direction", false);
            }

            visualEffect.SetFloat("Min Value", material.GetFloat("_MinValue"));
            visualEffect.SetFloat("Max Value", material.GetFloat("_MaxValue"));


        }
    }
}