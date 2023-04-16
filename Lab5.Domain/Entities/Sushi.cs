namespace Lab5.Domain.Entities
{
    public class Sushi : Entity
    {
        public int Count { get; set; }

        public List<Set> Sets { get; set; } = new();

        public Sushi(int id, string name, int count, IEnumerable<Set> sets, string photo = "empty.png") : base(id, name, photo)
        {
            Count = count;
            Sets = sets.ToList();
        }

        public Sushi() : base() { }
    }
}
