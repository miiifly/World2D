using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator.Interaction
{
    [CreateAssetMenu(fileName = "InteractPresets", menuName = "World2D/Presets/InteractPresets")]
    public class InteractPresets : ScriptableObject
    {
        [SerializeField]
        private List<InteractObject> _interact = new List<InteractObject>();
        public IEnumerable<InteractObject> Interact => _interact;
    }
}
