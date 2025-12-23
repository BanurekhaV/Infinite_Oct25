<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="ValidationsPrj.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .selfstyle{
            height:400px;
            margin-left:40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="selfstyle">
            <h1 style="color:darkblue;font-size:20px;text-align:center">Registration Form</h1>
            <br />

            Name : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="txtname" ForeColor="Red" ValidationGroup="regn" >*</asp:RequiredFieldValidator>
            <br /> <br />
            Age : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtage" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtage" Display="Dynamic" ErrorMessage="Age is must" ForeColor="Red" ValidationGroup="regn">*</asp:RequiredFieldValidator>
&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtage" Display="Dynamic" ErrorMessage="Age has to be between 21 and 50 only" ForeColor="Red" MaximumValue="50" MinimumValue="21" Type="Integer" ValidationGroup="regn" >*</asp:RangeValidator>
            <br /><br />
            Password :  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpass" ErrorMessage="Password is required" ForeColor="Red" ValidationGroup="regn" >*</asp:RequiredFieldValidator>
           
            <br /><br />
            Confirm Password : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcpass" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcpass" Display="Dynamic" ErrorMessage="Confirm password is must" ForeColor="Red" ValidationGroup="regn" >*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass" ControlToValidate="txtcpass" Display="Dynamic" ErrorMessage="Password and Confirm password mismatch" ForeColor="Red" ValidationGroup="regn" >*</asp:CompareValidator>
            <br /><br />
            Email : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Email is required" ForeColor="Red" ValidationGroup="regn">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Mail Format incorrect" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="regn">*</asp:RegularExpressionValidator>
            <br /><br />
            <asp:Button ID="btnregister" Text="Register" runat="server" OnClick="btnregister_Click" ValidationGroup="regn" />

            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="regn" />

        </div>
        <br />
        <hr />
        <div>
            <h1 style="color:crimson;text-align:center;"> Login Form</h1>
            <br />
            Login Name : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtlogin" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlogin" ErrorMessage="Login name must" ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
            <br />
            Password :&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtlpass" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtlpass" ErrorMessage="Password must" ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnlogin" Text="Login" runat="server"  ValidationGroup="login"/>
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="login" />
        </div>
    </form>
</body>
</html>
