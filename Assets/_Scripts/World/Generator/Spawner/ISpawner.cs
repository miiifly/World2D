using System;

namespace World2D.Generator.Spawner
{
    public interface ISpawner<T> where T : IBaseSpawneble
    {
        event Action<T> OnSpawn;
        event Action<T> OnDespawn;
        void ClearSpawnedObjects();
        void Spawn(T spawnPrefab, bool setParent, Action<T> spawnedCallback);
        void Spawn(int spawnTypeID, bool setParent, Action<T> despawnedCallback);
        void Despawn(T despawnPrefab);
    }
}
