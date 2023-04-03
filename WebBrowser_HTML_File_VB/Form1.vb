
Imports System.IO
Imports System.Reflection

Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim assmbly As Assembly = Assembly.GetExecutingAssembly()
        Dim reader As New StreamReader(assmbly.GetManifestResourceStream("WebBrowser_HTML_File_VB.HTML.htm"))
        WebBrowser1.DocumentText = reader.ReadToEnd()
    End Sub
End Class
