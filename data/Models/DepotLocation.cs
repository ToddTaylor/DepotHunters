namespace data.Models
{
    public partial class DepotLocation : EntityBase
    {
        public String City { get; set; }
        public String County { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public String State { get; set; }
        public int DepotId { get; set; }

        public virtual Depot Depot { get; set; }
    }
}