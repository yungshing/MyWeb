<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetVip.aspx.cs" Inherits="GetVip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <p>复制时注意空格,建议用ctrl+a全选</p> 
            <p>不保证一定能用，测试过几个帐号均可使用。</p>
            <p style="color:red;font-size:17px">目前只开放VIP1</p>
           <p>
               &nbsp;<asp:DropDownList ID="chooseGame_List" runat="server" OnSelectedIndexChanged="ChooseGame">
                   <asp:ListItem>鏖战襄阳</asp:ListItem>
               </asp:DropDownList>
               <asp:DropDownList ID="chooseVIP_List" runat="server">
                   <asp:ListItem>VIP1</asp:ListItem>
               </asp:DropDownList>
           </p>
        <div>
        <asp:Label ID="username" runat="server" Text="游戏ID"></asp:Label>   <asp:TextBox ID="usernameID" runat="server" Width="542px"></asp:TextBox>
        </div>
        <asp:Button ID="getVIP_Btn" runat="server" Text="获取" Width="50px" onclick="GetVIPCode"/>                                                                   
        <asp:TextBox ID="showVIPCode_Tbx" runat="server" ReadOnly="false" Width="553px"></asp:TextBox>
    </div>
        <div>
            <p>如果你觉得帮到你了，如果可以，请我喝瓶水！</p>
            <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 支付宝&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 微信</p>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/zhifubao_1.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/Image/weixin_1.png"  />
            
            <p>如果你有更高VIP，如果可以，请把你的游戏ID和VIP代码发到此邮箱：yungshing@tom.com
               注意：不是你的平台帐号和密码。代码仅供破解使用。
            </p>
        </div>
    </form>
</body>
</html>
