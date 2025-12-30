<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrossPageIndex.aspx.cs" Inherits="Navigation_Prj.CrossPageIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td> Name :</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Btnsubmit" runat="server" Text="Move to Next Page" PostBackUrl="~/CrossPage.aspx" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
