using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
    public class TranslucentImageSet: MonoBehaviour
    {
        void OnEnable()
        {
            this.GetComponent<TranslucentImage>().source = Camera.main.GetComponent<TranslucentImageSource>();
        }
    }
}