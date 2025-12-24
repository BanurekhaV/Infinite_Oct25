<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MasterPage_Prj.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <br />
    <asp:TextBox ID="txtdata" runat="server"></asp:TextBox>
    <asp:Button ID="btnclick" runat="server" Text="click" />

</asp:Content>
