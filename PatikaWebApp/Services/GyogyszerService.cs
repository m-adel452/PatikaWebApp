using MySql.Data.MySqlClient;                                                                                                                                                                                           
using PatikaWebApp.Models;                                                                                                                                       
using PatikaWebApp.DataManager;                                                                                                                                  
using System.Security.Cryptography.Xml;                                                                    

namespace PatikaWebApp.Services                                                                                                                                  
{
    public class GyogyszerService                                                                                                                                
    {
        public List<Gyogyszer> GetAllVasarlo()                                                                                                                    
        {
            using (MySqlConnection conn = new DBManager().CreateConnection())                                                                                   
            {
                try                                                                                                                                             
                {
                    conn.Open();                                                                                                                                
                    List<Gyogyszer> result = new List<Gyogyszer>();                                                                                                
                    string sql = "SELECT * FROM gyogyszer;";                                                                                                      
                    MySqlCommand comm = new MySqlCommand(sql, conn);                                                                                           
                    MySqlDataReader reader = comm.ExecuteReader();                                                                                              
                    while (reader.Read())                                                                                                                      
                    {                                                                                                                                           
                        Gyogyszer ujGyogyszer = new Gyogyszer();
                        ujGyogyszer.Id = reader.GetInt32("id");
                        ujGyogyszer.Nev = reader.GetString("Nev");
                        ujGyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                        ujGyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                        ujGyogyszer.kepnev = reader.IsDBNull(reader.GetOrdinal("kepnev")) ? "" : reader.GetString("kepnev");
                        result.Add(ujGyogyszer);                                                                                                                  
                    }                                                                                                                                          
                    conn.Close();                                                                                                                           
                    return result;                                                                                                                              
                }                                                                                                                                               
                catch (Exception ex)                                                                                                                            
                {                                                                                                                                               
                    Console.WriteLine(ex.Message);                                                                                                              
                    return new List<Gyogyszer>()                                                                                                                  
                    {
                        new Gyogyszer() { Nev = ex.Message }                                                                                                      
                    };                                                                                                                                          
                }                                                                                                                                               
            }                                                                                                                                                  
        }

        public Gyogyszer GetById(int id)                                                                                                                          
        {
            try                                                                                                                                                
            {
                Gyogyszer result = new Gyogyszer();                                                                                                                 
                using (MySqlConnection conn = new DBManager().CreateConnection())                                                                              
                {
                    conn.Open();                                                                                                                                
                    string sql = "SELECT * FROM gyogyszer WHERE Id=@id;";                                                                                         
                    MySqlCommand cmd = new MySqlCommand(sql, conn);                                                                                             
                    cmd.Parameters.AddWithValue("@id", id);                                                                                                     
                    MySqlDataReader reader = cmd.ExecuteReader();                                                                                              
                    reader.Read();
                    result.Id = reader.GetInt32("id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.IsDBNull(reader.GetOrdinal("kepnev")) ? "" : reader.GetString("kepnev");
                    conn.Close();                                                                                                                               
                }                                                                                                                                               
                return result;                                                                                                                                  
            }                                                                                                                                                   
            catch (Exception ex)                                                                                                                                
            {                                                                                                                                                   
                Gyogyszer hiba = new Gyogyszer();                                                                                                                   
                hiba.Nev = ex.Message;                                                                                                                          
                return hiba;                                                                                                                                    
            }                                                                                                                                                   
        }                                                                                                                                                      
    }
}
