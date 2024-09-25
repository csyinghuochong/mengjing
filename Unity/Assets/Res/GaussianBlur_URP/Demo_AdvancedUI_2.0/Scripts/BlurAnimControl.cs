using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DAUI2
{ 

    [RequireComponent(typeof(Image))]
    public class BlurAnimControl : MonoBehaviour
    {
        [Range(0.0f, 1.0f)]
        public float BlurScale = 0;

        [Range(0.0f, 2.0f)]
        public float Lightness = 0.0f;

        [Range(-10.0f, 10.0f)]
        public float Saturation = 1.0f;

        private Material material;


        // Start is called before the first frame update
        void Start()
        {
            material = GetComponent<Image>().material;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            material.SetInt("_BlurScale", (int)(BlurScale * 100.0));
            material.SetFloat("_Lightness", Lightness);
            material.SetFloat("_Saturation", Saturation);
       
        }
    }
}
