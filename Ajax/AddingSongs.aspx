<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddingSongs.aspx.vb" Inherits="Ajax.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        <td style="width: 18px; height: 26px">
        </td>
        <td style="width: 342px; height: 26px"> <asp:TextBox ID="txtIDNumber" runat="server" Width="207px"></asp:TextBox></td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> First Name</td>
        <td style="width: 18px; height: 26px">
        </td>
        <td style="width: 342px; height: 26px"> <asp:TextBox ID="txtfName" runat="server" 
                Width="333px"></asp:TextBox></td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> Last Name</td>
        <td style="width: 18px; height: 26px">
        </td>
        <td style="width: 342px; height: 26px"> <asp:TextBox ID="txtLname" runat="server" 
                Width="333px"></asp:TextBox></td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 128px; text-align: right"> SS Number</td>
        <td style="width: 18px">
        </td>
        <td style="width: 342px"> <asp:TextBox ID="txtSSNum" runat="server" Width="210px"></asp:TextBox>
        </td>
        <td style="width: 17px">
        </td>
        <td style="width: 148px"> &nbsp;</td>
    </tr>
    
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> Address</td>
        <td style="width: 18px; height: 26px">
        </td>
        <td style="width: 342px; height: 26px"> <asp:TextBox ID="txtAddress" runat="server" Width="328px"></asp:TextBox></td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 128px; height: 26px; text-align: right"> Phone</td>
        <td style="width: 18px; height: 26px">
        </td>
        <td style="width: 342px; height: 26px"> <asp:TextBox ID="txtPhone" runat="server" Width="210px"></asp:TextBox></td>
        <td style="width: 17px; height: 26px">
        </td>
        <td style="width: 148px; height: 26px"> <asp:Button ID="btnAdd" runat="server" 
                Text="Add" Width="111px" /></td>
    </tr>
   
  
    <tr>
        <td colspan="2"></td>
        <td align="center">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td colspan="2"></td>
    </tr>
</table>
</div>


</asp:Content>
