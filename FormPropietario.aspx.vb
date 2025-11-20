Imports ControlVehiculos.Utils

Public Class FormPropietario
    Inherits System.Web.UI.Page

    Public Propietario As Propietario
    Protected dbPropietario As New dbPropietario()
    Protected dbPersona As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Private Sub CargarPersonas()
        Try
            ddlPersona.DataSource = dbPersona.Consulta()
            ddlPersona.DataTextField = "NombreCompleto"
            ddlPersona.DataValueField = "IdPersona"
            ddlPersona.DataBind()

            ddlPersona.Items.Insert(0, New ListItem("-- Seleccione una persona --", "0"))

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al cargar personas", ex.Message)
        End Try
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs)
        Try
            If ddlPersona.SelectedValue = "0" Then
                SwalUtils.ShowSwal(Me, "Advertencia", "Debe seleccionar una persona.", "warning")
                Return
            End If

            Propietario = New Propietario() With {
                .IdPersona = Convert.ToInt32(ddlPersona.SelectedValue)
            }

            dbPropietario.Create(Propietario)
            gvPropietarios.DataBind()
            LimpiarCampos()

            SwalUtils.ShowSwal(Me, "Propietario creado", "El propietario se registró correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al crear propietario", ex.Message)
        End Try
    End Sub

    Protected Sub gvPropietarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idPropietario As Integer = Convert.ToInt32(gvPropietarios.DataKeys(e.RowIndex).Value)

            dbPropietario.Delete(idPropietario)
            e.Cancel = True
            gvPropietarios.DataBind()

            SwalUtils.ShowSwal(Me, "Eliminado", "El propietario fue eliminado correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al eliminar propietario", ex.Message)
        End Try
    End Sub

    Protected Sub gvPropietarios_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Try
            gvPropietarios.EditIndex = e.NewEditIndex
            gvPropietarios.DataBind()
            CargarDDL_En_Grid(e.NewEditIndex)

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al iniciar edición", ex.Message)
        End Try
    End Sub


    Private Sub CargarDDL_En_Grid(rowIndex As Integer)
        Try
            Dim ddl As DropDownList = CType(gvPropietarios.Rows(rowIndex).FindControl("ddlPersonaEdit"), DropDownList)

            If ddl IsNot Nothing Then
                ddl.DataSource = dbPersona.Consulta()
                ddl.DataTextField = "NombreCompleto"
                ddl.DataValueField = "IdPersona"
                ddl.DataBind()

                Dim idPersonaActual As Integer = Convert.ToInt32(gvPropietarios.DataKeys(rowIndex)("IdPersona"))
                ddl.SelectedValue = idPersonaActual.ToString()
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al cargar datos en edición", ex.Message)
        End Try
    End Sub

    Protected Sub gvPropietarios_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        Try
            gvPropietarios.EditIndex = -1
            gvPropietarios.DataBind()

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al cancelar edición", ex.Message)
        End Try
    End Sub

    Protected Sub gvPropietarios_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim idPropietario As Integer = Convert.ToInt32(gvPropietarios.DataKeys(e.RowIndex).Value)
            Dim ddl As DropDownList = CType(gvPropietarios.Rows(e.RowIndex).FindControl("ddlPersonaEdit"), DropDownList)

            Dim propietario As New Propietario With {
                .IdPropietario = idPropietario,
                .IdPersona = Convert.ToInt32(ddl.SelectedValue)
            }

            dbPropietario.Update(propietario)

            e.Cancel = True
            gvPropietarios.EditIndex = -1
            gvPropietarios.DataBind()

            SwalUtils.ShowSwal(Me, "Actualizado", "La información del propietario fue actualizada correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar propietario", ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        ddlPersona.SelectedIndex = 0
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim propietario As New Propietario With {
                .IdPersona = Convert.ToInt32(ddlPersona.SelectedValue),
                .IdPropietario = Convert.ToInt32(editando.Value)
            }

            dbPropietario.Update(propietario)
            gvPropietarios.EditIndex = -1
            gvPropietarios.DataBind()
            LimpiarCampos()
            btnCrear.Visible = True
            btnActualizar.Visible = False

            SwalUtils.ShowSwal(Me, "Actualizado", "El propietario se actualizó correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar", ex.Message)
        End Try
    End Sub

    Protected Sub gvPropietarios_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim key As DataKey = gvPropietarios.SelectedDataKey

            Dim idPropietario As Integer = key("IdPropietario")
            Dim idPersona As Integer = key("IdPersona")

            editando.Value = idPropietario.ToString()
            ddlPersona.SelectedValue = idPersona.ToString()

            btnCrear.Visible = False
            btnActualizar.Visible = True

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al seleccionar propietario", ex.Message)
        End Try
    End Sub

End Class
