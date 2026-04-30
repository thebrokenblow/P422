using Microsoft.Data.SqlClient;

namespace Lesson5.Model;

public class ProductRepository
{
    public static List<Product> GetProduct()
    {
        var products = new List<Product>();
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        try
        {
 
            string password = "'' or 1 = 1";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sqlQuery = @$"select * from users where password = {password}";

            using var sqlCommand = new SqlCommand(sqlQuery, connection);
            var sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    var product = new Product
                    {
                        Id = sqlDataReader.GetInt32(0),
                        Name = sqlDataReader.GetString(1),
                        Category = sqlDataReader.GetString(2),
                        Price = sqlDataReader.GetDecimal(3),
                    };
                    products.Add(product);
                }
            }
        }
        catch
        {

        }

        return products;
    }
}
