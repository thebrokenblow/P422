using Microsoft.Data.SqlClient;

ExampleExecuteScalar();
ExampleInsert();




void ExampleExecuteScalar()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
    
    using var connection = new SqlConnection(connectionString);
    connection.Open();
    
    var query = "select COUNT(*) from goods";
    
    using var sqlCommand = new SqlCommand(query, connection);
    var result = (int)sqlCommand.ExecuteScalar();
    
    Console.WriteLine(result);
}

void ExampleUpdate()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    using var connection = new SqlConnection(connectionString);
    connection.Open();

    var query = @"UPDATE goods
                  set name = @name, description = @description, price = @price, category = @category;
                  where id = @id";

    using var sqlCommand = new SqlCommand(query, connection);
    sqlCommand.Parameters.AddWithValue("@name", "IPhone");
    sqlCommand.Parameters.AddWithValue("@description", "Крутой телефон");
    sqlCommand.Parameters.AddWithValue("@price", 1000);
    sqlCommand.Parameters.AddWithValue("@category", "Телефон");
    sqlCommand.Parameters.AddWithValue("@id", 1);

    sqlCommand.ExecuteNonQuery();
}

void ExampleDelete()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    using var connection = new SqlConnection(connectionString);
    connection.Open();

    var query = @"DELETE FROM goods where id = @id";

    using var sqlCommand = new SqlCommand(query, connection);
    sqlCommand.Parameters.AddWithValue("@id", 12);

    sqlCommand.ExecuteNonQuery();
}


void ExampleInsert()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=P422Shop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    using var connection = new SqlConnection(connectionString);
    connection.Open();

    var query = @"INSERT INTO goods (name, descriptoion, price, category) 
                  VALUES (@name, @description, @price, @category);";

    using var sqlCommand = new SqlCommand(query, connection);
    sqlCommand.Parameters.AddWithValue("@name", "IPhone");
    sqlCommand.Parameters.AddWithValue("@description", "Крутой телефон");
    sqlCommand.Parameters.AddWithValue("@price", 1000);
    sqlCommand.Parameters.AddWithValue("@category", "Телефон");

    sqlCommand.ExecuteNonQuery();
}