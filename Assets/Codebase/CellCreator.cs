using Codebase.View;
using UnityEngine;

namespace Codebase
{
    public class CellCreator
    {
        private readonly CellView _prefab;
        private readonly Material _evenMaterial;
        private readonly Material _notEvenMaterial;

        private int _counter;

        public CellCreator(CellView prefab, Material evenMaterial, Material notEvenMaterial)
        {
            _prefab = prefab;
            _evenMaterial = evenMaterial;
            _notEvenMaterial = notEvenMaterial;
        }

        public CellView CreateAt(Vector3 position)
        {
            var cell = Object.Instantiate(_prefab, position, Quaternion.identity);
            cell.GetComponent<MeshRenderer>().material = PickMaterial();
            _counter++;
            return cell;
        }
        public CellView Create()
        {
            var cell = Object.Instantiate(_prefab);
            cell.GetComponent<MeshRenderer>().material = PickMaterial();
            _counter++;
            return cell;
        }

        private Material PickMaterial() => 
            _counter % 2 == 0 ? _evenMaterial : _notEvenMaterial;
    }
}