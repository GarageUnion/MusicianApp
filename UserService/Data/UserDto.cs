namespace UserService.Data
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string City { get; set; }
        public string? Description { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Media { get; set; }
    }
}
