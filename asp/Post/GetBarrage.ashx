<%@ WebHandler Language="C#" Class="GetBarrage" %>

using System;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
public class GetBarrage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        if (context.Request.ServerVariables["request_method"].ToLower() == "post")
        {
            var request = context.Request;
            var barrage = new Barrage();

            using (var sr = new StreamReader(request.InputStream))
            {
                var js = new JavaScriptSerializer();
                barrage = js.Deserialize<Barrage>(sr);
            }

        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}
[System.Serializable]
public class Barrage
{
    public string time;
    public string content;
}