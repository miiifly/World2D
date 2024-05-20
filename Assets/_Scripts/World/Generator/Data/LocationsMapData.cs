using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace World2D.Generator.Data
{
    public class LocationsMapData
    {
        private int _width;
        private int _height;

        private readonly LocationTileData[,] _locationsTiles;
        private List<LocationData> _locationsData;

        public int Width => _width;
        public int Height => _height;

        public List<LocationData> LocationsData => _locationsData;

        public LocationsMapData(TileMapData tileMap)
        {
            _width = tileMap.Width;
            _height = tileMap.Height;

            _locationsData = new List<LocationData>();
            _locationsTiles = new LocationTileData[tileMap.Height, tileMap.Width];
            SetBlockTiles(tileMap);
        }

        private void SetBlockTiles(TileMapData tileMap)
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _locationsTiles[i, j] = new LocationTileData(tileMap[i, j].IsWaterBiom ? LocationTileType.Water : LocationTileType.Empty);
                }
            }
        }

        public void FillLocation(LocationData locationData)
        {
            _locationsData.Add(locationData);

            foreach (Vector2Int tilePosition in locationData.Tiles)
            {
                _locationsTiles[tilePosition.x, tilePosition.y].LocationTileType = LocationTileType.Location;
                _locationsTiles[tilePosition.x, tilePosition.y].SetLocation(locationData);
            }
        }

        public bool IsSpaceAvailable(Vector2Int startPosition, int size)
        {
            for (int i = startPosition.y; i < startPosition.y + size; i++)
            {
                for (int j = startPosition.x; j < startPosition.x + size; j++)
                {
                    var position = new Vector2Int(j, i);

                    if (!IsValidTile(position) || !CanGenerateIn(position))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanGenerateIn(Vector2Int position) => _locationsTiles[position.x, position.y].LocationTileType == LocationTileType.Empty;

        public bool IsValidTile(Vector2Int position) => position.x >= 0 && position.x < _width && position.y >= 0 && position.y < _height;

        public LocationData GetTileLocation(Vector2Int position) => _locationsTiles[position.x, position.y].LocationData;

        }
    }
