<%@ WebHandler Language="C#" Class="GetVipCode" %>

using System;
using System.Web;

public class GetVipCode : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.ServerVariables["request_method"].ToLower() == "post")
        {
            if ((context.Request.QueryString["game"] != null))
            {
                var gname = (GameList)int.Parse(context.Request.QueryString["game"]);
                var vip = (VIP)int.Parse(context.Request.QueryString["vip"]);
                var gameID = context.Request.QueryString["gameID"];
                var re = new Follow().GetGameVIPCode(gameID, gname, vip);
                context.Response.Write(re);
            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}