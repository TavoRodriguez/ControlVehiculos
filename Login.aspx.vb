Imports ControlVehiculos.Utils
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim usuario = txtUsuario.Text.Trim()
        Dim password = txtContrasena.Text
        Dim encrypter As New Simple3Des("MiClaveSecreta123")
        Dim pass As String = encrypter.EncryptData(password)
        Dim dbHelper As New dbLogin()
        Dim isValidLogin = dbHelper.ValidateLogin(usuario, pass)
        If usuario = "" Or password = "" Then
            SwalUtils.ShowSwalError(Me, "Campos incompletos", "Por favor complete todos los campos obligatorios.")
            Return
        End If
        If isValidLogin Then
            ' Inicio de sesión exitoso
            Dim User As Usuario = dbHelper.GetUser(usuario)
            Session("Usuario") = User
            If User.Rol = "2" Then
                Response.Redirect("Admin.aspx")
                Return
            End If
            Response.Redirect("Home.aspx")

        Else
            ' Credenciales incorrectas
            SwalUtils.ShowSwalError(Me, "Error de inicio de sesión", "Credenciales incorrectas. Por favor, intente de nuevo.")
            Return
        End If


    End Sub
End Class