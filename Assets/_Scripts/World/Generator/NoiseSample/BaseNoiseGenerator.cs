using UnityEngine;
using World2D.Generator.Settings;
using Random = System.Random;

namespace World2D.Generator.Noise
{
    public class BaseNoiseGenerator
    {
        private NoiseMapSetting _settings;
        private Random _random;

        private Vector2[] _octaveOffsets;

        private float _offsetX, _offsetY;

        public BaseNoiseGenerator(Random random, NoiseMapSetting settings)
        {
            _settings = settings;
            _random = random;

            SetOctaveOffsets();
        }

        private void SetOctaveOffsets()
        {
            _octaveOffsets = new Vector2[_settings.Octaves];

            //for (int i = 0; i < _settings.Octaves; i++)
            //{
            //    float offsetX = _random.Next(0, 100000);
            //    float offsetY = _random.Next(0, 100000);

            //    _octaveOffsets[i] = new Vector2(offsetX, offsetY);
            //}
            _offsetX = _random.Next(0, 1000000);
            _offsetY = _random.Next(0, 1000000);

        }

        public float[,] Generate(int width, int height)
        {
            float[,] map = new float[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[y,x] = CalculateValue(x,y);
                }
            }
            return map;
        }

        private float CalculateValue(float x, float y)
        {
            float amlitude = 1;
            //float frequency = 1;
            float noiseHeight = 0;

            for (int i = 0; i < _settings.Octaves; i++)
            {
                var sampleX = (x + _offsetX) * amlitude / _settings.Lacunarity;
                var sampleY = (y + _offsetY) * amlitude / _settings.Lacunarity;

                var perlinValue = Mathf.PerlinNoise(sampleX, sampleY);

                noiseHeight += perlinValue * 0.5f / amlitude;

                amlitude *= _settings.Persistance;
                //frequency *= _settings.Lacunarity;
            }

            return Mathf.Pow(noiseHeight, _settings.Target);
        }
    }
}
