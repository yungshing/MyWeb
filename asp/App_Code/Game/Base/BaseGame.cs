using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Yungs.Game
{
    /// <summary>
    /// Follow 的摘要说明
    /// </summary>
    public class BaseGame
    {
        public virtual string VipCode(string gameID, VIPLevel vipLeve) { return ""; }
    }

    public enum GameList
    {
        Null = 0,
        AoZhanXiangYang,
    }

    public enum VIPLevel
    {
        Null = 0,
        VIP1,
        VIP2,
        VIP3,
        VIP4,
        VIP5,
        VIP6,
        VIP7,
        VIP8,
        VIP9,
        VIP10
    }
}