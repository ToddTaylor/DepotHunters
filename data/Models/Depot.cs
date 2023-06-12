namespace data.Models
{
    public partial class Depot : EntityBase
    {
        public Depot()
        {
            DepotLocation = new HashSet<DepotLocation>();
            Railroad = new HashSet<Railroad>();
        }

        public int? PrecedingDepotId { get; set; }
        public bool? IsRazed { get; set; }
        public bool? IsRelocated { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
        public String? YearErected { get; set; }
        public String? YearRazed { get; set; }

        public virtual DepotPhoto DepotPhoto { get; set; }

        public virtual ICollection<DepotLocation> DepotLocation { get; set; }

        public virtual ICollection<Railroad> Railroad { get; set; }
    }
}