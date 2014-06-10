<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TrackUrl.aspx.vb" Inherits="Ajax.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" />
     <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>


    <script type="text/javascript">
     $(document).ready(function () {

            var data = '1';
            $.ajax({
                type: "POST",
                url: "ControlPanel.aspx/DashboardWebmethod",
                data: '{name: ' + data + ' }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (html) {
                    var HexColor = html.d
                    //alert(HexColor);
                    $('body').css('background', HexColor);

                }

            });
     });
    </script>


<script type="text/javascript">
   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <div id="main_container" ">
        <div id="Sub_main_container">
            <h1 id="review_edit_text">Media Upload</h1>
            <div id="Table_container">
                <h1 id="review_edit_text1" style="position:relative; left:0px; top:40px;">Select Your Track</h1>
                <h1 id="review_edit_text2" style="position:relative; left:480px;">Enter Youtube Link</h1>
                <div id="FileUpload_container"><asp:FileUpload ID="TrackMp3" runat="server" Width="196px" Height="50px" />
                    <asp:TextBox ID="txtYoutbe" runat="server" style="position:relative; left:280px;" ></asp:TextBox><br />
                    
                <asp:Button ID="btnSubmit" runat="server" Text="Apply" Width="185px" Height="50px" BackColor="White" style="position:relative; top:20px; left:220px;"/>
               
                </div>

            </div>
        </div>
        
    </div>
   


</asp:Content>
