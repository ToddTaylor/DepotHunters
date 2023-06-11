namespace data.Models
{
    public partial class Railroad : EntityBase
    {
        public Railroad()
        {
            Depot = new HashSet<Depot>();
        }

        public String Name { get; set; }
        public String ReportingMark { get; set; }

        public virtual ICollection<Depot> Depot { get; set; }
    }
}