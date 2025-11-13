Imports System.Data.SqlClient

Public Class dbLogin
    Private ReadOnly dbHelper = New DatabaseHelper() ' Instancia de DatabaseHelper

    Public Function ValidateLogin(ByRef usuario As String, ByRef password As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contrasena = @Password AND Activo =1"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Usuario", usuario),
                New SqlParameter("@Password", password)
            }
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
            If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0)(0)) > 0 Then
                Return True
            End If
        Catch ex As Exception
            ' Manejo de errores si es necesario
            Return "Creedenciales incorrectas."
        End Try
        Return False
    End Function

    Public Function RegisterUser(ByRef usuario As Usuario) As String
        Try
            Dim sql As String = "INSERT INTO Usuarios ([NombreUsuario]
           ,[Contrasena]
           ,[Email]) VALUES (@Usuario, @Password, @email)"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Usuario", usuario.NombreUsuario),
                New SqlParameter("@Password", usuario.Contrasena),
                New SqlParameter("@email", usuario.Email)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
        Catch ex As Exception
            Return "Error al registrar el usuario: " & ex.Message
        End Try
        Return "Usuario registrado"
    End Function

    Public Function GetUser(usuario As String) As Object
        Dim sql As String = "SELECT IdUsuario, NombreUsuario, Rol, Email FROM Usuarios WHERE NombreUsuario = @Usuario"
        Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario)
        }
        Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros) ' Ejecuta la consulta y obtiene el DataTable
        Dim usuarioObj As New Usuario()
        If dt.Rows.Count > 0 Then
            usuarioObj.IdUsuario = Convert.ToInt32(dt.Rows(0)("IdUsuario"))
            usuarioObj.NombreUsuario = dt.Rows(0)("NombreUsuario").ToString()
            usuarioObj.Rol = dt.Rows(0)("Rol").ToString()
            usuarioObj.Email = dt.Rows(0)("Email").ToString()

            Return usuarioObj
        Else
            Return Nothing
        End If
    End Function
End Class
