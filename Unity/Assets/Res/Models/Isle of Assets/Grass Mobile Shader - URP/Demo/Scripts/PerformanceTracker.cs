using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GrassMobileShader.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/265141")]
    public class PerformanceTracker : MonoBehaviour
    {
        [SerializeField]
        private Text text = null;

        /// <summary>
        /// Updating the frame rate display
        /// </summary>
        /// <returns></returns>
        private IEnumerator Start()
        {
            while (true)
            {
                float time = 0f, fps = 0f;
                int count = 0;
                while (time < 0.25f)
                {
                    time += Time.deltaTime;
                    fps += 1f / Time.deltaTime;
                    count++;
                    yield return null;
                }
                text.text = "FPS: " + (int)(fps / count);
                yield return null;
            }
        }
    }
}
