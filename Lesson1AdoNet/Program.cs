using Microsoft.Data.SqlClient;

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
var category = Console.ReadLine();

try
{
    using var connection = new SqlConnection(connectionString);
    connection.Open();

    var sqlQuery = @"select g.id, g.name, c.name from goods as g
                     join categories as c on c.id = g.id_category
                     where c.name = @category";

    using var sqlCommand = new SqlCommand(sqlQuery, connection);

    var categoryParam = new SqlParameter("@category", category);
    sqlCommand.Parameters.Add(categoryParam);

    var sqlDataReader = sqlCommand.ExecuteReader();
    if (sqlDataReader.HasRows)
    {
        var name1 = sqlDataReader.GetName(0);
        var name2 = sqlDataReader.GetName(1);
        var name3 = sqlDataReader.GetName(2);

        while (sqlDataReader.Read())
        {
            var value1 = sqlDataReader.GetInt32(0);
            var value2 = sqlDataReader.GetString(1);
            var value3 = sqlDataReader.GetString(2);

            Console.WriteLine($"{name1}: {value1}, {name2}: {value2}, {name3}: {value3}");
        }
    }
}
catch
{
    
}