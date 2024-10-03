Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class UserDAL
    Private connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Public Function GetUserByUsername(username As String) As User
        Dim user As User = Nothing
        Using conn As New MySqlConnection(connectionString)
            Dim cmd As New MySqlCommand("SELECT * FROM Users WHERE Username = @Username", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            conn.Open()
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    user = New User() With {
                        .UserId = Convert.ToInt32(reader("UserId")),
                        .Username = reader("Username").ToString(),
                        .Password = reader("Password").ToString(),
                        .Email = reader("Email").ToString()
                    }
                End If
            End Using
        End Using
        Return user
    End Function

    Public Sub RegisterUser(user As User)
        Using conn As New MySqlConnection(connectionString)
            Dim cmd As New MySqlCommand("INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)", conn)
            cmd.Parameters.AddWithValue("@Username", user.Username)
            cmd.Parameters.AddWithValue("@Password", user.Password) ' Hash this for security
            cmd.Parameters.AddWithValue("@Email", user.Email)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
