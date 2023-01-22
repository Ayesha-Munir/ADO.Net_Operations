// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //connection string to access Sql DB
            string connectionString = "Data Source=DESKTOP-4VKNBRB\\SQLEXPRESS;Database=StudentDB;Integrated Security = SSPI; ";

            //object connection created
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlcommand = new SqlCommand("select * from Users", connection);



            connection.Open();
            //prepairing reader to loop thorugh the table
            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {

                //getting user name from each row one by one
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
            }

            //Adding Records in DB

            //Insert Opertaion

            string inserUserQuery = "INSERT INTO Users (Id,Name) VALUES (@Id,@Name)";
            SqlCommand insertCommand = new SqlCommand(inserUserQuery, connection);
            insertCommand.Parameters.AddWithValue("@Id", 7);
            insertCommand.Parameters.AddWithValue("@Name", "Ayesha Munir");

            int recordsAdded = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{recordsAdded} no of records added");

            //Update Opertaion
            string updateQuery = "UPDATE Users SET Name=@Name WHERE Id=@Id";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@Name", "Saba");
            updateCommand.Parameters.AddWithValue("@Id", "7");

            int recordsUpdated = updateCommand.ExecuteNonQuery();
            Console.WriteLine($"{recordsUpdated} no of records updated");

            //Delete Opertaion
            string deleteQuery = "DELETE from Users WHERE Id=@Id";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.Parameters.AddWithValue("@Id", "8");

            int recordsDeleted = deleteCommand.ExecuteNonQuery();
            Console.WriteLine($"{recordsDeleted} no of records deleted");


            Console.WriteLine("Program ends here!");
        }
    }
}