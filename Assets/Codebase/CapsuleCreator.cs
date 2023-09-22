using UnityEngine;

namespace Codebase
{
    public class CapsuleCreator
    {
        public GameObject CreateAt(Vector3 position)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            capsule.transform.position = position;
            capsule.transform.localScale = Vector3.one / 2;
            return capsule;
        }
    }
}