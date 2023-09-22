using Codebase.Components;
using Codebase.View;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Codebase.Systems
{
    public sealed class GridSubscribeSystem : IEcsInitSystem
    {
        private readonly EcsPoolInject<CellComponent> _cellsPool = default;
        private readonly EcsPoolInject<PlaceCommand> _commandsPool = default;
        private readonly EcsFilterInject<Inc<CellComponent>> _cellsFilter = default;
        private EcsWorld _world;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            foreach (int cell in _cellsFilter.Value)
            {
                ref CellComponent cellComponent = ref _cellsPool.Value.Get(cell);
                cellComponent.View.Clicked += ViewOnClicked;
            }
        }

        private void ViewOnClicked(CellView cellView)
        {
            cellView.Clicked -= ViewOnClicked;
            
            int newEntity = _world.NewEntity();
            ref PlaceCommand command = ref _commandsPool.Value.Add(newEntity);
            command.Position = cellView.UnitPivot.position;
        }
    }
}