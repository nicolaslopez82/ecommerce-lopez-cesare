<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_comcerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <%--<form id="form1" runat="server">--%>
            <div class="card-body login-card-body">
              <p class="login-box-msg">Login para iniciar sesion</p> 
                <div class="form-box" id="login-box">
                    <asp:Login ID="Login1" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
                        <LayoutTemplate>
                           <div class="input-group mb-3">
                              <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Ingrese usuario..."></asp:TextBox>
                                <div class="input-group-append">
                                  <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                  </div>
                                </div>
                             </div>

                             <div class="input-group mb-3">
                                <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Ingrese clave..." TextMode="Password"></asp:TextBox>
                                  <div class="input-group-append">
                                    <div class="input-group-text">
                                      <span class="fas fa-lock"></span>
                                    </div>
                                  </div>
                              </div>

                             <div class="row">
                              <asp:Label ID="LblError" runat="server" CssClass="alert-danger" ></asp:Label>
                             </div>

                             <div class="row">                                
                                <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Inicar Sesion" CssClass="btn bg-olive btn-block" />
                             </div>
                    
                      </LayoutTemplate>
                    </asp:Login>
                </div>
                <div class="row">
                  <br>
                </div>
                  <p class="mb-1">
                    <a href="forgot-password.html">Olvide mi password</a>
                  </p>
                  <p class="mb-0">
                    <a href="Registro.aspx" class="text-center">Registrar como nuevo miembro</a>
                  </p>
              </div>
        <%--</form>--%>
    </div>




     <%-- <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
  </div>
  <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>--%>

</asp:Content>
