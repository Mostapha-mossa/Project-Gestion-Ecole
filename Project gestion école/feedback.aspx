<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="Project_gestion_école.feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><h1 class="mt-4">feedback</h1>
&nbsp;     <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="280px" Width="626px"></asp:TextBox>

        </div>
         <div>  <asp:Button ID="Button2" runat="server" Text="envoyer" CssClass="btn-danger" OnClick="Button3_Click"  />
             </div>   
    </form>
</body>
</html>
