<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostBackEg.aspx.cs" Inherits="EmptyPrj.PostBackEg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtcount" runat="server" ></asp:TextBox>
            <br />
            <asp:Button ID="BtnCount" runat="server" Text="Click for Count" OnClick="BtnCount_Click" />
        </div>
    </form>
</body>
</html>
