<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="BlackList.UserSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" style="margin-right: 0px; margin-top: 0px; margin-bottom: 4px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" style="margin-top: 0px" Text="Search" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" EmptyDataText="Sorry, there is no user like that" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Hometown" HeaderText="Hometown" SortExpression="Hometown" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BlackListDBConnectionString1 %>" SelectCommand="SELECT [Hometown], [UserName] FROM [AspNetUsers] WHERE ([UserName] LIKE '%' + @UserName + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="UserName" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
