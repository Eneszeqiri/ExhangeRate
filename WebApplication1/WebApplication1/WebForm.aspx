<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="WebApplication1.WebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:Black">
    <form id="form1" runat="server">
        <div>
            <div id="InsertingData" style="background-color: aquamarine; padding: 15px; margin:0 auto; border:solid black 1px; width:30%; text-align:center">
                <p>The only acceptable format to inserting is : dd.mm.yyyy</p>
                Starting Date: <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
                <br/>
                Ending Date: <asp:TextBox ID="EndDate" runat="server"></asp:TextBox>
                <br/><br />
                <asp:Button ID="Show" runat="server" Text="Show" OnClick="Show_Click" Width="160px"  />
                <br/>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            
            <div id="TableData">
                <asp:Table ID="myTable" runat="server" Width="70%" BorderColor="Black" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" BackColor="aquamarine"> 
                <asp:TableRow BackColor="aquamarine" BorderStyle="Solid">
                    <asp:TableCell>State</asp:TableCell>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Valute Name</asp:TableCell>
                    <asp:TableCell>In respective value</asp:TableCell>
                    <asp:TableCell>In denars</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
             
        </div>
    </form>
</body>
</html>
