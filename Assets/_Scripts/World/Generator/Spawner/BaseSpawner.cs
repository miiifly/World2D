using System;
using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator.Spawner
{
    public class BaseSpawner<T> : ISpawner<T> where T : IBaseSpawneble
    {
        event Action<T> ISpawner<T>.OnSpawn
        {
            add { _onSpawn += value; }
            remove { _onSpawn -= value; }
        }
        event Action<T> ISpawner<T>.OnDespawn
        {
            add { _onDespawn += value; }
            remove { _onDespawn -= value; }
        }

        private Action<T> _onSpawn;
        private Action<T> _onDespawn;
        private List<T> _spawnedObjects = new List<T>();

        private IEnumerable<T> _spawnables;

        protected readonly Transform _spawnParent;

        private readonly Action<IEnumerable<T>> _clearAction;

        public BaseSpawner(Transform spawnParent,
            IEnumerable<T> spawnables,
            Action<IEnumerable<T>> clearAction)
        {
            _spawnParent = spawnParent;
            _spawnables = spawnables;
            _clearAction = clearAction;
        }

        void ISpawner<T>.ClearSpawnedObjects()
        {
            foreach (var despawn in _spawnedObjects)
            {
                _onDespawn?.Invoke(despawn);
            }
            _clearAction?.Invoke(_spawnedObjects);
            _spawnedObjects.Clear();
        }

        void ISpawner<T>.Despawn(T despawnPrefab)
        {
            _onDespawn?.Invoke(despawnPrefab);
            _clearAction?.Invoke(new List<T> { despawnPrefab });
            _spawnedObjects.Remove(despawnPrefab);
        }

        void ISpawner<T>.Spawn(T spawnPrefab, bool setParent, Action<T> spawnedCallback) => Spawn(spawnPrefab, setParent, spawnedCallback);


        void ISpawner<T>.Spawn(int spawnTypeID, bool setParent, Action<T> spawnedCallback) => Spawn(FindInPreset(spawnTypeID), setParent, spawnedCallback);

        private T FindInPreset(int spawnTypeID)
        {
            foreach (var spanable in _spawnables)
            {
                if (spanable.SpawnableTypeID == spawnTypeID)
                {
                    return spanable;
                }
            }
            return default;
        }

        protected virtual void Spawn(T spawnableComponent, bool setParent, Action<T> spawnedCallback)
        {
            var go = GameObject.Instantiate(spawnableComponent.GameObject);
            var spawnable = go.GetComponent<T>();
            _spawnedObjects.Add(spawnable);
            if (setParent)
            {
                go.transform.SetParent(_spawnParent, false);
            }
            spawnedCallback?.Invoke(spawnable);
            _onSpawn?.Invoke(spawnable);
        }
    }
}
