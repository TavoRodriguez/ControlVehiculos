<%@ Page Title="Inicio de Sesión" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ControlVehiculos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-5 col-md-7">
                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-header bg-primary text-white text-center rounded-top-4">
                        <h3 class="mb-0">
                            <i class="bi bi-box-arrow-in-right me-2"></i>Inicio de Sesión
                        </h3>
                    </div>

                    <div class="card-body p-4">
                        <div class="mb-3">
                            <label for="txtUsuario" class="form-label fw-semibold">Usuario</label>
                            <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Ingrese su usuario" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtContrasena" class="form-label fw-semibold">Contraseña</label>
                            <asp:TextBox ID="txtContrasena" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña" runat="server"></asp:TextBox>
                        </div>

                        <div class="d-flex justify-content-center mt-4">
                            <asp:Button ID="btnLogin" CssClass="btn btn-success px-5" runat="server" Text="Ingresar" OnClick ="btnLogin_Click" />
                        </div>

                        <asp:Label ID="lblMensaje" CssClass="text-center d-block mt-3 fw-bold text-danger" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

