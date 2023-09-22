using Codebase.Components;
using Codebase.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Codebase.Systems
{
    public sealed class GridInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<CellCreator> _cellCreator = default;
        private readonly EcsCustomInject<Configuration> _config = default;
        private readonly EcsCustomInject<SceneData> _sceneData = default;
        readonly EcsPoolInject<CellComponent> _cellPool = default;

        public void Init(IEcsSystems systems)
        {
            int gridSizeX = _config.Value.GridSize.x;
            int gridSizeY = _config.Value.GridSize.y;

            EcsWorld world = systems.GetWorld();
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    int entity = world.NewEntity();
                    ref CellComponent cell = ref _cellPool.Value.Add(entity);
                    cell.View = _cellCreator.Value.CreateAt(NextPosition(i,j));
                }
            }
        }

        private Vector3 NextPosition(int i, int j)
        {
            Vector3 startPoint = _sceneData.Value.StartPoint;
            startPoint.x += i * 1;
            startPoint.z += j * 1;
            
            return startPoint;
        }
    }
}