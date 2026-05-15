namespace Collection.DTO.User
{
    public class UserPatchDTO
    {
        // В отличии от PUT, PATCH ожидает нулевые поля.
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int? Age { get; set; }
    }
}
