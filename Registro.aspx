<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="ControlVehiculos.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-6 col-md-8">
                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-header bg-primary text-white text-center rounded-top-4">
                        <h3 class="mb-0">
                            <i class="bi bi-person-plus-fill me-2"></i>Registro de Usuario
                        </h3>
                    </div>
                    <div class="card-body p-4">
                        <div class="row g-3">
                            <div class="col-12">
                                <label for="txtUsuario" class="form-label fw-semibold">Nombre de Usuario</label>
                                <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Ingrese su nombre de usuario" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-12">
                                <label for="txtCorreo" class="form-label fw-semibold">Correo Electrónico</label>
                                <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" placeholder="usuario@correo.com" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="txtContrasena" class="form-label fw-semibold">Contraseña</label>
                                <asp:TextBox ID="txtContrasena" TextMode="Password" CssClass="form-control" placeholder="********" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="txtConfirmar" class="form-label fw-semibold">Confirmar Contraseña</label>
                                <asp:TextBox ID="txtConfirmar" TextMode="Password" CssClass="form-control" placeholder="********" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="d-flex justify-content-center mt-4">
                            <asp:Button ID="btnRegistrar" CssClass="btn btn-success px-4 me-3" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                        </div>

                        <asp:Label ID="lblResultado" CssClass="text-center d-block mt-3 fw-bold text-success" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

