using System;
using World2D.Generator.Data;
using World2D.Generator.Model;
using World2D.Generator.Noise;
using World2D.Generator.Settings;

namespace World2D.Generator.Space
{
    public class WaterMapGenerator
    {
        private readonly WaterModel[] _waterBiomes;
        private readonly BaseNoiseGenerator _noiseGenerator;

        public WaterMapGenerator(Random random, WaterModel[] waterBiomes, NoiseMapSetting waterNoiseMapSettings)
        {
            _waterBiomes = waterBiomes;
            _noiseGenerator = new BaseNoiseGenerator(random, waterNoiseMapSettings);
        }

        public void GenerateWaterMap(TileMapData map)
        {
            if (_waterBiomes.Length > 0)
            {
                float[,] waterDeepnessMap = _noiseGenerator.Generate(map.Width, map.Height);

                SetWaterMap(map, waterDeepnessMap);
            }
        }

        private void SetWaterMap(TileMapData map, float[,] waterDeepnessMap)
        {
            for (int i = 0; i < waterDeepnessMap.GetLength(0); i++)
            {
                for (int j = 0; j < waterDeepnessMap.GetLength(1); j++)
                {
                    float deepnessValue = waterDeepnessMap[i, j];
                    map[i, j].WaterDeepness = deepnessValue;
                    map[i, j].WaterModel = CalculateWaterBiom(deepnessValue);
                }
            }
        }

        private WaterModel CalculateWaterBiom(float deepnessValue)
        {
            WaterModel biom = null;
            foreach (var waterBiom in _waterBiomes)
            {
                if (deepnessValue >= waterBiom.Treshold)
                    biom = waterBiom;
                else
                    break;
            }
            return biom;
        }
    }
}
