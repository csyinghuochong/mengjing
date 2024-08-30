using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Highlands
{
    public class SoundGroup : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClipps;
        [SerializeField] private AudioSource[] audioSources;
        private AudioSource _randomSource;

        public void PlayRandomSound()
        {
            _randomSource = audioSources[Random.Range(0, audioSources.Length)];
            _randomSource.clip = audioClipps[Random.Range(0, audioClipps.Length)];
            _randomSource.Play();
        }

    }
}
