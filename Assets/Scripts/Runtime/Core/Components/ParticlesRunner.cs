using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticlesRunner: MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            _particleSystem.Play();
        }

        private void OnDisable()
        {
            _particleSystem.Stop();
        }
    }
}