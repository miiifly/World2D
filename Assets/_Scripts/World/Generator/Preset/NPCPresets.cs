using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator.NPC
{
    [CreateAssetMenu(fileName = "NPCPresets", menuName = "World2D/Preset/NPCPresets")]
    public class NPCPresets : ScriptableObject
    {
        [SerializeField]
        private List<NPCObject> _npc = new List<NPCObject>();
        public IEnumerable<NPCObject> NPC => _npc;
    }
}
