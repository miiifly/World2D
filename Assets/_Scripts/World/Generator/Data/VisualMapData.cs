using UnityEngine;

namespace World2D.Generator.Data
{
    public class VisualMapData : MonoBehaviour
    {
        private readonly VisualType[,] _visualMap;

        private int _width;
        private int _height;

        public int Width => _width;
        public int Height => _height;

        public VisualMapData(int width, int height)
        {
            _width = width;
            _height = height;

            _visualMap = new VisualType[width, height];
        }

        public bool IsOnMap(Vector2Int positon) => positon.x >= 0 && positon.y >= 0 && positon.x < _width && positon.y < _height;

        public bool IsTileEmpty(Vector2Int positon) => _visualMap[positon.x, positon.y] == VisualType.Empty;

        public bool TilesEmpty(Vector2Int leftDown, Vector2Int rightUp)
        {
            for (int i = leftDown.y; i <= rightUp.y; i++)
            {
                for (int j = leftDown.x; j <= rightUp.x; j++)
                {
                    var position = new Vector2Int(i, j);
                    if (!IsOnMap(position) || IsTileEmpty(position))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void FillTile(Vector2Int positon, VisualType visualType)
        {
            if (IsTileEmpty(positon))
            {
                _visualMap[positon.x, positon.y] = visualType;
            }
        }
    }

    public enum VisualType
    {
        Empty = 0,
        Element = 1,
        Rock = 2,
        Flower = 3,
        Tree = 4
    }
}
