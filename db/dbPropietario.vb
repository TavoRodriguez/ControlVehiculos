Imports System.Data.SqlClient

Public Class dbPropietario
    Public ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbHelper = New DatabaseHelper()

    Public Function Create(prop As Propietario) As String
        Try
            Dim sql As String = "INSERT INTO Propietarios (IdPersona) VALUES (@IdPersona)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPersona", prop.IdPersona)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
        Catch ex As Exception
        End Try

        Return "Propietario Creado"
    End Function

    Public Function Delete(idPropietario As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Propietarios WHERE IdPropietario = @IdPropietario"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPropietario", idPropietario)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
            Return "Propietario eliminado correctamente"
        Catch ex As Exception
            Return "Error al eliminar: " & ex.Message
        End Try
    End Function

    Public Function Update(prop As Propietario) As String
        Try
            Dim sql As String = "UPDATE Propietarios SET IdPersona = @IdPersona WHERE IdPropietario = @IdPropietario"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPersona", prop.IdPersona),
                New SqlParameter("@IdPropietario", prop.IdPropietario)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Propietario actualizado correctamente"

        Catch ex As Exception
            Return "Error al actualizar: " & ex.Message
        End Try
    End Function

    Public Function Consulta() As DataTable
        Dim resultado As New DataTable()
        Dim sql As String =
            "SELECT p.IdPropietario, p.IdPersona,
                    (SELECT CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2)
                     FROM Personas WHERE IdPersona = p.IdPersona) AS NombreCompleto
             FROM Propietarios p"

        Try
            resultado = dbHelper.ExecuteQuery(sql, New List(Of SqlParameter)())
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error al consultar los propietarios.", ex)
        End Try
    End Function

End Class
