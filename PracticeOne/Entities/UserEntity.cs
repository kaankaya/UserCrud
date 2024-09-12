namespace PracticeOne.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
