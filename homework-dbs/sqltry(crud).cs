using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

static class DatabaseWork
{
   static string connectionString = @"Data Source=.\SQLEXPRESSNEW;Initial Catalog=userdb;Integrated Security=True";
   static string create()
    {
        Console.WriteLine("Введите имя:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите возраст:");
        int age = Int32.Parse(Console.ReadLine());

        return String.Format("INSERT INTO Users (Name, Age) VALUES ('{0}', {1})", name, age);
    }
   static string update()
    {
        string name;
        int age;
        Console.WriteLine("Хотите изменить имя или возраст? Имя - 1, возраст - не 1: ");
        if (Convert.ToInt32(Console.ReadLine()) == 1)
        {
            Console.WriteLine("Введите возраст, чьи данные хотите изменить:");
            age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое имя:");
           name = Console.ReadLine();

            return String.Format("UPDATE Users SET Name='{0}' WHERE Age={1}", name, age);
        }
        else
        {
            Console.WriteLine("Введите имя, чьи данные хотите изменить:");
            name = Console.ReadLine();

            Console.WriteLine("Введите новый возраст:");
            age = Int32.Parse(Console.ReadLine());

            return String.Format("UPDATE Users SET Age='{0}' WHERE Name='{1}'", age, name);
        }
    }
   static string delete()
    {
        Console.WriteLine("Введите имя, чью запись хотите удалить:");
        string name = Console.ReadLine();

        return String.Format("DELETE  FROM Users WHERE Name='{0}'", name);
    }
   static void read()
    {
        string sqlExpression = "SELECT * FROM Users";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object age = reader.GetValue(2);

                    Console.WriteLine("{0}\t{1}\t{2}", id, name, age);
                }
            }

            reader.Close();
        }
    }
   static public void work()
    {
        int choose = 5,number=0;
        string cmd="";
        bool end = false;
        SqlCommand command;
        do
        {
            Console.WriteLine("Работа с базой данных. Что вы хотите сделать?\n1 - добавить запись, 2 - обновить, 3 - удалить, 0 - exit: ");
            choose = Int32.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                switch (choose)
                {
                    case 1:
                        cmd = create();break;
                    case 2:
                        cmd=update();break;
                    case 3:
                       cmd=delete();break;
                    case 0:
                        end = true;
                        break;

                }
                if (!end)
                {
                    command = new SqlCommand(cmd, connection);
                    number = command.ExecuteNonQuery();
                    Console.WriteLine("Обновлено объектов: {0}", number);
                }
                
            }
            read();
        } while (choose != 0);
    }
}
namespace sqltry__crud_
{
    class CODE
    {
        static void Main(string[] args)
        {
            DatabaseWork.work();
        }
    }
}
