using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Data;
using World2D.Generator.Model;

namespace World2D.Generator
{
    public class VisualGenerator
    {
        private readonly System.Random _random;

        private readonly TileMapData _tileMapData;
        private readonly LocationsMapData _locationsMapData;
        private readonly VisualMapData _visualMapData;

        private readonly RandomSelector _randomSelector;

        private readonly Queue<VisualToRender> _visualQueue;

        public VisualGenerator(System.Random random, TileMapData tileMapData, LocationsMapData locationsMapData)
        {
            _random = random;
            _tileMapData = tileMapData;
            _locationsMapData = locationsMapData;

            _visualMapData = new VisualMapData(tileMapData.Width, tileMapData.Height);
            _randomSelector = new RandomSelector(random);

            _visualQueue = new Queue<VisualToRender>();
        }

        public Queue<VisualToRender> Generate()
        {
            GenerateObjects(VisualType.Tree);
            GenerateObjects(VisualType.Flower);
            GenerateObjects(VisualType.Element);
            GenerateObjects(VisualType.Rock);

            return _visualQueue;
        }

        private void GenerateObjects(VisualType visualType)
        {
            List<VisualToRender> visuals = new List<VisualToRender>();
            for (int i = 0; i < _tileMapData.Height; i++)
            {
                for (int j = 0; j < _tileMapData.Width; j++)
                {
                    var position = new Vector2Int(j, i);

                    if (_visualMapData.IsTileEmpty(position) && _tileMapData[j, i].GetBiomeModel() is LandModel landModel &&
                        _random.Next(10000) / 100f < GetVisualIntensity(visualType, landModel) && _locationsMapData.CanGenerateIn(position))
                    {
                        if (GetVisualData(visualType, landModel, out var visualData, out int maxCount))
                        {
                            VisualToRender visualToRender = new VisualToRender()
                            {
                                Prefab = visualData.Prefab,
                                Position = position + new Vector2(visualData.PositionX, visualData.PositionY),
                                Scale = _random.Next((int)(visualData.MinScale * 100), (int)(visualData.MaxScale * 100)) / 100f
                            };

                            visuals.Add(visualToRender);
                            _visualMapData.FillTile(position, visualType);
                        }
                    }
                }
            }
            CreateQueueRender(visuals);
        }

        private void CreateQueueRender(List<VisualToRender> visuals)
        {
            visuals.Sort((a, b) => b.Position.y.CompareTo(a.Position.y)); // Sort by y position

            foreach (var visual in visuals)
            {
                _visualQueue.Enqueue(visual);
            }
        }

        private bool GetVisualData(VisualType visualType, LandModel landModel, out VisualPreset visualData, out int maxCount)
        {

            switch (visualType)
            {
                case VisualType.Tree:
                    visualData = _randomSelector.SelectOption(landModel.Visual.Tree, out maxCount);
                    break;
                case VisualType.Flower:
                    visualData = _randomSelector.SelectOption(landModel.Visual.Flower, out maxCount);
                    break;
                case VisualType.Element:
                    visualData = _randomSelector.SelectOption(landModel.Visual.Static, out maxCount);
                    break;
                case VisualType.Rock:
                    visualData = _randomSelector.SelectOption(landModel.Visual.Rock, out maxCount);
                    break;
                default:
                    maxCount = 0;
                    visualData = null;
                    break;
            }

            return true;
        }
        private float GetVisualIntensity(VisualType visualType, LandModel landModel)
        {
            var intensity = 0f;
            switch (visualType)
            {
                case VisualType.Tree:
                    intensity = landModel.Visual.TreeIntensity;
                    break;
                case VisualType.Flower:
                    intensity = landModel.Visual.FlowerIntensity;
                    break;
                case VisualType.Element:
                    intensity = landModel.Visual.StaticIntensity;
                    break;
                case VisualType.Rock:
                    intensity = landModel.Visual.RockIntensity;
                    break;
            }

            return intensity;
        }
    }
    public class VisualToRender
    {
        public GameObject Prefab { get; set; }
        public Vector2 Position { get; set; }
        public float Scale { get; set; }
    }
}


