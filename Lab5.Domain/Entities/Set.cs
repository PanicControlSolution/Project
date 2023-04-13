using SQLite;

namespace Lab5.Domain.Entities
{
    [Table("Sets")]
    public class Set : Entity
    {
        [NotNull]
        public double Cost { get; set; }
        public string? Description { get; set; }
        [NotNull]
        public double Weight { get; set; }

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
