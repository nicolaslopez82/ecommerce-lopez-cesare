<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_comcerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <h2 class="form-signin-heading col-sm-10">Please sign in</h2>
        <asp:Login ID="Login" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
            <LayoutTemplate>
                <div class="form-group">
                    <label for="UserName" class="col-sm-2 control-label">Email</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Ingrese Email..."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Password" class="col-sm-2 control-label">Password</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Ingrese clave..." TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox">
                                Recordarme
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <%--<button type="submit" class="btn btn-default">Login</button>--%>
                        <%--<asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" cssclass="btn btn-primary"/>--%>
                        <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesion" CssClass="btn btn-primary" />
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>
