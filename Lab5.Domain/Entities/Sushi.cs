using SQLite;

namespace Lab5.Domain.Entities {
    [Table("Sushi")]
    public class Sushi : Entity {
        [NotNull]
        public int Count { get; set; }
        [NotNull]
        public int SetId { get; init; }
    }
}
