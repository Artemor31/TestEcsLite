using Codebase.View;
using UnityEngine;

namespace Codebase.Data
{
    [CreateAssetMenu(menuName = "Create Configuration", fileName = "Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        [field: SerializeField] public CellView CellViewPrefab { get; private set; }
        [field: SerializeField] public Vector2Int GridSize { get; private set; }
        [field: SerializeField] public Material EvenMaterial { get; private set; }
        [field: SerializeField] public Material NotEvenMaterial { get; private set; }
    }
}