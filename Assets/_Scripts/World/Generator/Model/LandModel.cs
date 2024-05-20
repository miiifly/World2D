using System;
using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator.Model
{
    [Serializable]
    public class LandModel : BaseTileModel
    {
        [SerializeField]
        private VisualModels _visualsModel;
        [SerializeField]
        private int _locationIntensity;
        [SerializeField]
        private List<PriorityModel<LocationModel>> _locationModels;

        public VisualModels Visual => _visualsModel;
        public int LocationIntensity => _locationIntensity;
        public List<PriorityModel<LocationModel>> Locations => _locationModels;
        public int BiomeIdentifier => _visualsModel.GetHashCode();

    }
}
