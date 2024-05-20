using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Model;

namespace World2D.Generator.Data
{
    public class VisualPreset : MonoBehaviour
    {
        [Header("Parameters")]
        [Range(1,10)]
        [SerializeField]
        private float _minScale;
        [Range(1, 10)]
        [SerializeField]
        private float _maxScale;

        [Header("TilePosition")]
        [Range(0,1f)]
        [SerializeField]
        private float _positionX, _positionY;


        public GameObject Prefab => this.gameObject;
        public float MinScale => _minScale;
        public float MaxScale => _maxScale;
        public float PositionX => _positionX;
        public float PositionY => _positionY;
    }
}
