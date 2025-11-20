Imports System.Data.SqlClient

Public Class dbVehiculo
    Public ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbHelper = New DatabaseHelper()

    Public Function Create(veh As Vehiculo) As String
        Try
            Dim sql As String = "INSERT INTO Vehiculos (Placa, Marca, Modelo, IdPropietario) VALUES (@Placa, @Marca, @Modelo, @IdPropietario)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", veh.Placa),
                New SqlParameter("@Marca", veh.Marca),
                New SqlParameter("@Modelo", veh.Modelo),
                New SqlParameter("@IdPropietario", veh.IdPropietario)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
        Catch ex As Exception
        End Try

        Return "Vehículo Creado"
    End Function

    Public Function Delete(idVehiculo As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", idVehiculo)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
            Return "Vehículo eliminado correctamente"
        Catch ex As Exception
            Return "Error al eliminar: " & ex.Message
        End Try
    End Function

    Public Function Update(veh As Vehiculo) As String
        Try
            Dim sql As String =
                "UPDATE Vehiculos SET 
                    Placa = @Placa,
                    Marca = @Marca,
                    Modelo = @Modelo,
                    IdPropietario = @IdPropietario
                 WHERE IdVehiculo = @IdVehiculo"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", veh.Placa),
                New SqlParameter("@Marca", veh.Marca),
                New SqlParameter("@Modelo", veh.Modelo),
                New SqlParameter("@IdPropietario", veh.IdPropietario),
                New SqlParameter("@IdVehiculo", veh.IdVehiculo)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Vehículo actualizado correctamente"

        Catch ex As Exception
            Return "Error al actualizar: " & ex.Message
        End Try
    End Function

    Public Function Consulta() As DataTable
        Dim resultado As New DataTable()

        Dim sql As String =
            "SELECT v.IdVehiculo,
                    v.Placa,
                    v.Marca,
                    v.Modelo,
                    v.IdPropietario,
                    (SELECT CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2)
                     FROM Personas
                     WHERE IdPersona = (SELECT IdPersona FROM Propietarios WHERE IdPropietario = v.IdPropietario)
                    ) AS NombrePropietario
             FROM Vehiculos v"

        Try
            resultado = dbHelper.ExecuteQuery(sql, New List(Of SqlParameter)())
            Return resultado
        Catch ex As Exception
            Throw New Exception("Error al consultar los vehículos.", ex)
        End Try
    End Function

End Class
