<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TrackUrl.aspx.vb" Inherits="Ajax.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <div id="main_container" style="position:relative; top:-0px;">
        <div id="Sub_main_container">
            <h1 id="review_edit_text">Media Upload</h1>
            <div id="Table_container">
                <h1 id="review_edit_text1" style="position:relative; left:0px; top:40px;">Select Your Track</h1>
                <h1 id="review_edit_text2" style="position:relative; left:480px;">Enter Youtube Link</h1>
                <div id="FileUpload_container"><asp:FileUpload ID="TrackMp3" runat="server" Width="196px" Height="50px" />
                    <asp:TextBox ID="txtYoutbe" runat="server" style="position:relative; left:280px;" /><br />
              
                <asp:Button ID="btnSubmit" runat="server" Text="Apply" Width="185px" Height="50px" BackColor="White" style="position:relative; top:20px; left:220px;"/>
               
                </div>

            </div>
        </div>
        
    </div>
   


</asp:Content>
