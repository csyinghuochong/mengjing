using UnityEngine;

namespace Assets.Scripts.Com.Game.Mono
{
    public class EffectScale : MonoBehaviour 
    {

	    // Use this for initialization
        public enum ScaleMode
        {
            TRANSFORM,
            PS_START_SIZE
        }
        public float scaleValue = 1;
        public ScaleMode scaleMode = ScaleMode.TRANSFORM;
    }
}
