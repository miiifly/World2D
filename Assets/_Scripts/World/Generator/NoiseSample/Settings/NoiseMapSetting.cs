using System;
using UnityEngine;

namespace World2D.Generator.Settings
{
    [Serializable]
    public class NoiseMapSetting
    {
        [SerializeField]
        private int _octaves;
        [SerializeField]
        private float _persistance;
        [SerializeField]
        private float _lacunarity;

        [SerializeField]
        private float _minValue;
        [SerializeField]
        private float _maxValue;

        [SerializeField]
        [Range(0f, 1f)]
        private float _target;

        public int Octaves => _octaves;
        public float Persistance => _persistance;
        public float Lacunarity => _lacunarity;
        public float MinValue => _minValue;
        public float MaxValue => _maxValue;
        public float Target => _target;
    }
}
