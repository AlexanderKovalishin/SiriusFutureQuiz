using System;
using SiriusFuture.Quiz.Core.Service;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class ServicesInstaller: MonoBehaviour
    {
        [SerializeField] private Timeline _timeline;
        private void Awake()
        {
            ServiceLocator.Register(_timeline);
        }

        private void OnDestroy()
        {
            ServiceLocator.Clear();
        }
    }
}