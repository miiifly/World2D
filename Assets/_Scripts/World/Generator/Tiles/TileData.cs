using World2D.Generator.Model;

namespace World2D.Generator.Data
{
    public class TileData
    {
        public LandModel LandModel { get; set; }
        public WaterModel WaterModel { get; set; }

        public float WaterDeepness { get; set; }

        public bool IsWaterBiom => WaterModel != null;
        public BaseTileModel GetBiomeModel() => IsWaterBiom ? WaterModel : LandModel;
        public bool IsSameBiome(int tileIndex) => this.LandModel.BiomeIdentifier == tileIndex;
    }
}
