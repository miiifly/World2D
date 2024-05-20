using System;
using System.Collections.Generic;
using World2D.Generator.Data;
using World2D.Generator.Model;
using World2D.Generator.Settings;

namespace World2D.Generator.Space
{
    public class MapGenerator
    {
        private Queue<VisualToRender> _renderQueue;
        public Queue<VisualToRender> RenderQueue => _renderQueue;
        private readonly TileMapData _mapData;
        private LocationsMapData _locationMapData;
        public TileMapData MapData => _mapData;
        public LocationsMapData LocationMapData => _locationMapData;

        private readonly LandModel[] _landBiomes;
        private readonly WaterModel[] _waterBiomes;

        private readonly NoiseMapSetting _landNoiseMapSettings;
        private readonly NoiseMapSetting _waterNoiseMapSettings;

        private LandMapGenerator _landMapGenerator;
        private WaterMapGenerator _waterMapGenerator;
        private LocationGenerator _locationGenerator;

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

            _locationGenerator = new LocationGenerator(_random, _mapData);
            _locationGenerator.GenerateLocations();
            _locationMapData = _locationGenerator.LocationMap;

            VisualGenerator objectGenerator = new VisualGenerator(_random, _mapData, _locationMapData);

            _renderQueue = objectGenerator.Generate();

            foreach (var visual in _locationGenerator.LocationVisualList)
            {
                _renderQueue.Enqueue(visual);
            }

        }
    }
}
