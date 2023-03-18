using SQLite;

namespace Lab5.Domain.Entities {
    public class Entity {
        [Indexed, PrimaryKey, AutoIncrement]
        public int Id { get; init; }
        [SQLite.NotNull, Unique]
        public string Name { get; set; } = "";
    }
}
