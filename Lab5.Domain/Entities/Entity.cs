namespace Lab5.Domain.Entities
{
    public class Entity
    {
        public int Id { get; init; }
        public string Name { get; set; } = "";
        public string Photo { get; set; } = "empty.png";

        public Entity(int id, string name, string photo)
        {
            Id = id;
            Name = name;
            Photo = photo;
        }

        public Entity() { }
    }
}
