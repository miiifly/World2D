using System.Collections.Generic;
using UnityEngine;
using World2D.Generator.Model;

namespace World2D.Generator.Data
{
    public class LocationData
    {
        private LocationModel _locationModel;
        public LocationModel LocationModel => _locationModel;


        public List<Vector2Int> Tiles { get; set; } = new List<Vector2Int>();

        public List<VisualToRender> BigObjects { get; } = new List<VisualToRender>();
        public List<VisualToRender> Objects { get; } = new List<VisualToRender>();

        public LocationData(LocationModel locationModel)
        {
            _locationModel = locationModel;
        }
    }
}
