namespace UserService.Data
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
