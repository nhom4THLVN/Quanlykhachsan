<%@ Page Title="" Language="C#" MasterPageFile="~/QLKS.Master" AutoEventWireup="true" CodeBehind="QLKH.aspx.cs" Inherits="QLKSAN.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            margin-left: 80px;
        }
        .style2
        {
            width: 272px;
        }
        .style3
        {
            width: 315px;
            color: #000000;
        }
        .style4
        {
            text-align: center;
            margin-left: 40px;
            color: #3333CC;
        }
        .style5
        {
            background-color: #0099CC;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="style4"> QUẢN LÝ KHÁCH HÀNG</h1>
    <p class="style1"> 
        <asp:Label ID="Label1" runat="server" style="text-align: center; color: #000000;" 
            Text="Tìm kiếm khách hàng "></asp:Label>
        <asp:TextBox ID="txtTimkiem" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="bntTimkiem" runat="server" Text="Tìm kiếm" 
            style="background-color: #0099CC" onclick="bntTimkiem_Click" />
    </p>
    <p class="style1"> 
        <table style="width:52%; height: 212px;" align="center">
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Họ tên khách hàng</td>
                <td class="style2">
                    <asp:TextBox ID="txtHoten" runat="server" Height="21px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Số CMND</td>
                <td class="style2">
                    <asp:TextBox ID="txtCMND" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Giới tính</td>
                <td class="style2">
&nbsp;&nbsp;&nbsp;
                    <asp:RadioButtonList ID="rdbGioitinh" runat="server" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Value="True">Nam</asp:ListItem>
                        <asp:ListItem Value="False">Nữ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Số điện thoại</td>
                <td class="style2">
                    <asp:TextBox ID="txtSDT" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Địa chỉ</td>
                <td class="style2">
                    <asp:TextBox ID="txtDC" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p class="style1"> 
        <asp:Button ID="bntthem" runat="server" Text="Thêm" CssClass="style5" 
            Width="78px" onclick="bntthem_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bntsua" runat="server" Text="Sửa" CssClass="style5" 
            Width="75px" onclick="bntsua_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnxoa" runat="server" Text="Xóa" CssClass="style5" 
            Width="74px" onclick="btnxoa_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bntXoatrong" runat="server" Text="Làm trống" CssClass="style5" 
            Width="85px" onclick="bntXoatrong_Click" />
    </p>
    <p class="style1"> 
        <asp:Label ID="lblThongbao" runat="server" BorderColor="#FF3300" 
            style="color: #FF0000"></asp:Label>
    </p>
    <p class="style1"> 
        <asp:Button ID="bntCo" runat="server" onclick="bntCo_Click" 
            style="background-color: #FF3300" Text="Có" Width="73px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bntKhong" runat="server" onclick="bntKhong_Click" 
            style="color: #000000; background-color: #FF3300" Text="Không" Width="71px" />
    </p>
    <p> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView align="center" ID="gvKH" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gvKH_SelectedIndexChanged" 
            style="height: 115px; margin-bottom: 0px" Width="729px" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên khách hàng" />
                <asp:BoundField DataField="CMND" HeaderText="Số CMND" />
                <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="Sdt" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" />
                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

    </p>
&nbsp;<p> &nbsp;</p>
    
</asp:Content>
