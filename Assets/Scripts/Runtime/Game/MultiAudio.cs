using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Service;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class MultiAudio: MonoBehaviour
    {
        [SerializeField] private float _minDelay = 0f;
        [SerializeField] private float _maxDelay = 0.3f;
        [SerializeField] private int _count = 3;
        
        private AudioSource _audio;
        private Timeline _timeline; // inject

        private void Awake()
        {
            _timeline = ServiceLocator.Locate<Timeline>();
            _audio = GetComponent<AudioSource>();
        }
        
        public void Play()
        {
            for (var i = 0; i < _count; i++)
            {
                var t = (float)i / (_count - 1);
                var delay = Mathf.Lerp(_minDelay, _maxDelay, t);
                _timeline.PosyDelayed(delay, PlayAudio, VoidType.Empty);
            }
        }


        private void PlayAudio(VoidType args)
        {
            _audio.Play();
        }
        
    }
}