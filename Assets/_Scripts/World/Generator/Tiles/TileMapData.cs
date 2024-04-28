namespace World2D.Generator.Data
{
    public class TileMapData
    {
        private readonly int _width;
        private readonly int _height;

        private TileData[,] _tileMap;

        public int Width => _width;
        public int Height => _height;

        public TileMapData(int width, int height)
        {
            _width = width;
            _height = height;

            SetupMap();
        }

        private void SetupMap()
        {
            _tileMap = new TileData[Width, Height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _tileMap[i, j] = new TileData();
                }
            }
        }

        public TileData this[int x, int y]
        {
            get { return _tileMap[x, y]; }
            set { _tileMap[x, y] = value; }
        }
    }
}
