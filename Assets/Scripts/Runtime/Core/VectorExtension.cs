using UnityEngine;

namespace SiriusFuture.Quiz.Core
{
    public static class VectorExtension
    {
        public static Vector3 WithX(this Vector3 p, float x)
        {
            return new Vector3(x, p.y, p.z);
        }

        public static Vector3 WithY(this Vector3 p, float y)
        {
            return new Vector3(p.x, y, p.z);
        }
        
        public static Vector3 WithZ(this Vector3 p, float z)
        {
            return new Vector3(p.x,  p.y, z);
        }

    }
}