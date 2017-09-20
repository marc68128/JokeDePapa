using SQLite;

namespace JokeDePapa.Domain.Model
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
        public string Sentence { get; set; }
    }
}