using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// CalVIP 的摘要说明
/// </summary>
public abstract class CalVIP
{
    public CalVIP()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public abstract string GetVIP(string id, VIP vip = VIP.VIP1);
}