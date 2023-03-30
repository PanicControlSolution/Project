using SQLite;

namespace Lab5.Domain.Entities {
    [Table("Sets")]
    public class Set : Entity {
        [NotNull]
        public double Cost { get; set; }
        public string? Description { get; set; }
        [NotNull]
        public double Weigth { get; set; }
    }
}
