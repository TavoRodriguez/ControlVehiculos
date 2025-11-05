Imports ControlVehiculos.Utils

Public Class FormPersona
    Inherits System.Web.UI.Page

    Public Persona As Persona
    Protected dbPersona As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs)
        Try
            Persona = New Persona() With {
                .Nombre = txtNombre.Text.Trim(),
                .Apellido1 = txtApellido1.Text.Trim(),
                .Apellido2 = txtApellido2.Text.Trim(),
                .Nacionalidad = ddlNacionalidad.SelectedValue,
                .FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text),
                .Telefono = txtTelefono.Text.Trim()
            }

            dbPersona.Create(Persona)
            gvPersonas.DataBind()
            LimpiarCampos()

            SwalUtils.ShowSwal(Me, "Persona creada", "La persona se registró correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al crear", "Ocurrió un error al crear la persona: " & ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idPersona As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            dbPersona.Delete(idPersona)
            e.Cancel = True
            gvPersonas.DataBind()

            SwalUtils.ShowSwal(Me, "Eliminado", "La persona fue eliminada correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al eliminar", ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Try
            gvPersonas.EditIndex = e.NewEditIndex
            gvPersonas.DataBind()
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al editar", ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        Try
            gvPersonas.EditIndex = -1
            gvPersonas.DataBind()
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al cancelar la edición", ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim idPersona As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            Dim persona As New Persona With {
                .Nombre = e.NewValues("Nombre").ToString().Trim(),
                .Apellido1 = e.NewValues("Apellido1").ToString().Trim(),
                .Apellido2 = e.NewValues("Apellido2").ToString().Trim(),
                .Nacionalidad = e.NewValues("Nacionalidad").ToString().Trim(),
                .FechaNacimiento = Convert.ToDateTime(e.NewValues("FechaNacimiento")),
                .Telefono = e.NewValues("Telefono").ToString().Trim(),
                .IdPersona = idPersona
            }

            dbPersona.Update(persona)
            e.Cancel = True
            gvPersonas.EditIndex = -1
            gvPersonas.DataBind()

            SwalUtils.ShowSwal(Me, "Actualizado", "La información de la persona fue actualizada correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar", ex.Message)
        End Try
    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = gvPersonas.SelectedRow()
            Dim idPersona As Integer = Convert.ToInt32(row.Cells(2).Text)
            Dim persona As New Persona()

            txtNombre.Text = row.Cells(3).Text.Trim()
            txtApellido1.Text = row.Cells(4).Text.Trim()
            txtApellido2.Text = row.Cells(5).Text.Trim()
            ddlNacionalidad.SelectedValue = row.Cells(6).Text.Trim()
            txtFechaNac.Text = Convert.ToDateTime(row.Cells(7).Text.Trim()).ToString("yyyy-MM-dd")
            txtTelefono.Text = row.Cells(8).Text.Trim()

            editando.Value = idPersona
            btnCrear.Visible = False
            btnActualizar.Visible = True
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al seleccionar", ex.Message)
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim persona As New Persona With {
                .Nombre = txtNombre.Text.Trim(),
                .Apellido1 = txtApellido1.Text.Trim(),
                .Apellido2 = txtApellido2.Text.Trim(),
                .Nacionalidad = ddlNacionalidad.SelectedValue,
                .FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text.Trim()),
                .Telefono = txtTelefono.Text.Trim(),
                .IdPersona = Convert.ToInt32(editando.Value)
            }

            dbPersona.Update(persona)
            gvPersonas.EditIndex = -1
            gvPersonas.DataBind()
            LimpiarCampos()
            btnCrear.Visible = True
            btnActualizar.Visible = False

            SwalUtils.ShowSwal(Me, "Actualizado", "La persona se actualizó correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar", ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtFechaNac.Text = DateTime.Today.ToString("yyyy-MM-dd")
        txtTelefono.Text = String.Empty
        ddlNacionalidad.SelectedIndex = 0
    End Sub
End Class
