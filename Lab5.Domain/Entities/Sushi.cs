namespace Lab5.Domain.Entities
{
    public class Sushi : Entity
    {
        public int Count { get; set; }

        public List<Set> Sets { get; set; } = new();

        public Sushi(string name, int count, IEnumerable<Set> sets, string photo = "empty.png") : base(name, photo)
        {
            Count = count;
            Sets = sets.ToList();
        }

        public Sushi(string name, int count, string photo = "empty.png") : base(name, photo)
        {
            Count = count;
        }

        public Sushi() : base() { }
    }
}
