namespace Lab5.Domain.Entities
{
    public class Set : Entity
    {
        public double Cost { get; set; }
        public string? Description { get; set; }
        public double Weight { get; set; }

        public List<Sushi> Sushi { get; set; }

        public Set(int id, double cost, string name, string? description, double weight)
        {
            Id = id;
            Cost = cost;
            Description = description;
            Weight = weight;
            Name = name;
        }
    }
}
