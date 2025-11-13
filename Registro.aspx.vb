Imports ControlVehiculos.Utils

Public Class Registro
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbLogin()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Dim nombreUsuario = txtUsuario.Text.Trim()
        Dim correo = txtCorreo.Text.Trim()
        Dim Password = txtContrasena.Text
        Dim ConfirmPassword = txtConfirmar.Text

        If nombreUsuario = "" Or correo = "" Or Password = "" Or ConfirmPassword = "" Then
            SwalUtils.ShowSwalError(Me, "Campos incompletos", "Por favor complete todos los campos obligatorios.")
            Return
        End If

        Dim regexCorreo As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        If Not regexCorreo.IsMatch(correo) Then
            SwalUtils.ShowSwalError(Me, "Correo inválido", "Ingrese un correo electrónico con formato válido (ejemplo@dominio.com).")
            Return
        End If

        If Password <> ConfirmPassword Then
            SwalUtils.ShowSwalError(Me, "Error de registro", "Las contraseñas no coinciden.")
            Return
        End If

        If Password.Length < 6 Then
            SwalUtils.ShowSwalError(Me, "Contraseña débil", "La contraseña debe tener al menos 6 caracteres.")
            Return
        End If

        Dim encrypter As New Simple3Des("MiClaveSecreta123")
        Dim pass As String = encrypter.EncryptData(Password)

        Dim usuario As New Usuario(nombreUsuario, pass, txtCorreo.Text)
        Dim mensaje = dbHelper.RegisterUser(usuario)
        If mensaje.Contains("Error") Then
            SwalUtils.ShowSwalError(Me, "Error", mensaje)
        Else
            SwalUtils.ShowSwal(Me, mensaje)
        End If
    End Sub

End Class