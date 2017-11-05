using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Yungs.Game.Database
{
    /// <summary>
    /// SaveGameID 的摘要说明
    /// </summary>
    public class SaveGameID
    {
        DataBase db;
        public SaveGameID()
        {
            db = new DataBase();
            db.ServerUri = "qds161729656.my3w.com";
            db.UserID = "qds161729656";
            db.Pw = "hero1991";
            db.Database = "qds161729656_db";
            db.Table = "aozhanxiangyangID";
        }

        public int InsertID(string id)
        {
            return db.InsertData(new string[] { "ID","Time" }, new string[] { id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}