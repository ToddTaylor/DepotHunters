namespace data.Models
{
    public partial class DepotLocation : EntityBase
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int DepotId { get; set; }

        public virtual Depot Depot { get; set; }
    }
}