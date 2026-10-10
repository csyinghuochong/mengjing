using UnityEngine;
using System.Collections;
using System.Linq;

namespace KyeomsFX
{
    public class AnimationLoopingControl : MonoBehaviour
    {
        public Animation animationComponent;
        public float[] animationDurations;

        private string[] animationNames;
        private Coroutine animationCoroutine;

        private void OnEnable()
        {
            StartAnimationSequence();
        }

        private void OnDisable()
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
                animationCoroutine = null;
            }
        }

        private void StartAnimationSequence()
        {
            if (animationComponent == null)
            {
                animationComponent = GetComponent<Animation>();
            }

            if (animationComponent != null)
            {
                animationNames = animationComponent.Cast<AnimationState>()
                    .Select(state => state.name)
                    .ToArray();

                if (animationNames.Length > 0)
                {
                    animationCoroutine = StartCoroutine(PlayAnimationsSequentially());
                }
                else
                {
                    Debug.LogError("No animation clips found in the Animation component!");
                }
            }
            else
            {
                Debug.LogError("Animation component is missing!");
            }
        }

        private IEnumerator PlayAnimationsSequentially()
        {
            for (int i = 0; i < animationNames.Length; i++)
            {
                animationComponent.Play(animationNames[i]);

                if (i < animationDurations.Length)
                {
                    yield return new WaitForSeconds(animationDurations[i]);
                }
                else
                {
                    yield return new WaitForSeconds(animationComponent.GetClip(animationNames[i]).length);
                }
            }

            gameObject.SetActive(false);
        }
    }
}