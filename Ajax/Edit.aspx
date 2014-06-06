<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.vb" Inherits="Ajax.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style7
        {
            height: 26px;
            width: 128px;
        }
        .style11
        {
            height: 26px;
            width: 313px;
        }
        .style2
        {
            width: 128px;
            height: 30px;
        }
        .style3
        {
            width: 18px;
            height: 30px;
        }
        .style4
        {
            width: 313px;
            height: 30px;
        }
        .style5
        {
            width: 17px;
            height: 30px;
        }
        .style6
        {
            width: 148px;
            height: 30px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div id="main_container">
        <div id="Sub_main_container">
            <h1 id="review_edit_text">Review and edit </h1>
            <div id="Table_container">
                <table id="EditTable" border="0" style="margin-left: 0px; width: 664px; height: 159px;">
                    <tr>
                        <td style="text-align: right" class="style7">&nbsp;</td>
                        <td style="width: 18px; height: 26px"></td>
                        <td class="style11">
                            <asp:TextBox ID="txtIDNumber" runat="server"
                                Width="324px"></asp:TextBox></td>
                        <td style="width: 17px; height: 26px"></td>
                        <td style="width: 148px; height: 26px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="style7">Track Name</td>
                        <td style="width: 18px; height: 26px"></td>
                        <td class="style11">
                            <asp:TextBox ID="txtTrackName"  runat="server"
                                Width="324px"></asp:TextBox></td>
                        <td style="width: 17px; height: 26px"></td>
                        <td style="width: 148px; height: 26px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="style7">Artist</td>
                        <td style="width: 18px; height: 26px"></td>
                        <td class="style11">
                            <asp:TextBox ID="txtArtist" runat="server"
                                Width="324px"></asp:TextBox></td>
                        <td style="width: 17px; height: 26px"></td>
                        <td style="width: 148px; height: 26px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="style2">Status</td>
                        <td class="style3"></td>
                        <td class="style4">
                            <asp:TextBox ID="txtStatus" runat="server" Width="324px"></asp:TextBox>
                        </td>
                        <td class="style5"></td>
                        <td class="style6">
                           
                    </tr>
                    <tr>
                        <td style="text-align: right" class="style2">Album Name</td>
                        <td class="style3"></td>
                        <td class="style4">
                            <asp:TextBox ID="txtAlbum" runat="server" Width="324px"></asp:TextBox>
                        </td>
                        <td class="style5"></td>
                        <td class="style6"></td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                        <td colspan="1">
                            </td>

                    </tr>
                    <tr>
                        <td>



                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>



                        </td>
                    </tr>


                </table>


            </div>
           
            <div id="Delete_Edit_data">
                 <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="150px" Height="30px" />
                 <asp:Button ID="btnApply"  runat="server" Text="Apply" Width="150px" Height="30px" />
            
            </div>
        </div>
    </div>
</asp:Content>
