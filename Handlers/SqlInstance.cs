using MySql.Data.MySqlClient;

namespace HOME.Handlers
{
    public class SqlInstance
    {
        public static MySqlConnection Instance
        {
            get
            {
                var instance =
                    new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");
                instance.Open();

                return instance;
            }
        }
    }
}