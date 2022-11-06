using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceRunner : MonoBehaviour
    {
        [SerializeField] private bool _stopOnDisable;

        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        private void OnEnable()
        {
            _audioSource.Play();
        }

        private void OnDisable()
        {
            if (!_stopOnDisable) return;
            _audioSource.Stop();
        }
    }
}