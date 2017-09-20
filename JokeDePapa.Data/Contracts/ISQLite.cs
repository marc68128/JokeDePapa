using SQLite;

namespace JokeDePapa.Data.Contracts
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}