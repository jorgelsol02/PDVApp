using System.Configuration;
using Microsoft.Data.SqlClient;

string connectionString = ConfigurationManager.ConnectionStrings["PDVConnection"].ConnectionString;

SqlConnection conn = new SqlConnection(connectionString);
conn.Open();
// ...


public class Database
{
    private readonly string connectionString = "Server=JORGEOLIVEIRA\\SQLEXPRESS;Database=PDV;Trusted_Connection=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}

