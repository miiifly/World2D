using System;
using UnityEngine;

namespace World2D.Generator.Model
{
    [Serializable]
    public class PriorityModel<T>
    {
        [SerializeField]
        private int _priority;
        public int Priority => _priority;

        [SerializeField]
        public int _maxCount;
        public int MaxCount => _maxCount;

        [SerializeField]
        private T _model;

        public T Model => _model;

    }
}