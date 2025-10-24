namespace Learn_DotNetCore_WebApi_v8.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties : used to define relationship between models
        public List<Book> Books { get; set; }
    }
}
