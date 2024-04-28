using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using World2D.Generator.Data;

namespace World2D.Generator.Noise
{
    public class MapDisplay : MonoBehaviour
    {
        private Tilemap _groundTilemap;
        private Tilemap _waterTilemap;

        private Dictionary<Sprite, Tile> _tileDictionary = new Dictionary<Sprite, Tile>();

        public void Render(Transform parentTransform, TileMapData mapData)
        {
            Grid grid = CreateGrid(parentTransform);
            _groundTilemap = CreateTilemap(grid.transform, "Ground Tilemap");
            _waterTilemap = CreateTilemap(grid.transform, "Water Tilemap");
            DrawTileMap(mapData);
        }

        private void DrawTileMap(TileMapData mapData)
        {
            for (int y = 0; y < mapData.Height; y++)
            {
                for (int x = 0; x < mapData.Width; x++)
                {
                    Data.TileData tile = mapData[x, y];

                    Tile lendTile = GetTileSO(tile.LandModel.Floor);

                    _groundTilemap.SetTile(new Vector3Int(x, y, 0), lendTile);

                    if (tile.WaterModel != null)
                    {
                        Tile waterTile = GetTileSO(tile.WaterModel.Floor);
                        _waterTilemap.SetTile(new Vector3Int(x, y, 0), waterTile);
                    }
                }
            }
        }

        private Tile GetTileSO(Sprite sprite)
        {
            if (!_tileDictionary.TryGetValue(sprite, out Tile tile))
            {
                tile = (Tile)ScriptableObject.CreateInstance("Tile");
                tile.sprite = sprite;
                _tileDictionary.Add(sprite, tile);
            }
            return tile;
        }

        private Grid CreateGrid(Transform parent)
        {
            GameObject gameObject = new GameObject("Grid");
            gameObject.transform.parent = parent;

            Grid grid = gameObject.AddComponent<Grid>();

            return grid;
        }

        private Tilemap CreateTilemap(Transform parent, string name)
        {
            GameObject gameObject = new GameObject(name);
            gameObject.transform.parent = parent;
            gameObject.AddComponent<TilemapRenderer>();

            Tilemap tilemap = gameObject.GetComponent<Tilemap>();

            return tilemap;
        }
    }
}
