<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SongsManagement.aspx.vb" Inherits="Ajax.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
         <%-- boostrap --%>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" />
   
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <link href="bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
        <link href="bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
        <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
     <%-- End boostrap --%>

     <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
   
    <script type="text/javascript">
        //***********************************************************************************************************************************************************


        $(document).ready(function () {



            $("#MainContent_GridView1 tr").find("th").addClass('newcolor');
            $("#MainContent_GridView1 ").find("*").css("border", "none");
            $("#MainContent_GridView1 ").find("*").css("height", "43px");
            $("#MainContent_GridView1 ").find("td").css("border-bottom", "3px solid lightgrey");
            $("#MainContent_GridView1 ").find("td").css("border-top", "1px solid lightgrey");
            $("#MainContent_GridView1 ").find("td").css("text-align", "center");
            $("#MainContent_GridView1 ").find("th").css("border-bottom", "1px solid lightgrey");
            $("#MainContent_GridView1 ").find("th").css("border-top", "1px solid lightgrey");
            //adding fix widths to the ths and tds
            $("#MainContent_GridView1 tr").find("th:nth-child(1) ").addClass("myID");
            $("#MainContent_GridView1 tr").find("th:nth-child(2) ").css("myTrack");
            $("#MainContent_GridView1 tr").find("th:nth-child(3) ").css("width", "300x");
            $("#MainContent_GridView1 tr").find("th:nth-child(4) ").css("width", "150px");
            $("#MainContent_GridView1 tr").find("th:nth-child(5) ").css("width", "150px");
            $("#MainContent_GridView1 tr").find("td:nth-child(1) ").css("width", "51px");
            $("#MainContent_GridView1 tr").find("td:nth-child(2) ").css("width", "227px");
            $("#MainContent_GridView1 tr").find("td:nth-child(3) ").css("width", "300px");
            $("#MainContent_GridView1 tr").find("td:nth-child(4) ").css("width", "150px");
            $("#MainContent_GridView1 tr").find("td:nth-child(5) ").css("width", "150px");

           
            $('#btnFilter').hide();
            $('#<%=txtFiltrerID.ClientID %>').hide();

        $('#rb2bk').addClass('borderside');
        // $('#searchheader').hide();




        $('#<%=rb2.ClientID%>').click(function () {
            var rb2value = $('#<%=rb2.ClientID%> input:checked').index();

            if (rb2value != -1) {
                var myval = $('#<%=rb2.ClientID%> input:checked').val();
                $('#btnFilter').fadeIn("slow");
                $('#<%=txtFiltrerID.ClientID %>').fadeIn("slow");
            }

        });

        var rows = $('#MainContent_GridView1').find('tbody tr').length;
        var no_rec_per_page = 15;
        var no_pages = Math.ceil(rows / no_rec_per_page);
        var $pagenumbers = $('<div id="pages"></div>');
        for (i = 0; i < no_pages; i++) {
            $('<span id="clickme" class="paging">' + (i + 1) + '</span>').appendTo($pagenumbers);
        }
        $pagenumbers.insertBefore('#MainContent_GridView1');
        $('.paging').hover(function () {
            $(this).addClass('hoverpaging');
        }, function () {
            $(this).removeClass('hoverpaging');
        });
        $('#MainContent_GridView1').find('tbody tr').hide();
        var tr = $('#MainContent_GridView1 tbody tr');

        $('span').click(function (event) {
            $('#MainContent_GridView1').find('tbody tr').hide();
            for (var i = ($(this).text() - 1) * no_rec_per_page;
           i <= $(this).text() * no_rec_per_page - 1; i++) {
                $(tr[i]).show();
            }
        });
        $('#clickme').trigger("click"); // trigger click event on the span with ID clickme

        $('#MainContent_GridView1 tr').hover(function () {
            $(this).find('td').addClass('hover');
            $(this).find('tr').addClass('tblWoBorder');
            //$('#MainContent_GridView1').addClass('tblWoBorder');
        },
              function () {
                  $(this).find('td').removeClass('hover');
              }).toggle(function () {

                  var ID = $(this).find("th:nth-child(1) ").text();
                  $(this).find('td').css("color", "black");

                  if (ID != "ID") {

                      var ID = $(this).find("td:nth-child(1) ").text();
                      var Track = $(this).find("td:nth-child(2) ").text();
                      var Artist = $(this).find("td:nth-child(3) ").text();
                      var Status = $(this).find("td:nth-child(4) ").text();
                      var Album = $(this).find("td:nth-child(5) ").text();

                      var data = '';

                      //(Audio Payer) Call to Webmethod that return the url of an mp3

                      audioPayerUrl = "";
                      $.ajax({
                          type: "POST",
                          url: "TrackUrl.aspx/WebMethodTrackUrl",
                          data: '{name: ' + ID + ' }',
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (html) {

                              returnData(html.d);
                          }
                      });

                      $.ajax({
                          type: "POST",
                          url: "TrackUrl.aspx/WebMethodYoutubeId",
                          data: '{name: ' + ID + ' }',
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (html) {
                              
                
                              YoutubeIDReturn(html.d);
                          }
                      });

                 
                      $('.product').remove();
                      $(this).closest('tr').after('<tr class="product">' +
                          '<td class="myLyricsUrl" colspan="3"></td>' +
                            '<td colspan="2" id="myothercont">' +
                                    '<button id="myEdit" >Edit</button>' +
                                     '<button id="mySongUpload">Upload Media</button>' +
                                    '<div id="myPlayer">' +
                                    '</div >' +
                                    '<div id="youtubevideo">   </div>' +

                            '</td>' +
                            '<td id="mmm"> </td>' +
                          '</tr>');
                      function YoutubeIDReturn(htmlreturn) {
                         // alert(htmlreturn);
                         $('#youtubevideo').html('<iframe width="300" height="169" src="//www.youtube.com/embed/'+htmlreturn+'" frameborder="0" allowfullscreen></iframe>')
                      }

                      function returnData(htmlReturn) {
                          audioPayerUrl = htmlReturn

                          $('#myPlayer').html('<div id="myElement"><audio controls id="trackplayer"> <source src="/MP3/' + audioPayerUrl + '" type="audio/mpeg"> </audio> </div>')

                      }

                      var songpath = ""
                      // alert(audioPayerUrl);
                      //Parameterized load page and select portion of ID = #MainContent_myLyrics

                      $('.product .myLyricsUrl').load('Lyrics.aspx #MainContent_myLyrics', { ID: ID }, function () {

                          //Lyrics  uploaded
                          var obj = $('#MainContent_myLyrics').html();

                          if (obj == 'Ready') {
                              //alert('I am inside Ready ');
                              var data = '';
                              $.ajax({
                                  type: "POST",
                                  url: "PasteLyricspg.aspx/testmethod",
                                  data: '{name: ' + ID + ' }',
                                  contentType: "application/json; charset=utf-8",
                                  dataType: "json",
                                  success: function (html) {
                                      $('#MainContent_myLyrics').html('<iframe id="iframemyuploadlyricspdf" style="Height:750px; width:570px;" src="/upfile/' + html.d + '"></iframe>');
                                  }
                              });
                          }
                          //Lyrics not yet uploaded
                          if (obj == 'uploadmylyrics') {
                              // alert('I am inside uploadmylyrics ');

                              $('#MainContent_myLyrics').html('<button id="btnuploadmylyrics">Upload PDF version of the Lyrics</button>');

                          }

                          else {
                              $('#MainContent_myLyrics').html("")

                          };
                          //Mp3 Player


                         
                          $('.product').fadeIn(2000);

                        









                          $('#mmm').hide();
                      });


                      $('#mySongUpload').live('click', function () {

                          window.location.href = 'TrackUrl.aspx?ID=' + ID;


                      });

                      $('#btnuploadmylyrics').live('click', function (e) {

                          window.location.href = 'PasteLyricspg.aspx?ID=' + ID;




                          e.preventDefault();
                      });

                      $('#myEdit').click(function () {
                          window.location.href = 'Edit.aspx?ID=' + ID;
                      });
                  }
                  else {
                  }
              }, function () {

                  $('.product').remove();
                  $('#myPlayer').remove();

              });

        //        $('#MainContent_GridView1 tr').addClass('formatting');


        $('.listbox').hide();
        $('.userid').keyup(function () {
            var uid = $('.userid').val();
            var data = 'userid=' + uid;


            $.ajax({
                type: "POST",
                url: "ServerResponse.aspx",
                data: data,
                success: function (html) {
                    $('.listbox').show();
                    $('.listbox').css('background', 'white');
                    $('.nameslist').html(html);
                    $('li').hover(function () {
                        $(this).addClass('hover');
                    }, function () {
                        $(this).removeClass('hover');
                    });
                    $('li').click(function () {
                        $('.userid').val($(this).text());
                        $('.listbox').hide();
                    });
                }
            });





            $('.listbox').css('background', 'green');


            return false;
        });
    });

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        $("#MainContent_GridView1 tr").find("th").addClass('newcolor');
        $("#MainContent_GridView1 ").find("*").css("border", "none");
        $("#MainContent_GridView1 ").find("*").css("height", "40px");
        $("#MainContent_GridView1 ").find("td").css("border-bottom", "1px solid lightgrey");
        $("#MainContent_GridView1 ").find("td").css("border-top", "1px solid lightgrey");
        $("#MainContent_GridView1 ").find("td").css("text-align", "center");
        $("#MainContent_GridView1 ").find("th").css("border-bottom", "1px solid lightgrey");
        $("#MainContent_GridView1 ").find("th").css("border-top", "1px solid lightgrey");
        //adding fix widths to the ths and tds
        $("#MainContent_GridView1 tr").find("th:nth-child(1) ").css("width", "50px");
        $("#MainContent_GridView1 tr").find("th:nth-child(2) ").css("width", "200x");
        $("#MainContent_GridView1 tr").find("th:nth-child(3) ").css("width", "300x");
        $("#MainContent_GridView1 tr").find("th:nth-child(4) ").css("width", "150px");
        $("#MainContent_GridView1 tr").find("th:nth-child(5) ").css("width", "150px");
        $("#MainContent_GridView1 tr").find("td:nth-child(1) ").css("width", "50px");
        $("#MainContent_GridView1 tr").find("td:nth-child(2) ").css("width", "200px");
        $("#MainContent_GridView1 tr").find("td:nth-child(3) ").css("width", "300px");
        $("#MainContent_GridView1 tr").find("td:nth-child(4) ").css("width", "150px");
        $("#MainContent_GridView1 tr").find("td:nth-child(5) ").css("width", "150px");

        //var ID = $(this).find("td:nth-child(1) ").text();
        // var Track = $(this).find("td:nth-child(2) ").text();
        // var Artist = $(this).find("td:nth-child(3) ").text();
        // var Status = $(this).find("td:nth-child(4) ").text();
        // var Album = $(this).find("td:nth-child(5) ").text();

        $('#btnFilter').hide();
        $('#<%=txtFiltrerID.ClientID %>').hide();

        $('#rb2bk').addClass('borderside');
        // $('#searchheader').hide();




        $('#<%=rb2.ClientID%>').click(function () {
            var rb2value = $('#<%=rb2.ClientID%> input:checked').index();

            if (rb2value != -1) {
                var myval = $('#<%=rb2.ClientID%> input:checked').val();
                $('#btnFilter').fadeIn("slow");
                $('#<%=txtFiltrerID.ClientID %>').fadeIn("slow");
            }

        });

        var rows = $('#MainContent_GridView1').find('tbody tr').length;
        var no_rec_per_page = 15;
        var no_pages = Math.ceil(rows / no_rec_per_page);
        var $pagenumbers = $('<div id="pages"></div>');
        for (i = 0; i < no_pages; i++) {
            $('<span id="clickme" class="paging">' + (i + 1) + '</span>').appendTo($pagenumbers);
        }
        $pagenumbers.insertBefore('#MainContent_GridView1');
        $('.paging').hover(function () {
            $(this).addClass('hoverpaging');
        }, function () {
            $(this).removeClass('hoverpaging');
        });
        $('#MainContent_GridView1').find('tbody tr').hide();
        var tr = $('#MainContent_GridView1 tbody tr');

        $('span').click(function (event) {
            $('#MainContent_GridView1').find('tbody tr').hide();
            for (var i = ($(this).text() - 1) * no_rec_per_page;
           i <= $(this).text() * no_rec_per_page - 1; i++) {
                $(tr[i]).show();
            }
        });
        $('#clickme').trigger("click"); // trigger click event on the span with ID clickme

        $('#MainContent_GridView1 tr').hover(function () {
            $(this).find('td').addClass('hover');
            $(this).find('tr').addClass('tblWoBorder');
            //$('#MainContent_GridView1').addClass('tblWoBorder');
        },
              function () {
                  $(this).find('td').removeClass('hover');
              }).toggle(function () {

                  var ID = $(this).find("th:nth-child(1) ").text();
                  $(this).find('td').css("color", "black");

                  if (ID != "ID") {

                      var ID = $(this).find("td:nth-child(1) ").text();
                      var Track = $(this).find("td:nth-child(2) ").text();
                      var Artist = $(this).find("td:nth-child(3) ").text();
                      var Status = $(this).find("td:nth-child(4) ").text();
                      var Album = $(this).find("td:nth-child(5) ").text();
                      //window.location.href = 'Edit.aspx?ID=' + ID; //+ '&Track=' + Track + '&Artist=' + Artist + '&Status=' + Status + '&Album=' + Album;

                      $('.product').remove();
                      $(this).closest('tr').after('<tr class="product" style="border:2px solid lightgrey; background:white;">' +
                          '<td class="myLyricsUrl" colspan="3" style="border:1px solid lightgrey;" ></td>' +
                            '<td colspan="2" id="myothercont" style="background:black;  height:950px;" " >' +
                                    '<button id="myEdit" >Edit</button>' +
                                     '<button id="mySongUpload" >Upload Track</button>' +
                                    '<div id="myPlayer">' +
                                        '<div id="myElement">Loading the player...</div>' +
                                    '</div>' +
                            '</td>' +
                            '<td id="mmm"> </td>' +
                          '</tr>');
                      var songpath = ""
                      //Parameterized load page and select portion of ID = #MainContent_myLyrics
                      $('.product .myLyricsUrl').load('Lyrics.aspx #MainContent_myLyrics', { ID: ID }, function () {
                          var obj = $('#MainContent_myLyrics').html();


                          if (obj = 'uploadmylyrics') {
                              $('#MainContent_myLyrics').html('<iframe id="iframemyuploadlyricspdf" style="Height:750px; width:580px;" src=""></iframe>').before('<button id="btnuploadmylyrics">Upload PDF version of the Lyrics</button>');
                              // $('#MainContent_myLyrics').html('<button id="btnuploadmylyrics">Upload Lyrics</button>');

                          };

                          $('#myEdit').css("color", "#1E90FF");
                          $('#myEdit').css("font-size", "16px");
                          $('#myEdit').css("position", "absolute");
                          $('#myEdit').css("top", "-160px");
                          $('#myEdit').css("left", "20px");
                          $('#myEdit').css("width", "126px");
                          $('#myEdit').css("height", "40px");

                          $('#mySongUpload').css("color", "red");
                          $('#mySongUpload').css("font-size", "16px");
                          $('#mySongUpload').css("position", "relative");
                          $('#mySongUpload').css("top", "-160px");
                          $('#mySongUpload').css("left", "30px");
                          $('#mySongUpload').css("width", "126px");
                          $('#mySongUpload').css("height", "40px");
                          $('.product').fadeIn(2000);


                          $('#mmm').hide();
                      });

                      $('#btnuploadmylyrics').live('click', function () {
                          window.location.href = 'PasteLyricspg.aspx?ID=' + ID;
                      });

                      $('#myEdit').click(function () {
                          window.location.href = 'Edit.aspx?ID=' + ID;
                      });
                  }
                  else {
                  }
              }, function () {

                  $('.product').remove();
                  $('#myPlayer').remove();

              });

        //        $('#MainContent_GridView1 tr').addClass('formatting');


        $('.listbox').hide();
        $('.userid').keyup(function () {
            var uid = $('.userid').val();
            var data = 'userid=' + uid;


            $.ajax({
                type: "POST",
                url: "ServerResponse.aspx",
                data: data,
                success: function (html) {
                    $('.listbox').show();
                    $('.listbox').css('background', 'white');
                    $('.nameslist').html(html);
                    $('li').hover(function () {
                        $(this).addClass('hover');
                    }, function () {
                        $(this).removeClass('hover');
                    });
                    $('li').click(function () {
                        $('.userid').val($(this).text());
                        $('.listbox').hide();
                    });
                }
            });





            $('.listbox').css('background', 'green');


            return false;
        });
    });




    //***********************************************************************************************************************************************************
</script>




    <style type="text/css">
        .style8
        {
            width: 128px;
            height: 80px;
        }
        .style13
        {
            width: 313px;
        }
        .style14
        {
            width: 18px;
            height: 80px;
        }
        .style16
        {
            width: 17px;
            height: 80px;
        }
        .style17
        {
            width: 148px;
            height: 80px;
        }
        </style>

        <style type="text/css">
          
            .listbox
    {
       
        position:absolute;
        z-index:2;
        top:50px;
       
       
        
        margin-top:95px;
        width: 200px;
        background-color: transparent;
        color: black;
        list-style:none;      
            }
    .nameslist
    {
        position:relative;
      
        z-index:3;
        margin: 0px;
        padding: 0px;
        list-style: none;
           
    }
    .hover
    {
        background-color: #BCF5A9;
        color: blue;
    }
            .userid
            {
                width: 191px;
            }
                        
            
            .hover { background-color: #01ADED; color: Black; font:bold; } 
            
            .tblWoBorder{
        border:none;
        height:50px;
    }
            .style18
            {
                height: 80px;
            }
            
            
            .hoverpaging
            {
                background:#00f; color:#fff;
                }
             .paging
             {
                 margin:5px;
                 }
                 
                 
                 .borderside
                 {
                      border-left:1px solid lightgrey;      
                      border-right:1px solid lightgrey;
                     
                     }
            .auto-style1 {
                width: 63px;
            }
            .auto-style2 {
                width: 59px;
            }
            .auto-style3 {
                width: 95px;
            }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="rightsidebarparent" style="position:relative;"> 
        <div id="logoheads">&nbsp;<br />
        </div>
        <div id="mylogo123"></div>
   


    </div>



    <div class="displaylista">
    <br />
        <div>
            <div style="margin-left:15px; ">

<div id="Adding_table_main_page_top">
<table style="width: 890px" border="0">

<%--<tr style="height:30px;"><td colspan="7"></td><td colspan ="2">
    <div id="MemoBody">
        &nbsp;<div class="listbox">
            <div class="nameslist">
            </div>
        </div>
    </div>

    </td></tr>
<tr>--%>

<td style="width:97px; text-align:right;">Track Name:</td>
<td style="width:97px;"> 
            <asp:TextBox ID="txtTrackName" runat="server" 
                Width="96px"></asp:TextBox></td>
<td style="text-align:right;" class="auto-style2">Artist:</td>
<td style="width:97px;"> 
    <asp:TextBox ID="txtLname" runat="server" 
                Width="95px"></asp:TextBox></td>
<td style="text-align:right;" class="auto-style1">Status</td>
<td class="auto-style2"> <asp:TextBox ID="txtSSNum" runat="server" Width="96px"></asp:TextBox>
        </td>
<td style="width:97px; text-align:right;">Album Name:</td>
<td style="width:97px;"> <asp:TextBox ID="txtAlbum" runat="server" Width="94px"></asp:TextBox>
        </td>
<td class="auto-style3"> 
            <asp:Button ID="btnAdd" runat="server" 
                Text="Add" Width="67px" /></td>


</tr>
    <tr><td colspan="7">
        &nbsp;</td>
        <td>
             &nbsp;</td>
         <td class="auto-style3">
            
    </tr>

</table>
</div>
                </div>
            </div>



    <div id="main_container">
<div id="displaylisth">
        <label id="lblDsplayinfo" >SONG INFORMATION</label>
</div>
 
        
    




    <div class="displaylistb">
    <br />
        <div>
            <div style="margin-left:15px; ">

            <table border="0" style="margin-left: 10px; width: 879px; height: 50px;  ">
                <tr class="">
                    <td class="style8">
                        <asp:Button ID="btnListAll" runat="server" Text="List All" Width="111px" Height="26px" />
                    </td>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style18" id="rb2bk">
                        <asp:RadioButtonList ID="rb2" runat="server" RepeatColumns="4" Width="329px">
                            <asp:ListItem Value="rbTrack">Track</asp:ListItem>
                            <asp:ListItem Value="rbArtist">Artist</asp:ListItem>
                            <asp:ListItem Value="rbStatus">Status</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="style16">
                    </td>
                    <td class="style17">
                         
                        <br />
                        <br />
                        <asp:Button ID="btnFilter" runat="server" Text="Search" ClientIDMode="static" Width="66px" />
                        <strong>&nbsp;<asp:TextBox ID="txtFiltrerID" runat="server" Width="61px"></asp:TextBox></strong>
                    </td>
                </tr>
             
               
            </table>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            <asp:UpdatePanel ID="myupdatepanel" runat="server">
            <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" class="whitecolor" AutoGenerateColumns="False" BorderStyle="None"
                            Width="881px" PageSize="5">
                            <RowStyle Width="883px" Height="25px" Font-Size="11px" BorderStyle="None"  />
                           
                            <SelectedRowStyle  />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-BackColor=""></asp:BoundField>
                                <asp:BoundField DataField="Track" HeaderText="Track" />
                                <asp:BoundField DataField="Artist" HeaderText="Artist" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Album" HeaderText="Album" />
                                
                            </Columns>
                            <HeaderStyle   ForeColor="black" />
                        </asp:GridView>
                        </ContentTemplate>
                        <Triggers >
                      <%--<asp:AsyncPostBackTrigger ControlID="btnFilter"  EventName="click" />--%>
                       <asp:AsyncPostBackTrigger ControlID="rb2" EventName="SelectedIndexChanged" />
                         <%-- <asp:AsyncPostBackTrigger ControlID="btnListAll" EventName="Click" />--%>
                         <%-- <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />--%>
                        </Triggers>
                        </asp:UpdatePanel>
            <br />
            
        </div>
        </div>
    </div>
    <table border="0" style="margin-left: 10px; width: 879px">
     <tr>
                    <td colspan="2">
                    </td>
                    <td align="center" class="style13">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
    
    </table>
       
        <script src="Scripts/jwplayer.js"></script>

</div>

<script type="text/javascript" src="Scripts/jwplayer.js"></script>


       
       

<script type="text/javascript">
    
</script>


       



  
</asp:Content>
