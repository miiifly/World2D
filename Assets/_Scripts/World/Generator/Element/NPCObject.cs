using UnityEngine;
using World2D.Generator.Spawner;

namespace World2D.Generator.NPC
{
    public class NPCObject : MonoBehaviour, IBaseSpawneble
    {
        [SerializeField]
        private NPCType _type;

        GameObject IBaseSpawneble.GameObject => gameObject;

        int IBaseSpawneble.SpawnableTypeID => _type.GetHashCode();

        public enum NPCType
        {
            None = 0,
            Clasic = 1
        }
    }
}
