using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator.Spawner
{
    public interface IBaseSpawneble
    {
        GameObject GameObject { get; }

        int SpawnableTypeID { get; }
    }
}
