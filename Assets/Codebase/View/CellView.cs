using System;
using UnityEngine;

namespace Codebase.View
{
    public class CellView : MonoBehaviour
    {
        public event Action<CellView> Clicked;
        [field: SerializeField] public Transform UnitPivot { get; private set; }

        public void OnMouseDown() => 
            Clicked?.Invoke(this);
    }
}