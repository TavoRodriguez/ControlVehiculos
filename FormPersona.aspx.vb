Public Class FormPersona
    Inherits System.Web.UI.Page
    Public Persona As Persona
    Protected dbPersona As New dbPersona()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs)
        Persona = New Persona()
        Persona.Nombre = txtNombre.Text.Trim()
        Persona.Apellido1 = txtApellido1.Text.Trim()
        Persona.Apellido2 = txtApellido2.Text.Trim()
        Persona.Nacionalidad = ddlNacionalidad.SelectedValue
        Persona.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text)
        Persona.Telefono = txtTelefono.Text.Trim()
        dbPersona.Create(Persona)
        gvPersonas.DataBind()
        LimpiarCampos()
    End Sub


    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idPersona As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            dbPersona.Delete(idPersona)
            e.Cancel = True
            gvPersonas.DataBind()
        Catch ex As Exception
            lblResultado.Text = "Error al eliminar la persona: " & ex.Message
        End Try
    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        Try
            gvPersonas.EditIndex = -1
            gvPersonas.DataBind()
        Catch ex As Exception
            lblResultado.Text = "Error al cancelar la edición: " & ex.Message
        End Try
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
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
    End Sub


    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim idPersona As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()
        txtNombre.Text = row.Cells(3).Text.Trim()
        txtApellido1.Text = row.Cells(4).Text.Trim()
        txtApellido2.Text = row.Cells(5).Text.Trim()
        ddlNacionalidad.SelectedValue = row.Cells(6).Text.Trim()
        txtFechaNac.Text = Convert.ToDateTime(row.Cells(7).Text.Trim()).ToString("yyyy-MM-dd")
        txtTelefono.Text = row.Cells(8).Text.Trim()
        editando.Value = idPersona
        btnCrear.Visible = False
        btnActualizar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim persona As New Persona With {
        .Nombre = txtNombre.Text.Trim(),
        .Apellido1 = txtApellido1.Text.Trim(),
        .Apellido2 = txtApellido2.Text.Trim(),
        .Nacionalidad = ddlNacionalidad.SelectedValue,
        .FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text.Trim()).ToString("yyyy-MM-dd"),
        .Telefono = txtTelefono.Text.Trim(),
        .IdPersona = Convert.ToInt32(editando.Value)
        }
        dbPersona.Update(persona)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
        limpiarCampos()
        btnCrear.Visible = True
        btnActualizar.Visible = False
    End Sub
    Private Sub limpiarCampos()
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtFechaNac.Text = DateTime.Today.ToString("yyyy-MM-dd")
        txtTelefono.Text = String.Empty
        ddlNacionalidad.SelectedIndex = 0
    End Sub

End Class