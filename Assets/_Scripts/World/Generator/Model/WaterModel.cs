using System;
using UnityEngine;

namespace World2D.Generator.Model
{
    [Serializable]
    public class WaterModel : BaseTileModel
    {
        [SerializeField]
        private float _treshold;
        public float Treshold => _treshold;
    }
}
