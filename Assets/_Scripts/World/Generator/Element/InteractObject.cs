using UnityEngine;
using World2D.Generator.Spawner;

namespace World2D.Generator.Interaction
{
    public class InteractObject : MonoBehaviour, IBaseSpawneble
    {
        [SerializeField]
        private InteractType _type;

        GameObject IBaseSpawneble.GameObject => gameObject;

        int IBaseSpawneble.SpawnableTypeID => _type.GetHashCode();

        public enum InteractType
        {
            None = 0,
            Chess = 1
        }
    }
}
