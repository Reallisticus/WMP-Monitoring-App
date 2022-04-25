using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    public class Database
    {
        private string connetionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { ConnectionString = value; }
        }

    }

    public void ConnectDatabase(string connectionString)
    {
        SqlConnection cnn;
        //Data Source=PC-PROGRAMMING\SQLEXPRESS;Initial Catalog=PlayerTest;Integrated Security = True;
        connectionString = @"Data Source=PC-PROGRAMMING\SQLEXPRESS;Initial Catalog=PlayerTest;Integrated Security=True";
        cnn = new SqlConnection(connectionString);
        cnn.Open();
    }

    private void PushToBase(string PCName, double elapsedTime, DateTime date)
    {
        String st = "INSERT INTO Listened Time(PCName, Elapsed Time, Date) values (@PCName, @elapsedTime, @date)";
        SqlCommand cmd = new SqlCommand(st, cnn);
        cmd.Parameters.AddWithValue("@PCName", PCName);
        cmd.Parameters.AddWithValue("@elapsed Time", elapsedTime);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.ExecuteNonQuery();
    }
}
