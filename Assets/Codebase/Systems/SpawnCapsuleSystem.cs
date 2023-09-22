using Codebase.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Codebase.Systems
{
    public sealed class SpawnCapsuleSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsCustomInject<CapsuleCreator> _capsuleCreator = default;
        private readonly EcsPoolInject<PlaceCommand> _commandsPool = default;
        private readonly EcsPoolInject<CapsuleComponent> _capsulePool = default;
        private readonly EcsFilterInject<Inc<PlaceCommand>> _commandsFilter = default;

        public void Run(IEcsSystems systems)
        {
            foreach (int command in _commandsFilter.Value)
            {
                ref PlaceCommand placeCommand = ref _commandsPool.Value.Get(command);
                GameObject capsuleGameObject = _capsuleCreator.Value.CreateAt(placeCommand.Position);
                _commandsPool.Value.Del(command);

                int newEntity = _world.Value.NewEntity();
                ref CapsuleComponent capsule = ref _capsulePool.Value.Add(newEntity);
                capsule.GameObject = capsuleGameObject;
            }
        }
    }
}