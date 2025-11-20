<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVehiculo.aspx.vb" Inherits="ControlVehiculos.FormVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server" />

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-8 col-md-10">
                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-header bg-primary text-white text-center rounded-top-4">
                        <h3 class="mb-0"><i class="bi bi-car-front-fill me-2"></i>Gestión de Vehículos</h3>
                    </div>

                    <div class="card-body p-4">
                        <div class="row g-3">

                            <div class="col-md-6">
                                <label for="txtPlaca" class="form-label fw-semibold">Placa</label>
                                <asp:TextBox ID="txtPlaca" CssClass="form-control" placeholder="Placa" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="txtMarca" class="form-label fw-semibold">Marca</label>
                                <asp:TextBox ID="txtMarca" CssClass="form-control" placeholder="Marca" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="txtModelo" class="form-label fw-semibold">Modelo</label>
                                <asp:TextBox ID="txtModelo" CssClass="form-control" placeholder="Modelo" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="ddlPropietario" class="form-label fw-semibold">Propietario</label>
                                <asp:DropDownList ID="ddlPropietario" CssClass="form-select" runat="server">
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="d-flex justify-content-center mt-4">
                            <asp:Button ID="btnCrear" CssClass="btn btn-success me-3 px-4" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                            <asp:Button ID="btnActualizar" CssClass="btn btn-warning px-4" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Visible="False" />
                        </div>

                        <asp:Label ID="lblResultado" CssClass="text-center d-block mt-3 fw-bold text-success" runat="server" Text=""></asp:Label>

                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-5">
            <div class="col-12">
                <div class="card shadow-sm border-0 rounded-4">
                    <div class="card-header bg-dark text-white rounded-top-4">
                        <h5 class="mb-0"><i class="bi bi-table me-2"></i>Listado de Vehículos</h5>
                    </div>

                    <div class="card-body p-0">
                        <asp:GridView ID="gvVehiculos" CssClass="table table-striped table-hover align-middle mb-0"
                            runat="server" AutoGenerateColumns="False" DataKeyNames="IdVehiculo"
                            DataSourceID="SqlDataSourceVehiculos"
                            OnRowDeleting= "gvVehiculos_RowDeleting"
                            OnRowEditing= "gvVehiculos_RowEditing"
                            OnRowCancelingEdit= "gvVehiculos_RowCancelingEdit"
                            OnRowUpdating= "gvVehiculos_RowUpdating"
                            OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged">

                            <HeaderStyle CssClass="table-primary text-center" />
                            <RowStyle CssClass="text-center" />

                            <Columns>
                                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-outline-success btn-sm" />
                                <asp:CommandField ShowEditButton="true" EditText="Editar" UpdateText="Guardar" CancelText="Cancelar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" />

                                <asp:BoundField DataField="IdVehiculo" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Placa" HeaderText="Placa" />
                                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                <asp:BoundField DataField="IdPropietario" HeaderText="Propietario" />

                                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-outline-danger btn-sm" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <asp:SqlDataSource ID="SqlDataSourceVehiculos" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="SELECT * FROM Vehiculos">
    </asp:SqlDataSource>

</asp:Content>

