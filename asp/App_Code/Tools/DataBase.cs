using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// 数据库相关操作
/// 插入 取值
/// 需要手动释放SqlConnection 调用dispose方法
/// </summary>
public class DataBase
{
    public DataBase()
    {
        
    }
    /// <summary>
    /// 服务器地址
    /// </summary>
    public string ServerUri
    {
        private get
        {
            return serverUri;
        }

        set
        {
            serverUri = value;
        }
    }
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserID
    {
        private get
        {
            return userID;
        }
        set
        {
            userID = value;
        }
    }
    /// <summary>
    /// 密码
    /// </summary>
    public string Pw
    {
        get
        {
            return pw;
        }

        set
        {
            pw = value;
        }
    }
    /// <summary>
    /// 表名
    /// </summary>

    public string Table
    {
        private get
        {
            return table;
        }

        set
        {
            table = value;
        }
    }
    /// <summary>
    /// 数据库名
    /// </summary>
    public string Database
    {
        private get
        {
            return database;
        }

        set
        {
            database = value;
        }
    }

    private string serverUri;
    private string userID;
    private string pw;
    private string database;
    private string table;

    private SqlConnection currConnection = null;
    private string Connection()
    {
        return "server="+ ServerUri + ";uid=" + UserID + ";pwd=" + Pw + ";database=" + Database;
    }
    public SqlConnection CreateSqlConnection()
    {
        if (currConnection == null)
        {
            currConnection = new SqlConnection(Connection());
            currConnection.Open();
        }
        return currConnection;
    }
    #region 插入
    public int InsertData(string args,string value)
    {
        return InsertData(new string[] { args }, new string[] { value });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args">字段名集合</param>
    /// <param name="value">值集合</param>
    /// <returns>0:false 1:true</returns>
    public int InsertData(string [] args,string[]value)
    {
        var order = "insert into [" + Table + "] ([" + args[0] + "]";
        for (int i = 1; i < args.Length; i++)
        {
            order += ",["+args[i]+"]";
        }
        order += ") values('"+value[0]+"'";
        for (int i = 1; i < value.Length; i++)
        {
            order += ",'"+value[i]+"'";
        }
        order += ")";
        return ExecuteNonQuery(order);
    }
    #endregion
    #region 查询
    /// <summary>
    /// 查询一项
    /// </summary>
    /// <param name="name">名字</param>
    /// <param name="_where"></param>
    /// <param name="_whereValue"></param>
    /// <returns></returns>
    public string[] SelectValue(string name,string _where,string _whereValue)
    {
        var order = "select [" + name + "] from [" + table + "] where [" + _where + "] = " + _whereValue;
        List<string> s = new List<string>();
        using (var comm = new SqlCommand(order, currConnection))
        {
            var er = comm.ExecuteReader();
            while(er.Read())
            {
                s.Add(er.GetString(er.GetOrdinal(name)));
            }
        }
        return s.ToArray();
    }
    public string[] SelectAll(string name)
    {
        var order = "select [" + name + "] from [" + table + "]";
        List<string> s = new List<string>();
        CreateSqlConnection();
        using (var comm = new SqlCommand(order, currConnection))
        {
            var er = comm.ExecuteReader();
            while (er.Read())
            {
                s.Add(er.GetString(er.GetOrdinal(name)));
            }
        }
        return s.ToArray();
    }
    #endregion
    #region 更新数据
    public int Update(string args, string value, string _where, string _wherevalue)
    {
        return Update(new string[] { args }, new string[] { values }, _where, _wherevalue);
    }
    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="args"></param>
    /// <param name="values"></param>
    /// <param name="_where"></param>
    /// <param name="_wherevalue"></param>
    /// <returns>0:false 1:true</returns>
    public int Update(string[] args,string[]values,string _where,string _wherevalue)
    {
        var order = "update [" + table + "] set [" + args[0] + "]='" + values[0] + "'";
        for (int i = 1; i < args.Length; i++)
        {
            order += ",[" + args[i] + "]='" + values[0] + "'";
        }
        order += " where [" + _where + "]='" + _wherevalue + "'";

        return ExecuteNonQuery(order);
    }
    #endregion
    /// <summary>
    /// 执行增加，删除命令
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private int ExecuteNonQuery(string order)
    {
        int t = 0;
        CreateSqlConnection();
        using (var comm = new SqlCommand(order, currConnection))
        {
            t = comm.ExecuteNonQuery();
        }
        return t;
    }
    public void Dispose()
    {
        try
        {
            currConnection.Dispose();
            currConnection = null;
        }
        catch { }
    }
}