using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class GetVip : Page
{
    Follow follow;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.ServerVariables["request_method"].ToLower() == "post")
        {
            var gname = (GameList)int.Parse(Request.QueryString["game"]);
            var vip = (VIP)int.Parse(Request.QueryString["vip"]);
            var gameID = Request.QueryString["gameID"];
            var re = new Follow().GetGameVIPCode(gameID, gname, vip);
            usernameID.Text = gameID;
            showVIPCode_Tbx.Text = re;
            Response.Clear();
            Response.Write(re);
        }
        else
        {
            follow = new Follow();
        }
    }
    /// <summary>
    /// 点击获取按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetVIPCode(object sender, EventArgs e)
    {
        showVIPCode_Tbx.Text = follow.GetGameVIPCode(usernameID.Text);
    }

    protected void ChooseGame(object sender,EventArgs e)
    {
        follow.gameList = (GameList)(chooseGame_List.SelectedIndex + 1);
    }
    protected void ChooseVIP(object sender, EventArgs e)
    {
        follow.vip = (VIP)(chooseVIP_List.SelectedIndex + 1);
    }
}