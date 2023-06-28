<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mostrar_Fatura.aspx.cs" Inherits="UI.Vista_Reportes.Mostrar_Fatura" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Style="width: 900px; height: 900px">
            </rsweb:ReportViewer>
            
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
