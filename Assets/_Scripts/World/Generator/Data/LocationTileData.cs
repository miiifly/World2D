namespace World2D.Generator.Data
{
    public class LocationTileData
    {
        private LocationTileType _locationTileType;
        private LocationData _locationData;

        public LocationTileType LocationTileType 
        {
            get { return _locationTileType; }
            set { _locationTileType = value; }       
        }

        public LocationData LocationData => _locationData;

        public LocationTileData(LocationTileType locationTileType)
        {
            _locationTileType = locationTileType;
        }

        public void SetLocation(LocationData locationData)
        {
            _locationData = locationData;
        }
    }

    public enum LocationTileType
    {
        Empty = 0,
        Water = 1,
        Location = 2
    }
}
