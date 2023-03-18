using SQLite;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Domain.Entities {
    [Table("Sets")]
    public class Set : Entity {
        [SQLite.NotNull]
        public double Cost { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [SQLite.NotNull]
        public double Weigth { get; set; }
    }
}
