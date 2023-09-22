using Codebase.View;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Codebase.Systems
{
    public sealed class FollowCursorSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsCustomInject<CapsuleCreator> _creator = default;
        private GameObject _capsule;
        private Camera _camera;

        public void Init(IEcsSystems systems)
        {
            _camera = Camera.main;
            _capsule = _creator.Value.CreateAt(Vector3.zero);
            _capsule.gameObject.name = "Follower";
        }

        public void Run(IEcsSystems systems)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray, 100);
            foreach (RaycastHit hit in raycastHits)
            {
                if (hit.transform.GetComponent<CellView>())
                {
                    _capsule.SetActive(true);
                    PointFollower(hit);
                }
                else
                {
                    _capsule.SetActive(true);
                }
            }
        }

        private void PointFollower(RaycastHit hit)
        {
            var plane = new Plane(Vector3.up, hit.transform.position);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                hitPoint.y += 1;
                _capsule.transform.position = hitPoint;
            }
        }
    }
}