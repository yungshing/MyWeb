using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yungs.Game
{
    /// <summary>
    /// AoZhanXiangYang 的摘要说明
    /// </summary>
    public class AoZhanXiangYang : BaseGame
    {
        public AoZhanXiangYang()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public override string VipCode(string gameID, VIPLevel vip = VIPLevel.VIP1)
        {
            return ((int)vip <= (int)VIPLevel.VIP5 ? GetVIPA(gameID, vip) : GetVIPB(gameID, vip));
        }

        /// <summary>
        /// vip1~5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vip"></param>
        /// <returns></returns>
        private string GetVIPA(string id, VIPLevel vip)
        {
            var playName2Int = StringHash.GetStringHash(id);
            var codeNum = GetVIP_codeNum(vip);
            playName2Int = Math.Abs(playName2Int);

            int n = 0;
            while (n < codeNum[0])
            {
                playName2Int = Math.Abs(StringHash.GetStringHash(playName2Int.ToString()));
                n++;
            }

            if (playName2Int < 1000000000)
            {
                playName2Int = playName2Int + 1000000000;
            }

            return playName2Int.ToString() + GetVIPCodeEnd(vip);
        }
        /// <summary>
        /// vip6~8
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vip"></param>
        /// <returns></returns>
        private string GetVIPB(string id, VIPLevel vip)
        {
            return "未开放";
        }
        /// <summary>
        /// 16	1872621654  VIP1
        /// 15	-1852797781 VIP3
        /// 14	383701306	VIP4
        /// 13	1240896430	VIP5
        /// 476189441		768461234		VIP6
        /// -1837671441		-1288222321		VIP7
        /// 1858938605		2112060518		VIP8
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        private int[] GetVIP_codeNum(VIPLevel vip)
        {
            switch (vip)
            {
                case VIPLevel.VIP1: return new int[] { 16, 1872621654 };
                case VIPLevel.VIP3: return new int[] { 15, -1852797781 };
                case VIPLevel.VIP4: return new int[] { 14, 383701306 };
                case VIPLevel.VIP5: return new int[] { 13, 1240896430 };
                case VIPLevel.VIP6: return new int[] { 476189441, 768461234 };
                case VIPLevel.VIP7: return new int[] { -1837671441, -1288222321 };
                case VIPLevel.VIP8: return new int[] { 1858938605, 2112060518 };
            }
            return new int[] { 16, 1872621654 };
        }
        private string GetVIPCodeEnd(VIPLevel vip)
        {
            switch (vip)
            {
                case VIPLevel.VIP1: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP3: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP4: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP5: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP6: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP7: return "O0/lql0$eqwww.qq.com					 ";
                case VIPLevel.VIP8: return "O0/lql0$eqwww.qq.com					 ";
            }
            return "O0/lql0$eqwww.qq.com					 ";
        }
    }
}