namespace data.Models
{
    public partial class DepotPhoto : EntityBase
    {
        public int DepotId { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
        public string YearTaken { get; set; }
        public string Description { get; set; }

        public virtual Depot IdNavigation { get; set; }
    }
}