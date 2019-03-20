<%@ Page Title="" Language="C#" MasterPageFile="~/QLKS.Master" AutoEventWireup="true" CodeBehind="Thuephong.aspx.cs" Inherits="QLKSAN.Thuephong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
    {
            width: 320px;
            text-align: left;
            margin-left: 40px;
        }
        .style2
        {
            height: 20px;
            text-align: right;
            width: 522px;
        }
        .style3
        {
            width: 320px;
            height: 20px;
        }
        .style5
        {
            text-align: right;
            width: 522px;
        }
        .style6
        {
            height: 21px;
            text-align: right;
            width: 522px;
        }
        .style7
        {
            width: 320px;
            height: 21px;
            margin-left: 40px;
        }
        .style8
        {
            color: #0000FF;
        }
        .style9
        {
            font-weight: bold;
            background-color: #0099CC;
        }
        .style10
        {
            width: 522px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
    
        <h1>
            <span class="style8">THUÊ PHÒNG</span></h1>
    
        <table style="width:84%; height: 216px;">
            <tr>
                <td class="style5">Tìm kiếm Khách hàng</td>
                <td class="style1">
                    <asp:TextBox ID="txtTimkiem" runat="server" Width="171px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="bntTimkiem" runat="server" CssClass="style9" Text="Tìm kiếm" 
                        onclick="bntTimkiem_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2"><strong><em style="text-align: right">Thông tin thuê phòng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </em></strong></td>
                <td class="style3"></td>
            </tr>
            <tr>
                <td class="style5">Mã phòng</td>
                <td class="style1">
                    <asp:DropDownList ID="ddlMaphong" runat="server" Height="21px" Width="137px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style5">Mã nhân viên</td>
                <td class="style1">
                    <asp:TextBox ID="txtmanhanvien" runat="server" Width="211px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">Số CMND</td>
                <td class="style1">
                    <asp:TextBox ID="txtCMND" runat="server" Width="211px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">Ngày thuê</td>
                <td class="style1">
                    <asp:TextBox ID="txtNgaythue" runat="server" Width="211px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style10">&nbsp;</td>
                <td class="style1">
                    <asp:Button ID="btnThuephong" runat="server" Text="Thuê phòng" 
                        OnClick="Button1_Click" CssClass="style9" />
                </td>
            </tr>
            <tr>
                <td class="style10">&nbsp;</td>
                <td class="style1">
                    <asp:Label ID="lblThongbao" runat="server" style="color: #FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6"><strong><em><span class="auto-style5">Thông tin khách hàng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></em></strong></td>
                <td class="style7"></td>
            </tr>
        </table>
    
        <asp:GridView align="center" ID="gvKH" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gvKH_SelectedIndexChanged" 
            style="height: 115px; margin-bottom: 0px" Width="729px" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên khách hàng" />
                <asp:BoundField DataField="CMND" HeaderText="Số CMND" />
                <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="Sdt" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" />
                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    
        <br />
        <br />
        <br />
    
    </div>
        
</asp:Content>
 