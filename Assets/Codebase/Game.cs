using Codebase.Data;
using Codebase.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Codebase
{
    sealed class Game : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private Configuration _config;

        private EcsSystems _systems;

        void Start()
        {
            var world = new EcsWorld();
            _systems = new EcsSystems(world);

            var cellCreator = new CellCreator(_config.CellViewPrefab, _config.EvenMaterial, _config.NotEvenMaterial);
            var capsuleCreator = new CapsuleCreator();

            _systems.Add(new GridInitSystem())
                    .Add(new GridSubscribeSystem())
                    .Add(new FollowCursorSystem())
                    .Add(new SpawnCapsuleSystem())
                    .Inject(_config)
                    .Inject(_sceneData)
                    .Inject(cellCreator)
                    .Inject(capsuleCreator)
                    .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            _systems?.Destroy();

            _systems?.GetWorld()
                    ?.Destroy();

            _systems = null;
        }
    }
}