using Microsoft.Data.SqlClient;
using System.Data;

Example3();

void Example1() 
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
    var connection = new SqlConnection(connectionString);
    try
    {
        connection.Open();
        Console.WriteLine("Подключение открыто");
    }
    catch (SqlException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Подключение закрыто...");
        }
    }
    Console.WriteLine("Программа завершила работу.");
    Console.Read();
}

void Example2()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        var command = new SqlCommand
        {
            CommandText = "CREATE DATABASE adonetdb",
            Connection = connection
        };

        var count = command.ExecuteNonQuery();
    }
}

void Example3()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    string sqlExpression = "SELECT * FROM Users";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) // если есть данные
        {
            // выводим названия столбцов
            string columnName1 = reader.GetName(0);
            string columnName2 = reader.GetName(1);
            string columnName3 = reader.GetName(2);

            Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

            while (reader.Read()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                object name = reader.GetValue(2);
                object age = reader.GetValue(1);

                Console.WriteLine($"{id} \t{name} \t{age}");
            }
        }

        reader.Close();
    }
    Console.Read();
}

void Example4()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    string sqlExpression = "SELECT * FROM Users";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        SqlCommand command = new SqlCommand(sqlExpression, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);

                Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(2);
                    int age = reader.GetInt32(1);

                    Console.WriteLine($"{id} \t{name} \t{age}");
                }
            }
        }
    }
    Console.Read();
}

void Example5()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    string sqlExpression = "SELECT COUNT(*) FROM Users";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();

        SqlCommand command = new SqlCommand(sqlExpression, connection);
        object count = command.ExecuteScalar();

        command.CommandText = "SELECT MIN(Age) FROM Users";
        object minAge = command.ExecuteScalar();

        command.CommandText = "SELECT AVG(Age) FROM Users";
        object avgAge = command.ExecuteScalar();

        Console.WriteLine($"В таблице {count} объектa(ов)");
        Console.WriteLine($"Минимальный возраст: {minAge}");
        Console.WriteLine($"Средний возраст: {avgAge}");
    }
}

void Example6()
{
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    // данные для добавления
    int age = 36;
    string name = "Tom',10);INSERT INTO Users (Name, Age) VALUES('Hack";
    // выражение SQL для добавления данных
    string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        SqlCommand command = new SqlCommand(sqlExpression, connection);

        // создаем параметр для имени
        SqlParameter nameParam = new SqlParameter("@name", name);
        SqlParameter nameParam1 = new SqlParameter("@name", SqlDbType.NVarChar);

        // добавляем параметр к команде
        command.Parameters.Add(nameParam);
        // создаем параметр для возраста
        SqlParameter ageParam = new SqlParameter("@age", age);
        // добавляем параметр к команде
        command.Parameters.Add(ageParam);

        int number = command.ExecuteNonQuery();
        Console.WriteLine($"Добавлено объектов: {number}");

        // вывод данных

        command.CommandText = "SELECT * FROM Users";
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);

                Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object name2 = reader.GetValue(2);
                    object age2 = reader.GetValue(1);

                    Console.WriteLine($"{id} \t{name2} \t{age2}");
                }
            }
        }
    }
}