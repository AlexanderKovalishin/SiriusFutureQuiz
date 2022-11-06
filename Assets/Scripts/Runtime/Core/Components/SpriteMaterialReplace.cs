using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteMaterialReplace: MonoBehaviour
    {
        [SerializeField] private Material _replace;

        private SpriteRenderer _sprite;
        private Material _origin;
        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _origin = _sprite.material;
        }

        private void OnEnable()
        {
            _sprite.material = _replace;
        }

        private void OnDisable()
        {
            _sprite.material = _origin;
        }
    }
}