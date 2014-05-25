<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Songs.aspx.vb" Inherits="Ajax.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


 <style type="text/css">
        .style1
        {
            height: 26px;
            width: 209px;
        }
        .style2
        {
            width: 209px;
        }
        .style3
        {
            height: 26px;
            width: 55px;
        }
        .style4
        {
            width: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2> Customer Management Form </h2>
<p> Perform back-end management tasks such as searching, adding, editing, deleting, printing, printing all, and listing all the customers. <br /> </p>
<p> Enter the data and click the desire button to execute the operation. <br /> </p>

<div style="text-align: left">
<br />
<table border="0" style="margin-left:0px; width: 930px" >
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> <strong>Customer ID</strong></td>
        <td class="style3">
            <asp:TextBox ID="txtIDNumber" runat="server" Width="79px"></asp:TextBox> 
        </td>
        <td class="style1"> <asp:Button ID="btnSearch" runat="server" Text="Search" Width="111px" /></td>
        <td style="width: 17px; height: 26px">
            &nbsp;</td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> &nbsp;</td>
        <td class="style3">
        </td>
        <td class="style1"> 
            <asp:Button ID="btnSubmit" runat="server" Text="Exit" Width="111px" />
        </td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
 
    </table >
    <hr />
    <table style = "width: 930px">
    <tr>
        <td colspan="5" align="right">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
             Height="107px" Width="922px" > 
                <Columns>
                     <asp:BoundField DataField="IDNumber" HeaderText="Customer ID" 
                         HeaderStyle-BackColor ="#CC99FF" > 
<HeaderStyle BackColor="#CC99FF"></HeaderStyle>
                     </asp:BoundField>
                     <asp:BoundField DataField="FirstName" HeaderText="First Name" /> 
                     <asp:BoundField DataField="LastName" HeaderText="Last Name" /> 
                     <asp:BoundField DataField="SSNumber" HeaderText="Social Security" /> 
                     <asp:BoundField DataField="Address" HeaderText="Address" /> 
                     <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" /> 
                </Columns> 
                <HeaderStyle BackColor="#CC99FF" />
            </asp:GridView>
            
            &nbsp;</td>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td align="center" class="style2">
            &nbsp;</td>
        <td colspan="2"></td>
    </tr>
</table>
</div>
</asp:Content>
