using UnityEngine;

namespace GrassMobileShader.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class MobileCanvas : MonoBehaviour
    {
        public static bool W, D, S, A, E, Q, BoostActive;

        /// <summary>
        /// Destroy mobile canvas if it is not a mobile platform
        /// </summary>
        private void Start()
        {
            if (!Application.isMobilePlatform)
            {
                Destroy(gameObject);
            }
            W = false;
            D = false;
            S = false;
            A = false;
            E = false;
            Q = false;
            BoostActive = false;
        }
    }
}
