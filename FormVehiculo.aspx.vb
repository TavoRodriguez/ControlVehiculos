Imports ControlVehiculos.Utils

Public Class FormVehiculo
    Inherits System.Web.UI.Page

    Public Vehiculo As Vehiculo
    Protected dbVehiculo As New dbVehiculo()
    Protected dbHelper As New dbPropietario() ' Para cargar personas en el ddl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Public Sub CargarPersonas()
        ddlPropietario.DataSource = dbHelper.Consulta()
        ddlPropietario.DataTextField = "NombreCompleto"
        ddlPropietario.DataValueField = "IdPropietario"
        ddlPropietario.DataBind()
        ddlPropietario.Items.Insert(0, New ListItem("-- Seleccione una persona --", "0"))
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs)
        Try
            Vehiculo = New Vehiculo() With {
                .Placa = txtPlaca.Text.Trim(),
                .Marca = txtMarca.Text.Trim(),
                .Modelo = txtModelo.Text.Trim(),
                .IdPropietario = Convert.ToInt32(ddlPropietario.SelectedValue)
            }

            dbVehiculo.Create(Vehiculo)
            gvVehiculos.DataBind()
            LimpiarCampos()

            SwalUtils.ShowSwal(Me, "Vehículo creado", "El vehículo se registró correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al crear", "Ocurrió un error al crear el vehículo: " & ex.Message)
        End Try
    End Sub

    Protected Sub gvVehiculos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idVehiculo As Integer = Convert.ToInt32(gvVehiculos.DataKeys(e.RowIndex).Value)
            dbVehiculo.Delete(idVehiculo)
            e.Cancel = True
            gvVehiculos.DataBind()

            SwalUtils.ShowSwal(Me, "Eliminado", "El vehículo fue eliminado correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al eliminar", ex.Message)
        End Try
    End Sub

    Protected Sub gvVehiculos_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Try
            gvVehiculos.EditIndex = e.NewEditIndex
            gvVehiculos.DataBind()
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al editar", ex.Message)
        End Try
    End Sub


    Protected Sub gvVehiculos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        Try
            gvVehiculos.EditIndex = -1
            gvVehiculos.DataBind()
        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al cancelar la edición", ex.Message)
        End Try
    End Sub


    Protected Sub gvVehiculos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim idVehiculo As Integer = Convert.ToInt32(gvVehiculos.DataKeys(e.RowIndex).Value)

            Dim veh As New Vehiculo With {
                .Placa = e.NewValues("Placa").ToString().Trim(),
                .Marca = e.NewValues("Marca").ToString().Trim(),
                .Modelo = e.NewValues("Modelo").ToString().Trim(),
                .IdPropietario = Convert.ToInt32(e.NewValues("IdPropietario")),
                .IdVehiculo = idVehiculo
            }

            dbVehiculo.Update(veh)
            e.Cancel = True
            gvVehiculos.EditIndex = -1
            gvVehiculos.DataBind()

            SwalUtils.ShowSwal(Me, "Actualizado", "El vehículo fue actualizado correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar", ex.Message)
        End Try
    End Sub


    Protected Sub gvVehiculos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = gvVehiculos.SelectedRow()
            Dim idVehiculo As Integer = Convert.ToInt32(row.Cells(2).Text)

            txtPlaca.Text = row.Cells(3).Text.Trim()
            txtMarca.Text = row.Cells(4).Text.Trim()
            txtModelo.Text = row.Cells(5).Text.Trim()
            ddlPropietario.SelectedValue = row.Cells(6).Text.Trim()

            editando.Value = idVehiculo
            btnCrear.Visible = False
            btnActualizar.Visible = True

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al seleccionar", ex.Message)
        End Try
    End Sub


    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim veh As New Vehiculo With {
                .Placa = txtPlaca.Text.Trim(),
                .Marca = txtMarca.Text.Trim(),
                .Modelo = txtModelo.Text.Trim(),
                .IdPropietario = Convert.ToInt32(ddlPropietario.SelectedValue),
                .IdVehiculo = Convert.ToInt32(editando.Value)
            }

            dbVehiculo.Update(veh)
            gvVehiculos.EditIndex = -1
            gvVehiculos.DataBind()

            LimpiarCampos()
            btnCrear.Visible = True
            btnActualizar.Visible = False

            SwalUtils.ShowSwal(Me, "Actualizado", "El vehículo se actualizó correctamente.", "success")

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, "Error al actualizar", ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtPlaca.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        ddlPropietario.SelectedIndex = 0
    End Sub

End Class
