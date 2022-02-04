<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="e_comcerce.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div style="display: flex; flex-direction: row; flex-wrap: wrap; " >
    
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="https://www.lluviadigital.com/wp-content/uploads/2020/02/e-commerce-que-es-Lluvia-Digital.jpg" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Registrar Producto</h5>
            <p class="card-text"> Aqui podrá registrar los productos que quiere vender </p>
           
            <a href="RegistroProducto.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>
   
        <tr>

    <div class="card" width="100%" style="border-radius:20px; width: 18rem;border: solid 1px black; padding: 10px; margin: 15px;  ">
        <img style="border-radius: 20px;" src="" class="card-img-top" alt="..."  width="158" height="158"  >
        <div class="card-body">
            <h5 class="card-title">Eliminar o Modificar Producto</h5>
            <p class="card-text"> Aqui podrá eliminar o modificar un producto de su commerce</p>
           
            <a href="ProductosAdmin.aspx"  style="border-radius:20px;" class="btn btn-success">Click Acá!</a>
        </div>
    </div>
        </tr>



        </div>

</asp:Content>
