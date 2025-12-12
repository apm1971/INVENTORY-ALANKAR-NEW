Imports System.Data
Imports System.Data.OleDb

Module Module1

    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ATAM\MYPROJ\hello\inventory.accdb;Persist Security Info=False;")
    Private ReadOnly conLock As New Object()

    Public Function GetDataTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            SyncLock conLock
                Using da As New OleDbDataAdapter(sql, con)
                    Dim mustClose As Boolean = False
                    If con.State <> ConnectionState.Open Then
                        con.Open()
                        mustClose = True
                    End If

                    da.Fill(dt)

                    If mustClose AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Using
            End SyncLock

            Return dt
        Catch ex As Exception
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                Try
                    con.Close()
                Catch
                End Try
            End If
            Throw ' rethrow so caller can handle/log the exception
        End Try
    End Function

    Public Sub ExecuteSQL(sql As String)
        Try
            SyncLock conLock
                Using cmd As New OleDbCommand(sql, con)
                    Dim mustClose As Boolean = False
                    If con.State <> ConnectionState.Open Then
                        con.Open()
                        mustClose = True
                    End If

                    cmd.ExecuteNonQuery()

                    If mustClose AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Using
            End SyncLock
        Catch ex As Exception
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                Try
                    con.Close()
                Catch
                End Try
            End If
            Throw
        End Try
    End Sub

End Module


