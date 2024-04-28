using UnityEngine;
using World2D.Generator.Data;
using World2D.Generator.Model;
using World2D.Generator.Settings;
using World2D.Generator.Space;

namespace World2D.Generator.Noise
{
    public class GeneratorManager : MonoBehaviour
    {
        [SerializeField]
        private int _mapWidth;
        [SerializeField]
        private int _mapHeight;
        [SerializeField]
        private int _seed;
        [SerializeField]
        private NoiseMapSetting _waterNoiseSettings;
        [SerializeField]
        private NoiseMapSetting _landNoiseSettings;

        [SerializeField]
        private WaterModel[] _waterBiomeModel;
        [SerializeField]
        private LandModel[] _landBiomeModel;


        [SerializeField]
        private bool _autoUpdate;
        [SerializeField]
        private bool _generateRandomSeed;

        public bool AutoUpdate => _autoUpdate;

        private TileMapData _mapData { get; set; }

        [SerializeField]
        private MapDisplay _display;

        private void ResetMap()
        {
            for (int i = transform.childCount - 1; i >= 0; --i)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            _mapData = null;
        }

        public void RandomSeed()
        {
            _seed = Random.Range(int.MinValue, int.MaxValue);
        }

        public void GenerateMap()
        {
            ResetMap();

            if (_generateRandomSeed)
            {
                RandomSeed();
            }

            MapGenerator mapGenerator = new MapGenerator(_seed, _mapWidth, _mapHeight, _waterBiomeModel, _landBiomeModel, _waterNoiseSettings, _landNoiseSettings);

            mapGenerator.Generate();

            _mapData = mapGenerator.MapData;

            MapDisplay mapDisplay = new MapDisplay();

            mapDisplay.Render(transform, _mapData);
        }
    }
}
