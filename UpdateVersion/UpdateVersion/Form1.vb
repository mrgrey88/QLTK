Imports System
Imports System.IO
Imports BMS
Imports BMS.Model
Imports BMS.Utils
Imports BMS.Business
Public Class frmUpdateVersion
    Dim pathServer As String = "\\SERVER\\Company\\Share\\Thiet ke\\PHẦN MỀM QUẢN LÝ THIẾT KẾ"
    'Dim count = 0
    Dim listFiles As String()
    Dim listFolder As String()

    Private Sub frmUpdateVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim config As New ConfigSystemModel
        'config = CType(ConfigSystemBO.Instance.FindByCode("UpdatePath"), ConfigSystemModel)
        'pathServer = config.KeyValue

        Dim ItemProcess() As Process = Process.GetProcessesByName("DesignSupportSystem")
        If Not ItemProcess Is Nothing Then
            For Each SubProcess As Process In ItemProcess
                SubProcess.Kill()
            Next
        End If
        listFiles = Directory.GetFiles(pathServer, "*.*", SearchOption.TopDirectoryOnly)
        listFolder = Directory.GetDirectories(pathServer)
        ProgressBar1.Maximum = listFiles.Count + listFolder.Count + 20
        Timer1.Enabled = True
        ProgressBar1.Visible = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = "Đang cập nhật..."

        Try

            For Each itemFolder In listFolder
                Dim pathC As String = Path.GetFileName(itemFolder)
                Dim localPath As String = Application.StartupPath & "\" & pathC
                If Not Directory.Exists(localPath) Then
                    Directory.CreateDirectory(localPath)
                Else
                    My.Computer.FileSystem.DeleteDirectory(localPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                My.Computer.FileSystem.CopyDirectory(itemFolder, localPath, True)
                ProgressBar1.Value += 1
            Next

            For Each itemFile In listFiles
                ProgressBar1.Value += 1
                Dim fi As New FileInfo(itemFile)
                If Path.GetFileName(fi.FullName).ToUpper().Contains("Update.ini".ToUpper()) Then
                    Continue For
                End If
                If Path.GetFileName(fi.FullName).ToUpper().Contains("UpdateVersion".ToUpper()) Then
                    Continue For
                End If
                If Path.GetFileName(fi.FullName).ToUpper().Contains("DesignSupportSystem".ToUpper()) Then
                    Continue For
                End If
                File.Copy(fi.FullName, Application.StartupPath & "\" & fi.Name, True)
            Next

            File.Copy(pathServer & "\\DesignSupportSystem.exe", Application.StartupPath & "\\DesignSupportSystem.exe", True)
            Label2.Text = "Cập nhật thành công!"

            Process.Start(Application.StartupPath & "\\DesignSupportSystem.exe")
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        Finally
            Timer1.Enabled = False
            Application.Exit()
        End Try

    End Sub
End Class
