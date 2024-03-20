namespace MvcHtmlInputDemo.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? Gender { get; set; }
        public string? Sports { get; set; }
        public string? City { get; set; }
    }
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? Gender { get; set; }
        public int? CityId { get; set; }
        public bool Cricket { get; set; }
        public bool Kabbdai { get; set; }
        public bool Tenies { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string? ProfilePictureName { get; set; }
    }
    public class AddUserDto
    {
        public string Fullname { get; set; }
        public string? Gender { get; set; }
        public int? CityId { get; set; }
        public bool Cricket { get; set; }
        public bool Kabbdai { get; set; }
        public bool Tenies { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string? ProfilePictureName { get; set; }
    }

    public class UpdateUserdto : AddUserDto
    {
        public int Id { get; set; }
    }
}
