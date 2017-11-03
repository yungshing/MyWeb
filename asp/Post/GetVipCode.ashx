<%@ WebHandler Language="C#" Class="GetVipCode" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using Yungs.Game;
public class GetVipCode : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (context.Request.ServerVariables["request_method"].ToLower() == "get")
        {
            if ((context.Request.QueryString["game"] != null))
            {
                var gname = int.Parse(context.Request.QueryString["game"]);
                var vip = int.Parse(context.Request.QueryString["vip"]);
                var gameID = context.Request.QueryString["gameID"];
                var callBack = context.Request.QueryString["callback"];
                var re = new Follow().GetGameVIPCode(gameID, gname, vip);
                var res = new JavaScriptSerializer().Serialize(re);
                context.Response.Write(callBack + "(" + res + ")");
                new DataBase().AddID(gameID);
            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}