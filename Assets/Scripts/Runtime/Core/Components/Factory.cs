using UnityEngine;

namespace SiriusFuture.Quiz.Core.Components
{
    public class Factory<T> : MonoBehaviour where T: MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private T _prototype;

        public T Create()
        {
            var instance = Instantiate(_prototype, _parent);
            if (instance is IFactoryCreteInstanceListener listener)
            {
                listener.OnFactoryCreteInstance();
            }
            return instance;
        }
    }
}