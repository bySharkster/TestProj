using SQLite;

namespace TestProj.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }

}
