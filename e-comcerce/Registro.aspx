<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="e_comcerce.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>UTN E-Commerce | Registrar</title>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
   <div class="register-box text-center">
  <div class="register-logo">
    <a href="/index.html"><b>UTN</b>-E-Commerce</a>
  </div>
    <!-- /.login-logo -->
    <div class="card text-center">      
        <div class="card-body login-card-body text-center">
          <p class="login-box-msg">Registrar Usuario</p> 
            <div class="form-box text-center" id="login-box">                
                    <LayoutTemplate align="center">
                       <div class="input-group mb-3">
                          <asp:TextBox ID="RegisterNombre" runat="server" CssClass="form-control" style="align: center" placeholder="Ingrese nombre..."></asp:TextBox>
                          <div class="input-group-append">
                            <div class="input-group-text">
                              <span class="fas fa-user"></span>
                            </div>
                          </div>
                        </div>

                         <div class="input-group mb-3">
                            <asp:TextBox ID="RegisterApellido" runat="server" CssClass="form-control" placeholder="Ingrese apellido..."></asp:TextBox>
                            <div class="input-group-append">
                              <div class="input-group-text">
                                <span class="fas fa-user"></span>
                              </div>
                            </div>
                          </div>
		                  <div class="input-group mb-3">
                            <asp:TextBox ID="RegisterDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI..."></asp:TextBox>
                            <div class="input-group-append">
                              <div class="input-group-text">
                                <span class="fas fa-user"></span>
                              </div>
                            </div>
                          </div>
                          <div class="input-group mb-3">                            
                            <asp:TextBox ID="RegisterUsuario" runat="server" CssClass="form-control" placeholder="Ingrese Usuario..."></asp:TextBox>
                            <div class="input-group-append">
                              <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                              </div>
                            </div>
                          </div>
                          <div class="input-group mb-3">
                            <asp:TextBox ID="RegisterPassword" runat="server" CssClass="form-control" placeholder="Ingrese password..." TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                              <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                              </div>
                            </div>
                          </div>
                          <div class="input-group mb-3">
                           <asp:TextBox ID="RegisterRePassword" runat="server" CssClass="form-control" placeholder="Confirme password..." TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                              <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                              </div>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col-8">
                              <div class="icheck-primary">
                                <input type="checkbox" id="agreeTerms" name="terms" value="agree"/>
                                <label for="agreeTerms">
                                 Acepto los terminos <a href="#">terminos</a>
                                </label>
                              </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-4">
                              <%--<button type="submit" class="btn btn-primary btn-block">Registrar</button>--%>
                               <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-block"/>
                            </div>
                            <!-- /.col -->
                          </div>                          
                  </LayoutTemplate>          
            </div>            
          </div>
      
     </div>
    <!-- /.login-card-body -->
    </div>
<!-- /.login-box -->
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
