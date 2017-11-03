using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// DataBase 的摘要说明
/// </summary>
public class DataBase
{
    public DataBase()
    {
        
    }
    
    public SqlConnection CreateDataBase()
    {
        var connectionString = "server=qds161729656.my3w.com;uid=qds161729656;pwd=hero1991;database=qds161729656_db";
        return new SqlConnection(connectionString);
    }

    public int AddID(string id)
    {
        int t = 0;
        using (var conn = CreateDataBase())
        {
            var time = DateTime.Now;
            var order = "insert into [aozhanxiangyangID] ([ID],[Time]) values('#id#','#time#')";
            order = order.Replace("#id#",id).Replace("#time#",time.ToString("yyyy-MM-dd HH:mm:ss"));
            using (var comm = new SqlCommand(order,conn))
            {
                conn.Open();
               t = comm.ExecuteNonQuery();
            }
            return t;
        }
    }

    public string TestGetValue()
    {
        string s = "n";
        using (var conn = CreateDataBase())
        {
            conn.Open();
            var order = "select [ID] from [aozhanxiangyangID] where [Index] = 1";
            var comm = conn.CreateCommand();
            comm.CommandText = order;
            var read = comm.ExecuteReader();
            while(read.Read())
            {
                s = read.GetString(read.GetOrdinal("ID"));
            }
        }
        return s;
    } 
}