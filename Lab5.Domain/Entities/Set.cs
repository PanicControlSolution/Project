namespace Lab5.Domain.Entities
{
    public class Set : Entity
    {
        public double Cost { get; set; }
        public string? Description { get; set; }
        public double Weight { get; set; }

        public List<Sushi> Sushi { get; set; } = new();

        public Set(int id, double cost, string name, string? description, double weight, string photo = "empty.png")
        {
            Id = id;
            Cost = cost;
            Description = description;
            Weight = weight;
            Name = name;
            Photo = photo;
        }
    }
}
