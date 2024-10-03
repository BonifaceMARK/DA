Imports System.Web.Mvc

Public Class UserController
    Inherits Controller

    Private userDAL As New UserDAL()

    ' GET: User/Login
    Public Function Login() As ActionResult
        ViewBag.Message = Nothing
        Return View(New User()) ' Pass an empty User model to the view
    End Function


    ' POST: User/Login
    <HttpPost>
    Public Function Login(username As String, password As String) As ActionResult
        Dim user As User = userDAL.GetUserByUsername(username)
        If user IsNot Nothing AndAlso user.Password = password Then
            ' Login logic (you should hash passwords and compare hashes in production)
            Session("User") = user
            Return RedirectToAction("Dashboard", "Home")
        Else
            ViewBag.Message = "Invalid username or password"
            Return View()
        End If
    End Function

    ' GET: User/Register
    Public Function Register() As ActionResult
        Return View()
    End Function

    ' POST: User/Register
    <HttpPost>
    Public Function Register(user As User) As ActionResult
        If ModelState.IsValid Then
            ' Hash the password and register the user
            userDAL.RegisterUser(user)
            Return RedirectToAction("Login")
        End If
        Return View(user)
    End Function

    ' Logout
    Public Function Logout() As ActionResult
        Session("User") = Nothing
        Return RedirectToAction("Login")
    End Function
End Class
