using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using World2D.Generator.Data;
using World2D.Generator.Model;
using UnityEngine;

namespace World2D.Generator
{
    public class RandomSelector
    {
        private System.Random _random;
        public RandomSelector(System.Random random)
        {
            _random = random;
        }

        public T SelectOption<T>(List<PriorityModel<T>> prefabModels, out int maxCount)
        {
            var totalPriority = prefabModels.Sum(x => x.Priority);
            var randomNumber = _random.Next(0, totalPriority);
            var index = -1;
            var currentValue = 0;

            do
            {
                index++;
                currentValue += prefabModels[index].Priority;
            }
            while (currentValue < randomNumber);

            maxCount = prefabModels[index].MaxCount;
            return prefabModels[index].Model;
        }
    }
}
