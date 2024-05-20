using System;
using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.NPC;

namespace World2D.Generator.Spawner
{
    public class NPCSpawner : BaseSpawner<NPCObject>
    {
        public NPCSpawner(Transform spawnParent, IEnumerable<NPCObject> spawnables, Action<IEnumerable<NPCObject>> clearAction) : base(spawnParent, spawnables, clearAction)
        {
        }
    }
}
