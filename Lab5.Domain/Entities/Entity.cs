namespace Lab5.Domain.Entities
{
    public class Entity
    {
        public int Id { get; init; }
        public string Name { get; set; } = "";
        public string Photo { get; set; } = "empty.png";

        public Entity(string name, string photo)
        {
            Name = name;
            Photo = photo;
        }

        public Entity() { }
    }
}
