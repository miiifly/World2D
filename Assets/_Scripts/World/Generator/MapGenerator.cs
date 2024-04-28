using System;
using World2D.Generator.Data;
using World2D.Generator.Model;
using World2D.Generator.Settings;

namespace World2D.Generator.Space
{
    public class MapGenerator
    {
        private readonly TileMapData _mapData;
        public TileMapData MapData => _mapData;

        private readonly LandModel[] _landBiomes;
        private readonly WaterModel[] _waterBiomes;

        private readonly NoiseMapSetting _landNoiseMapSettings;
        private readonly NoiseMapSetting _waterNoiseMapSettings;

        private LandMapGenerator _landMapGenerator;
        private WaterMapGenerator _waterMapGenerator;

        private readonly Random _random;

        public MapGenerator(int seed, int width, int height, WaterModel[] waterBiome, LandModel[] groundBiome, NoiseMapSetting waterNoiseMapSettings, NoiseMapSetting groundNoiseMapSettings)
        {
            _landBiomes = groundBiome;
            _waterBiomes = waterBiome;
            _waterNoiseMapSettings = waterNoiseMapSettings;
            _landNoiseMapSettings = groundNoiseMapSettings;

            _random = new Random(seed);
            _mapData = new TileMapData(width, height);
        }

        public void Generate()
        {
            _landMapGenerator = new LandMapGenerator(_random, _landBiomes, _landNoiseMapSettings);
            _landMapGenerator.GenerateLandMap(_mapData);

            _waterMapGenerator = new WaterMapGenerator(_random, _waterBiomes, _waterNoiseMapSettings);
            _waterMapGenerator.GenerateWaterMap(_mapData);
        }
    }
}
