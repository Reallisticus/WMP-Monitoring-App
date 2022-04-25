using System;
using System.Data.SqlClient;

namespace Test3
{
    internal class Database
    {
        public string connectionString = @"data source=PC-PROGRAMMING\SQLEXPRESS;initial catalog=WMPlayer;trusted_connection=true";

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

        internal void PushToBase(string PCName, double totalTime, string date, SqlConnection cnn)
        {
            totalTime = Math.Round(totalTime, 2);
            string st = "insert into Time (PCName, ElapsedTime, Date) values (@PCName, @ElapsedTime, @Date)";
            SqlCommand cmd = new SqlCommand(st, cnn);
            cmd.Parameters.AddWithValue("@PCName", PCName);
            cmd.Parameters.AddWithValue("@ElapsedTime", totalTime);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.ExecuteNonQuery();
        }
    }

}