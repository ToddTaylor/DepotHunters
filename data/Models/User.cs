namespace data.Models
{
    public partial class User : EntityBase
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}