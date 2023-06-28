<%@ Page Title="" Language="C#" MasterPageFile="~/Mernu.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="UI.Principal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
   <%-- <img src="img/FONDO1.jpg" class="img-responsive"  style="width:100%;height:100%;"/>--%>
  <script>
      $(document).ready(function () {
          var NOMBRES = ($.session.get('SESSION_NOMBRES'));

          if (typeof NOMBRES === "undefined") {
              location.href = '../Login.aspx';

          }
      });
  </script>
</asp:Content>

