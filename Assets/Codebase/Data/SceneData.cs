using UnityEngine;

namespace Codebase.Data
{
    public class SceneData : MonoBehaviour
    {
        [field: SerializeField] public Vector3 StartPoint { get; private set; }
    }
}