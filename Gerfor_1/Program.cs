using System;
using Npgsql;
class Program
{
    static void Main()
    {
            using(NpgsqlConnection conn = new NpgsqlConnection("Server=db-rappiescolta.cktvjgg3ibd7.us-east-1.rds.amazonaws.com; Port=5432; User Id=postgres;  Database=rappi_escolta_db"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Products WHERE price > 10", conn);
                NpgsqlDataReader dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(1));
                }
                dr.Close();
            }
    }
}