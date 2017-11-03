using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yungs.Game
{
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
        public string GetGameVIPCode(string gameID,int game,int vip)
        {
            var g = new BaseGame();
            switch((GameList)game)
            {
                case GameList.AoZhanXiangYang:g = new AoZhanXiangYang();break;
            }
            return g.VipCode(gameID,(VIPLevel)vip);
        }
    }
}