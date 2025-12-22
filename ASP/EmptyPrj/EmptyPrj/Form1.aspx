<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="EmptyPrj.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:TextBox ID="txtname" runat="server" Text=""></asp:TextBox>
                  
            <br />
        <asp:Button ID="Btnclick" runat="server" Text="Click here" OnClick="Btnclick_Click" />
        </div>
    </form>
</body>
</html>
