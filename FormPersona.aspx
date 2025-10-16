<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="editando" runat="server" />    

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-8 col-md-10">
                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-header bg-primary text-white text-center rounded-top-4">
                        <h3 class="mb-0"><i class="bi bi-person-lines-fill me-2"></i>Gestión de Personas</h3>
                    </div>
                    <div class="card-body p-4">
                        <div class="row g-3">
                            <div class="col-md-6">
                                <label for="txtNombre" class="form-label fw-semibold">Nombre</label>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtApellido1" class="form-label fw-semibold">Primer Apellido</label>
                                <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtApellido2" class="form-label fw-semibold">Segundo Apellido</label>
                                <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="ddlNacionalidad" class="form-label fw-semibold">Nacionalidad</label>
                                <asp:DropDownList ID="ddlNacionalidad" CssClass="form-select" runat="server">
                                    <asp:ListItem Value="" Selected="True">Seleccione una nacionalidad...</asp:ListItem>
                                    <asp:ListItem>Costarricense</asp:ListItem>
                                    <asp:ListItem>Estadounidense</asp:ListItem>
                                    <asp:ListItem>Colombiano</asp:ListItem>
                                    <asp:ListItem>Español</asp:ListItem>
                                    <asp:ListItem>Canadiense</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label for="txtFechaNac" class="form-label fw-semibold">Fecha de Nacimiento</label>
                                <asp:TextBox ID="txtFechaNac" TextMode="Date" CssClass="form-control" placeholder="Fecha de Nacimiento" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtTelefono" class="form-label fw-semibold">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" TextMode="Phone" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
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
                        <h5 class="mb-0"><i class="bi bi-table me-2"></i>Listado de Personas</h5>
                    </div>
                    <div class="card-body p-0">
                        <asp:GridView ID="gvPersonas" CssClass="table table-striped table-hover align-middle mb-0" 
                            runat="server" AutoGenerateColumns="False" DataKeyNames="IdPersona"
                            DataSourceID="SqlDataSource1" 
                            OnRowDeleting="gvPersonas_RowDeleting" 
                            OnRowEditing="gvPersonas_RowEditing" 
                            OnRowCancelingEdit="gvPersonas_RowCancelingEdit" 
                            OnRowUpdating="gvPersonas_RowUpdating" 
                            OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
                            
                            <HeaderStyle CssClass="table-primary text-center" />
                            <RowStyle CssClass="text-center" />

                            <Columns>
                                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-outline-success btn-sm" />
                                <asp:CommandField ShowEditButton="true" EditText="Editar" UpdateText="Guardar" CancelText="Cancelar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" />
                                <asp:BoundField DataField="IdPersona" HeaderText="ID" ReadOnly="True" SortExpression="IdPersona" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" SortExpression="Apellido1" />
                                <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" SortExpression="Apellido2" />
                                <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-outline-danger btn-sm" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" 
        SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>
</asp:Content>

