namespace School.Domain.Entity
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public CategoryEntity(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
