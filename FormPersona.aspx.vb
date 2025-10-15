Public Class FormPersona
    Inherits System.Web.UI.Page
    Public Persona As Persona
    Protected dbPersona As New dbPersona()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs)
        Persona = New Persona()
        Persona.Nombre = txtNombre.Text
        Persona.Apellido1 = txtApellido.Text
        Persona.Apellido2 = Convert.ToInt32(txtEdad.Text)
        Persona.Nacionalidad = "CR"
        Persona.FechaNacimiento = DateTime.Now
        Persona.Telefono = "88888888"
        dbPersona.Create(Persona)
        gvPersonas.DataBind()
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
        Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim persona As New Persona With {
        .Nombre = e.NewValues("NOMBRE").ToString(),
        .Apellido = e.NewValues("APELLIDO").ToString(),
        .Edad = Convert.ToInt32(e.NewValues("EDAD")),
        .Id = id
        }
        dbHelper.Update(persona)
        e.Cancel = True
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()

    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()
        txtNombre.Text = row.Cells(3).Text
        txtApellido.Text = row.Cells(4).Text
        txtEdad.Text = row.Cells(5).Text
        editando.Value = id

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim persona As New Persona With {
        .Nombre = txtNombre.Text(),
        .Apellido = txtApellido.Text(),
        .Edad = txtEdad.Text,
        .Id = editando.Value
        }
        dbHelper.Update(persona)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
    End Sub

End Class