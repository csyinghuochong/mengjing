using System.Collections;
using UnityEngine;

/*Sub-component of the main player interaction script, 
  interactive object animation is played by the animator*/

namespace Highlands
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    public class Interactive : MonoBehaviour
    {
        [Tooltip("Interactive object opening sound")]
        [SerializeField] private AudioClip openSound;

        [Tooltip("Interactive object closing sound")]
        [SerializeField] private AudioClip closeSound;

        [SerializeField] private string openAnimationName;
        [SerializeField] private string closeAnimationName;

        [Tooltip("Additional delay in deactivating interaction, added to animation time")]
        [SerializeField] private float interactiveObjectDelayTime;
        [HideInInspector] public bool interactiveObjectOpen = false;

        //Private variables.
        private Animator _interactiveObjectAnimator;
        private AudioSource _interactiveObjectAudioSource;
        private float _InteractiveObjectOpenTime;
        private bool _pauseInteraction;

        private void Awake()
        {
            _interactiveObjectAudioSource = gameObject.GetComponent<AudioSource>();
            _interactiveObjectAnimator = gameObject.GetComponent<Animator>();
            _InteractiveObjectOpenTime = _interactiveObjectAnimator.GetCurrentAnimatorStateInfo(0).length + interactiveObjectDelayTime; //Sum of animation time and additional delay
        }

        //Play an animation and sound, depending on interactive object status
        public void PlayInteractiveAnimation()
        {
            if (!interactiveObjectOpen && !_pauseInteraction)
            {
                _interactiveObjectAnimator.Play(openAnimationName);
                _interactiveObjectAudioSource.clip = openSound;
                interactiveObjectOpen = true;
                _interactiveObjectAudioSource.Play();
                StartCoroutine(PauseInteraction());

            }
            else if (interactiveObjectOpen && !_pauseInteraction)
            {
                _interactiveObjectAudioSource.clip = closeSound;
                _interactiveObjectAnimator.Play(closeAnimationName);
                interactiveObjectOpen = false;
                _interactiveObjectAudioSource.Play();
                StartCoroutine(PauseInteraction());

            }

        }

        //Waiting for object open time, to prevent interactive object from opening/closing again
        private IEnumerator PauseInteraction()
        {
            _pauseInteraction = true;
            yield return new WaitForSeconds(_InteractiveObjectOpenTime);
            _pauseInteraction = false;
        }

    }
}