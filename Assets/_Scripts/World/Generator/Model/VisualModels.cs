using System;
using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Data;

namespace World2D.Generator.Model
{
    [Serializable]
    public class VisualModels
    {
        [SerializeField]
        private float _staticIntensity;
        [SerializeField]
        private List<PriorityModel<VisualPreset>> _static;
        [SerializeField]
        private float _treeIntensity;
        [SerializeField]
        private List<PriorityModel<VisualPreset>> _tree;
        [SerializeField]
        private float _flowerIntensity;
        [SerializeField]
        private List<PriorityModel<VisualPreset>> _flower;
        [SerializeField]
        private float _rockIntensity;
        [SerializeField]
        private List<PriorityModel<VisualPreset>> _rock;

        public List<PriorityModel<VisualPreset>> Tree => _tree;
        public List<PriorityModel<VisualPreset>> Flower => _flower;
        public List<PriorityModel<VisualPreset>> Static => _static;
        public List<PriorityModel<VisualPreset>> Rock => _rock;
        public float StaticIntensity => _staticIntensity;
        public float TreeIntensity => _treeIntensity;
        public float FlowerIntensity => _flowerIntensity;
        public float RockIntensity => _rockIntensity;
    }
}
