using MySql.Data.MySqlClient;

namespace HOME.Handlers
{
    public class SqlInstance
    { 
        private static MySqlConnection _instance;
        
        public static MySqlConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");
                    _instance.Open();
                }
                return _instance;
            }
        }
    }
}