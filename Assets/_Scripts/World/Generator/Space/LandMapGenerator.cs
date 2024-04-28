using UnityEngine;
using World2D.Generator.Data;
using World2D.Generator.Model;
using World2D.Generator.Noise;
using World2D.Generator.Settings;

namespace World2D.Generator.Space
{
    public class LandMapGenerator
    {
        private readonly LandModel[] _biomes;

        private readonly NoiseMapSetting _landNoiseMapSettings;

        private readonly BaseNoiseGenerator _noiseFilter;

        private readonly float _layerCountInversion;

        public LandMapGenerator(System.Random random, LandModel[] biome, NoiseMapSetting landNoiseMapSetting)
        {
            _biomes = biome;
            _landNoiseMapSettings = landNoiseMapSetting;
            _layerCountInversion = 1f / _biomes.Length;
            _noiseFilter = new BaseNoiseGenerator(random, landNoiseMapSetting);
        }

        public void GenerateLandMap(TileMapData map)
        {
            float[,] landNoiseArray = _noiseFilter.Generate(map.Width, map.Height);

            FindMinMax(landNoiseArray, out var landMin, out var landMax);

            for (int i = 0; i < map.Height; ++i)
            {
                for (int j = 0; j < map.Width; ++j)
                {
                    TileData tile = map[j, i];

                    tile.LandModel = _biomes[(int)(ScaleValue(landNoiseArray[i, j], landMin, landMax, _landNoiseMapSettings) / _layerCountInversion)];
                }
            }
        }

        private void FindMinMax(float[,] noiseMap, out float min, out float max)
        {
            min = float.MaxValue; max = float.MinValue;

            foreach (float value in noiseMap)
            {
                if (value > max)
                    max = value;
                if (value < min)
                    min = value;
            }
        }

        private float ScaleValue(float value, float minValue, float maxValue, NoiseMapSetting noiseMapParameters)
        {
            float result = ((value - minValue) * (noiseMapParameters.MaxValue - noiseMapParameters.MinValue) / (maxValue - minValue) + noiseMapParameters.MinValue);
            return Mathf.Clamp(result, 0, 0.9999999f);
        }
    }
}
