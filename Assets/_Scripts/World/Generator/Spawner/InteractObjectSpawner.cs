using System;
using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Interaction;

namespace World2D.Generator.Spawner
{
    public class InteractObjectSpawner : BaseSpawner<InteractObject>
    {
        public InteractObjectSpawner(Transform spawnParent, IEnumerable<InteractObject> spawnables, Action<IEnumerable<InteractObject>> clearAction) : base(spawnParent, spawnables, clearAction)
        {
        }


    }
}
