using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Data;

namespace World2D.Generator.Model
{
    [CreateAssetMenu(fileName = "LocationModel", menuName = "World2D/Model/LocationModel")]
    public class LocationModel : ScriptableObject
    {
        [Range(1, 5f)]
        [SerializeField]
        private int _minSize;
        [Range(5,10f)]
        [SerializeField]
        private int _maxSize;

        [SerializeField]
        private VisualPreset _objects;

        public int MinSize => _minSize;
        public int MaxSize => _maxSize;

        public VisualPreset Objects => _objects;
    }
}
