using System;
using System.Data.SqlClient;

namespace Test3
{
    internal class Database
    {
        public string connectionString = @"Data Source=PC-PROGRAMMING\SQLEXPRESS;Initial Catalog=PlayerTest;Integrated Security=True";

        //public Database(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        internal SqlConnection Connect()
        {
            SqlConnection cnn;
            string connect = this.connectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            return cnn;
        }

        internal void PushToBase(string PCName, double elapsedTime, DateTime endTime, SqlConnection cnn)
        {
            string st = "insert into agents(pcname, elapsed time, date) values (@pcname, @elapsedTime, @endTime)";
            SqlCommand cmd = new SqlCommand(st, cnn);
            cmd.Parameters.AddWithValue("@pcname", PCName);
            cmd.Parameters.AddWithValue("@totalTime", elapsedTime);
            cmd.Parameters.AddWithValue("@date", endTime);
            cmd.ExecuteNonQuery();
        }
    }

}