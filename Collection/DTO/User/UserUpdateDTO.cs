namespace Collection.DTO.User
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;


        public string Surname { get; set; } = null!;


        public int Age { get; set; }
    }
}
