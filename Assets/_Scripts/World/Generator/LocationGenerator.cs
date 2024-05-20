using System.Collections;
using System.Collections.Generic;
using System;
using World2D.Generator.Data;
using World2D.Generator;
using System.Net.NetworkInformation;
using World2D.Generator.Model;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace World2D
{
    public class LocationGenerator
    {
        private readonly System.Random _random;

        private readonly TileMapData _tileMapData;
        private LocationsMapData _locationsMapData;

        private List<VisualToRender> _locationVisualList = new List<VisualToRender>();
        private RandomSelector _randomSelector;

        private int _minX, _minY;
        private int _maxX, _maxY;

        public LocationsMapData LocationMap => _locationsMapData;
        public List<VisualToRender> LocationVisualList => _locationVisualList;

        public LocationGenerator(System.Random random, TileMapData tileMapData)
        {
            _random = random;
            _tileMapData = tileMapData;

            _randomSelector = new RandomSelector(random);
            _locationsMapData = new LocationsMapData(tileMapData);

            _minX = (int)(tileMapData.Width * 0.05);
            _maxX = (int)(tileMapData.Width * 0.95);
            _minY = (int)(tileMapData.Height * 0.05);
            _maxY = (int)(tileMapData.Height * 0.95);
        }

        public void GenerateLocations()
        {

            for(int i = _minY; i <= _maxY; i++)
            {
                for(int j = _minX; j <= _maxX; j++)
                {
                    var position = new Vector2Int(j, i);

                    if (_tileMapData[j,i].GetBiomeModel() is LandModel landModel &&
                        landModel.Locations.Any() &&
                        _locationsMapData.CanGenerateIn(position)&&
                        _random.Next(100000)/ 100f < landModel.LocationIntensity)
                    {
                        LocationModel locationDataModel = _randomSelector.SelectOption(landModel.Locations, out int maxCount);

                        LocationData location = GenerateArea(locationDataModel, position, landModel.BiomeIdentifier);

                        if(location != null)
                        {
                            GenerateLocationObject(location);
                            _locationsMapData.FillLocation(location);
                        }

                        if (_locationsMapData.LocationsData.Count >= maxCount)
                        {
                            _locationVisualList.Reverse();
                            return;
                        }
                    }
                }
            }
        }

        //TODO: Difical generation with more objects
        private void GenerateLocationObject(LocationData locationData)
        {             
            var positionIndex = _random.Next(locationData.Tiles.Count);             
            var visualObject = locationData.LocationModel.Objects;

            if (visualObject != null)
            {
                VisualToRender visual = new VisualToRender()
                {
                    Prefab = visualObject.Prefab,
                    Position = locationData.Tiles[positionIndex],
                    Scale = visualObject.MaxScale
                };

                _locationVisualList.Add(visual);
            }
        }

        private LocationData GenerateArea(LocationModel locationDataModel, Vector2Int position, int biomeIndex)
        {
            LocationData locationData = new LocationData(locationDataModel);

            var size = _random.Next(locationDataModel.MinSize, locationDataModel.MaxSize);

            if(FindAvailableLocation(position, size, biomeIndex, out var locationPosition))
            {
                for (int y = locationPosition.y; y < locationPosition.y + size; y++)
                {
                    for (int x = locationPosition.x; x < locationPosition.x + size; x++)
                    {
                        var positionTile = new Vector2Int(x, y);

                        if (_locationsMapData.CanGenerateIn(positionTile) && _tileMapData[x, y].IsSameBiome(biomeIndex))
                        {
                            locationData.Tiles.Add(positionTile);
                        }
                    }
                }

                return locationData;
            }

            return null;
        }

        private bool FindAvailableLocation(Vector2Int startPosition, int size, int biomeIndex, out Vector2Int locationPosition)
        {
            for (int y = startPosition.y; y <= startPosition.y + size; y++)
            {
                for (int x = startPosition.x; x <= startPosition.x + size; x++)
                {
                    var position = new Vector2Int(x, y);
                    if (_locationsMapData.IsSpaceAvailable(position, size) && _tileMapData[x,y].IsSameBiome(biomeIndex))
                    {
                        locationPosition = position;
                        return true;
                    }
                }
            }
            locationPosition = Vector2Int.zero;
            return false;
        }
    }
}
