namespace data.Models
{
    public partial class Depot : EntityBase
    {
        public Depot()
        {
            DepotLocation = new HashSet<DepotLocation>();
            Railroad = new HashSet<Railroad>();
        }

        public virtual DepotPhoto DepotPhoto { get; set; }

        public virtual ICollection<DepotLocation> DepotLocation { get; set; }

        public virtual ICollection<Railroad> Railroad { get; set; }
    }
}