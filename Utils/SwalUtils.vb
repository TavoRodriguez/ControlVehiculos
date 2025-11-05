Namespace Utils
    Public Module SwalUtils

        ' Muestra un SweetAlert personalizado
        Public Sub ShowSwalMessage(page As System.Web.UI.Page, title As String, message As String, icon As String)
            ' Evita errores por comillas simples en los textos
            title = title.Replace("'", "\'")
            message = message.Replace("'", "\'")
            icon = icon.ToLower()

            ' Registra el script con un identificador único
            Dim script As String = ShowSwalScript(title, message, icon)
            ScriptManager.RegisterStartupScript(page, page.GetType(), Guid.NewGuid().ToString(), script, True)
        End Sub

        ' Genera el script JavaScript que se ejecutará en el cliente
        Public Function ShowSwalScript(title As String, message As String, icon As String) As String
            Return $"Swal.fire({{ title: '{title}', text: '{message}', icon: '{icon}', confirmButtonColor: '#3085d6', confirmButtonText: 'OK' }});"
        End Function

        ' Atajo para mostrar un SweetAlert de error con título personalizado
        Public Sub ShowSwalError(page As System.Web.UI.Page, title As String, message As String)
            ShowSwalMessage(page, title, message, "error")
        End Sub

        ' Atajo para mostrar un SweetAlert de error con título "Error"
        Public Sub ShowSwalError(page As System.Web.UI.Page, message As String)
            ShowSwalMessage(page, "Error", message, "error")
        End Sub

        ' Atajo general para mostrar cualquier tipo de alerta
        Public Sub ShowSwal(page As System.Web.UI.Page, title As String, Optional message As String = "", Optional icon As String = "success")
            ShowSwalMessage(page, title, message, icon)
        End Sub

        ' Mostrar alerta con redirección tras confirmar
        Public Sub ShowSwalAndRedirect(page As System.Web.UI.Page, title As String, message As String, icon As String, redirectUrl As String)
            title = title.Replace("'", "\'")
            message = message.Replace("'", "\'")
            redirectUrl = redirectUrl.Replace("'", "\'")
            Dim script As String =
                $"Swal.fire({{ title: '{title}', text: '{message}', icon: '{icon}', confirmButtonText: 'OK' }}).then(() => {{ window.location.href = '{redirectUrl}'; }});"
            ScriptManager.RegisterStartupScript(page, page.GetType(), Guid.NewGuid().ToString(), script, True)
        End Sub

    End Module
End Namespace

