Imports System.Data.SqlClient

Public Class dbPersona
    Public ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbHelper = New DatabaseHelper() ' Instancia de DatabaseHelper

    Public Function Create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre, Apellido1, Apellido2, Nacionalidad, FechaNacimiento, Telefono) VALUES (@Nombre, @Apellido1, @Apellido2, @Nacionalidad, @FechaNacimiento, @Telefono)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido1", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
            'Using connection As New SqlConnection(connectionString)
            '    Using command As New SqlCommand(sql, connection)
            '        command.Parameters.AddRange(parametros.ToArray())
            '        connection.Open()
            '        command.ExecuteNonQuery()
            '    End Using

            'End Using
        Catch ex As Exception

        End Try

        Return "Persona Creada"
    End Function

    Public Function Delete(idPersona As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Personas WHERE IdPersona = @IdPersona"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdPersona", idPersona)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)

            'Using connection As New SqlConnection(connectionString)
            '    Using command As New SqlCommand(sql, connection)
            '        command.Parameters.AddRange(parametros.ToArray())
            '        connection.Open()
            '        command.ExecuteNonQuery()
            '    End Using
            'End Using

            Return "Persona eliminada correctamente"
        Catch ex As Exception
            Return "Error al eliminar: " & ex.Message
        End Try
    End Function

    Public Function Update(Persona As Persona) As String
        Try
            Dim sql As String = "UPDATE Personas SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Nacionalidad = @Nacionalidad, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono WHERE IdPersona = @IdPersona"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido1", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono),
                New SqlParameter("@IdPersona", Persona.IdPersona)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Persona actualizada correctamente"
        Catch ex As Exception
            Return "Error al actualizar: " & ex.Message
        End Try
    End Function
End Class
