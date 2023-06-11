namespace data.Models
{
    public abstract partial class EntityBase
    {
        public int Id { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}