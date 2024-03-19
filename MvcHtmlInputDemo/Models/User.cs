namespace MvcHtmlInputDemo.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? Gender { get; set; }
        public int? CityId { get; set; }
        public bool? Cricket { get; set; }
        public bool? Kabbdai { get; set; }
        public bool? Tenies { get; set; }
        public byte?[] ProfilePicture { get; set; }
        public string? ProfilePictureName { get; set; }        
    }
}