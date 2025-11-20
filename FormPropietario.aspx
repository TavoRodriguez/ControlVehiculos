<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="ControlVehiculos.FormPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server" />

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-8 col-md-10">
                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-header bg-primary text-white text-center rounded-top-4">
                        <h3 class="mb-0"><i class="bi bi-person-vcard me-2"></i>Gestión de Propietarios</h3>
                    </div>

                    <div class="card-body p-4">

                        <div class="row g-3">

                            <div class="col-md-12">
                                <label for="ddlPersona" class="form-label fw-semibold">Persona</label>
                                <asp:DropDownList ID="ddlPersona" CssClass="form-select" runat="server">
                                    <asp:ListItem Value="0">Seleccione una persona...</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="d-flex justify-content-center mt-4">
                            <asp:Button ID="btnCrear" CssClass="btn btn-success me-3 px-4" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                            <asp:Button ID="btnActualizar" CssClass="btn btn-warning px-4" runat="server" Text="Actualizar" Visible="False" OnClick="btnActualizar_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-12">
                <div class="card shadow-sm border-0 rounded-4">
                    <div class="card-header bg-dark text-white rounded-top-4">
                        <h5 class="mb-0"><i class="bi bi-table me-2"></i>Listado de Propietarios</h5>
                    </div>
                    <div class="card-body p-0">

                        <asp:GridView ID="gvPropietarios" CssClass="table table-striped table-hover align-middle mb-0"
                            runat="server" AutoGenerateColumns="False" DataKeyNames="IdPropietario, IdPersona"
                            DataSourceID="SqlDataSource1"
                            OnRowDeleting="gvPropietarios_RowDeleting"
                            OnRowEditing="gvPropietarios_RowEditing"
                            OnRowCancelingEdit="gvPropietarios_RowCancelingEdit"
                            OnRowUpdating="gvPropietarios_RowUpdating"
                            OnSelectedIndexChanged="gvPropietarios_SelectedIndexChanged">

                            <HeaderStyle CssClass="table-primary text-center" />
                            <RowStyle CssClass="text-center" />

                            <Columns>

                                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar"
                                    ControlStyle-CssClass="btn btn-outline-success btn-sm" />

                                <asp:CommandField ShowEditButton="true" EditText="Editar" UpdateText="Guardar"
                                    CancelText="Cancelar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" />

                                <asp:BoundField DataField="IdPropietario" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Propietario" />

                                <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" Visible="false" />

                                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar"
                                    ControlStyle-CssClass="btn btn-outline-danger btn-sm" />

                            </Columns>

                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>

    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="
            SELECT 
                p.IdPropietario,
                p.IdPersona,
                per.Nombre + ' ' + per.Apellido1 + ' ' + per.Apellido2 AS NombreCompleto
            FROM Propietarios p
            INNER JOIN Personas per ON p.IdPersona = per.IdPersona">
    </asp:SqlDataSource>

</asp:Content>
