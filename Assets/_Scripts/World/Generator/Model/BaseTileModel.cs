using System;
using UnityEngine;

namespace World2D.Generator.Model
{
    [Serializable]
    public class BaseTileModel
    {
        [SerializeField]
        private Sprite _floor;
        public Sprite Floor => _floor;
    }
}
