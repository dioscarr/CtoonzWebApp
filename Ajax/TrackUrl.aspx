<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TrackUrl.aspx.vb" Inherits="Ajax.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
            <asp:FileUpload ID="TrackMp3" runat="server" Width="196px" />
            <br />
            <br />
            <br />
             <asp:Button ID="btnSubmit" runat="server" Text="Save" Width="185px" />
    <br />
    <br />
    <asp:Button ID="btn1" runat="server" Text="Upload" />
            <br />
            <br />
    <div id="progressbar" class="progressbar">
           
    </div>
    

    <div>
        


    </div>



    
             
</asp:Content>
