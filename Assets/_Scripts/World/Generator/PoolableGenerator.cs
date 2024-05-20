using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Data;
using World2D.Generator.Interaction;
using World2D.Generator.NPC;

namespace World2D.Generator.Spawner
{
    public class PoolableGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform _specialParent;
        [SerializeField]
        Transform _patronParent;
        [SerializeField]
        private InteractPresets _interactionPreset;
        [SerializeField]
        private NPCPresets _npcPreset;

        LocationsMapData _locationsMapData;

        private InteractObjectSpawner _interactionSpawner;
        private NPCSpawner _npcSpawner;

        public PoolableGenerator(LocationsMapData locationsMapData)
        {
            _interactionSpawner = new InteractObjectSpawner(_specialParent, _interactionPreset.Interact, DestroySpawnedObjects);

            _npcSpawner = new NPCSpawner(_patronParent, _npcPreset.NPC, DestroySpawnedObjects);

            _locationsMapData = locationsMapData;
        }



        private void DestroySpawnedObjects<T>(IEnumerable<T> objToDestroy) where T : IBaseSpawneble
        {
            foreach (var obj in objToDestroy)
            {
                if (obj?.GameObject != null)
                {
                    Destroy(obj.GameObject);
                }
            }
        }
    }
}
