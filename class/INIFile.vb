Imports System.Runtime.InteropServices
Imports System.Text

Public Class INIFile

    Private m_filePath As String

    <DllImport("kernel32")> _
    Private Shared Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
    End Function

    Public Sub New(ByVal filePath As String)
        Me.m_filePath = filePath
    End Sub

    Public Function Read(ByVal section As String, ByVal key As String) As String
        Dim SB As New StringBuilder(255)
        Dim i As Integer = GetPrivateProfileString(section, key, "", SB, 255, Me.m_filePath)
        Return SB.ToString()
    End Function

    Public Property FilePath() As String
        Get
            Return Me.m_filePath
        End Get
        Set(ByVal value As String)
            Me.m_filePath = value
        End Set
    End Property

End Class

