Imports System.Data.SQLite
Public Class Config
    Private Shared CfgPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\EquipmentMappingTool\user.cfg"
    Private Shared CfgSchema As String = My.Resources.ConfigSetupSQL

    Private Shared Sub CheckConfigDB()
        If Not IO.File.Exists(CfgPath) Then
            Try
                IO.Directory.CreateDirectory(CfgPath.Substring(0, CfgPath.LastIndexOf("\")))
                Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;", True)
                SQLConn.Open()
                Dim SQLCmd As New SQLiteCommand(SQLConn)
                SQLCmd.CommandText = CfgSchema
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = "INSERT INTO Config DEFAULT VALUES;"
                SQLCmd.ExecuteNonQuery()
                SQLConn.Close()
            Catch ex As Exception

            End Try
        Else 'check for missing columns
            UpdateConfigDB()
        End If
    End Sub

    Private Shared Sub UpdateConfigDB()
        Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;", True)
        SQLConn.Open()
        Dim SQLCmd As New SQLiteCommand(SQLConn)
        SQLCmd.CommandText =
"SELECT sql
FROM sqlite_master
WHERE type = 'table' AND name = 'Config';"

        Dim ExistingSchema As String = SQLCmd.ExecuteScalar()
        ExistingSchema.Trim(vbCrLf, ";"c)
        Dim NewSchema As String = CfgSchema.Trim(";"c)

        If ExistingSchema <> NewSchema Then
            Console.WriteLine("Updating Config Database")
            Try
                SQLCmd.CommandText = "ALTER TABLE Config RENAME TO ConfigOld;"
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = CfgSchema
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                'major problem, cannot create new config table.
                SQLCmd.CommandText = "DROP TABLE Config;"
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = "ALTER TABLE ConfigOld RENAME TO Config;"
                SQLCmd.ExecuteNonQuery()
                SQLConn.Close()
                SQLConn.Dispose()
                Throw New Exception("Database schema update failed.")
                Exit Sub
            End Try
            Try
                'iterate through old columns and copy to new table
                SQLCmd.CommandText = "INSERT INTO Config DEFAULT VALUES"
                SQLCmd.ExecuteNonQuery()
                Dim oldConfig As New DataTable
                SQLCmd.CommandText = "SELECT * FROM ConfigOld;"
                oldConfig.Load(SQLCmd.ExecuteReader())
                For i = 0 To oldConfig.Columns.Count - 1
                    Dim colName As String = oldConfig.Columns(i).ColumnName
                    Dim colVal As Object = oldConfig.Rows(0).Item(i)
                    Try
                        SQLCmd.CommandText = $"UPDATE Config SET {colName} = '{colVal}';"
                        SQLCmd.ExecuteNonQuery()
                    Catch ex2 As Exception
                        'cannot add column, leave default
                    End Try
                Next
            Catch ex As Exception
                Dim null = Nothing
            End Try
            Try
                SQLCmd.CommandText = "DROP TABLE ConfigOld;"
                SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                'cannot drop old table
            End Try
        End If
        SQLConn.Close()
        SQLConn.Dispose()
    End Sub

    Private Shared Sub RepairConfigDB()
        Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;", True)
        SQLConn.Open()
        Dim SQLCmd As New SQLiteCommand(SQLConn)
        SQLCmd.CommandText = "DROP TABLE Config;"
        SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = "ALTER TABLE ConfigOld RENAME TO Config;"
        SQLCmd.ExecuteNonQuery()
        SQLConn.Close()
        SQLConn.Dispose()
    End Sub


    Public Shared Property StartMaximized As Boolean
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT StartMaximized FROM Config"
            Dim b As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return b
        End Get
        Set(value As Boolean)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET StartMaximized = " & If(value, 1, 0)
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property
    Public Shared Property LastMapPath As String
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT LastMapPath FROM Config"
            Dim s As Object = SQLCmd.ExecuteScalar
            If s Is Nothing OrElse s Is DBNull.Value Then s = ""
            SQLConn.Close()
            Return s.ToString
        End Get
        Set(value As String)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET LastMapPath = '" & value & "'"
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property
    Public Shared Property ExpireDays As Integer
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT ExpireDays FROM Config"
            Dim i As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return i
        End Get
        Set(value As Integer)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET ExpireDays = " & value
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property
    Public Shared Property ExpiredItemColor As Color
        Get
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "SELECT ExpiredItemColor FROM Config"
            Dim i As Integer = SQLCmd.ExecuteScalar()
            SQLConn.Close()
            Return Color.FromArgb(i)
        End Get
        Set(value As Color)
            CheckConfigDB()
            Dim SQLConn As New SQLiteConnection("Data Source=" & CfgPath & ";Version=3;")
            SQLConn.Open()
            Dim SQLCmd As New SQLiteCommand(SQLConn)
            SQLCmd.CommandText = "UPDATE Config SET ExpiredItemColor = " & value.ToArgb
            SQLCmd.ExecuteNonQuery()
            SQLConn.Close()
        End Set
    End Property

End Class
