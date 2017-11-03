using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Follow 的摘要说明
/// </summary>
public class Follow
{
    public Follow()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public GameList gameList = GameList.AoZhanXiangYang;
    public VIP vip = VIP.VIP1;

    public string GetGameVIPCode(string gameID, VIP vip = VIP.VIP1)
    {
        switch (gameList)
        {
            case GameList.AoZhanXiangYang: return new AoZhanXiangYang().GetVIP(gameID, vip);
        }
        return "";
    }

    public string GetGameVIPCode(string gameID, GameList id, VIP vip = VIP.VIP1)
    {
        switch (id)
        {
            case GameList.AoZhanXiangYang: return new AoZhanXiangYang().GetVIP(gameID, vip);
        }
        return "";
    }
}