namespace Lab5.Domain.Entities
{
    public class Sushi : Entity
    {
        public int Count { get; set; }

        public List<Set> Sets { get; set; }

        public Sushi(int id, string name, int count, IEnumerable<Set> sets, string photo = "empty.png")
        {
            Id = id;
            Count = count;
            Name = name;
            Sets = sets.ToList();
            Photo = photo;
        }
    }
}
