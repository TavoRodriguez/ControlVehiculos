Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim currentPath As String = Page.AppRelativeVirtualPath.ToLower()

        'Desactiva las clases activas 
        linkPersonas.Attributes("class") = "nav-link"
        linkPropietarios.Attributes("class") = "nav-link"
        linkVehiculos.Attributes("class") = "nav-link"

        'Marca la etiqueta a segun la pagina en la que nos encontremos
        If currentPath.Contains("formpersona") Then
            linkPersonas.Attributes("class") &= " active"
        ElseIf currentPath.Contains("formpropietario") Then
            linkPropietarios.Attributes("class") &= " active"
        ElseIf currentPath.Contains("formvehiculo") Then
            linkVehiculos.Attributes("class") &= " active"
        End If
    End Sub
End Class