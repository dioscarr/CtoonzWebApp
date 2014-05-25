<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="startpage.aspx.vb" Inherits="Ajax.startpage" %>

<!DOCTYPE html>
<link href="Styles/Site.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .auto-style2 {
            height: 86px;
        }
        .auto-style3 {
            width: 51px;
        }
    </style>
</head>
<body id="mystartpage">
  

    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="mainlogin">

            <div id="Loginnow">

                <div id="logintitle" style="">
                    <h3 id="title1"></h3>
                </div>
                <div id="logintitlebk" style="">
                    <h3 id="title1bk"></h3>
                </div>

                <div id="logincontent">
                    <table style="width: 398px; height: 200px; margin-left: auto; margin-right: auto;" border="0">
                        <tr>
                            <td class="auto-style3" style= "text-align:right;">
                                <asp:Label ID="Label2" style="Color:white; font-size:20px; font-family:Helvetica; " runat="server" >Username</asp:Label>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" Style="margin-left: 0px" Height="25px" Width="288px" Font-Size="Large"></asp:TextBox></td>
                        </tr>


                        <tr>
                            <td class="auto-style3" style= "text-align:right;">
                                <asp:Label ID="Label3" style="Color:white; font-size:20px; font-family:Helvetica; " runat="server" Text="Password"></asp:Label>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Height="25px" Width="287px" Font-Size="Large" TextMode="password"></asp:TextBox></td>


                        </tr>

                        <tr>


                            <td colspan="2" style="padding-bottom: 20px" class="auto-style2">
                                <asp:Button ID="btnLogin" runat="server" Style="position: relative; left: 133px; margin-top: 0px; top: 0px; width: 239px; height: 39px; border-radius: 12px; border: #66CCFF;" BorderColor="#66CCFF" Text="Login" BackColor="#66CCFF" />

                            </td>





                    </table>


                </div>
            </div>

            
                    <div id="lamaestria">
                       
                    </div>
        </div>
        <div>
        </div>
              </ContentTemplate>
        <Triggers>
             <asp:AsyncPostBackTrigger ControlID="btnLogin"  EventName="click" />


        </Triggers>
        </asp:UpdatePanel>
    </form>
      



</body>
</html>
