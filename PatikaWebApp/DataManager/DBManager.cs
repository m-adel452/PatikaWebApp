using MySql.Data.MySqlClient;                                                                   
namespace PatikaWebApp.DataManager
{
    public class DBManager                                                                      
    {
        string connectionString =                                                               
            "Server=localhost;" +                                                               
            "Database=patika;" +                                                        
            "User = root;" +                                                                    
            "Password = ;";                                                                     

        public MySqlConnection CreateConnection()                                                       
        {
            MySqlConnection connection = new MySqlConnection(connectionString);                 
            return connection;                                                                  
        }
    }
}