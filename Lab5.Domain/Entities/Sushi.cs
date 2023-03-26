using SQLite;

namespace Lab5.Domain.Entities
{
    [Table("Sushi")]
    public class Sushi : Entity
    {
        [NotNull]
        public int Count { get; set; }
        [NotNull]
        public int SetId { get; init; }

        public Sushi(int id, string name, int count, int setid)
        {
            Id = id;
            Count = count;
            Name = name;
            SetId = setid;
        }
    }
}
