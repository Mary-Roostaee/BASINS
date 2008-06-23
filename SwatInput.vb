Imports System.Data.OleDb
Imports MapWinUtility

''' <summary>
''' Class containing input needed for execution of SWAT2005 and methods to write text input files
''' </summary>
''' <remarks>Proof of concept - NOT COMPLETE</remarks>
Public Class SwatInput
#Region "Class Variables"
    Friend StatusBar As Windows.Forms.StatusBar = Nothing
    Friend CnSwatParm As OleDbConnection
    Friend CnSwatInput As OleDbConnection
    Friend OutputFolder As String = ""

    Private pNeedToClose As Boolean = False
#End Region

#Region "Initialize and Shutdown"
    ''' <summary>
    ''' Initialize with existing open database connections
    ''' </summary>
    ''' <param name="aSwatGDB"></param>
    ''' <param name="aOutGDB"></param>
    ''' <param name="aOutputFolder"></param>
    ''' <param name="aStatusBar"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal aSwatGDB As OleDbConnection, _
                   ByVal aOutGDB As OleDbConnection, _
                   ByVal aOutputFolder As String, _
                   ByVal aStatusBar As Windows.Forms.StatusBar)
        Initialize(aSwatGDB, aOutGDB, aOutputFolder, aStatusBar)
    End Sub

    ''' <summary>
    ''' Initialize with existing open database connections
    ''' </summary>
    ''' <param name="aSwatGDB"></param>
    ''' <param name="aOutGDB"></param>
    ''' <param name="aOutputFolder"></param>
    ''' <param name="aStatusBar"></param>
    ''' <remarks></remarks>
    Public Sub Initialize(ByVal aSwatGDB As OleDbConnection, _
                          ByVal aOutGDB As OleDbConnection, _
                          ByVal aOutputFolder As String, _
                          ByVal aStatusBar As Windows.Forms.StatusBar)
        OutputFolder = aOutputFolder
        If OutputFolder.Length > 0 AndAlso Not IO.Directory.Exists(OutputFolder) Then
            IO.Directory.CreateDirectory(OutputFolder)
        End If
        CnSwatParm = aSwatGDB
        CnSwatInput = aOutGDB
        StatusBar = aStatusBar
    End Sub

    ''' <summary>
    ''' Initialize with access database filenames
    ''' </summary>
    ''' <param name="aSwatGDB"></param>
    ''' <param name="aOutGDB"></param>
    ''' <param name="aProjectFolder"></param>
    ''' <remarks>Opens database connections</remarks>
    Public Sub New(ByVal aSwatGDB As String, _
                   ByVal aOutGDB As String, _
                   ByVal aProjectFolder As String)
        If Not IO.File.Exists(aOutGDB) Then
            BuildNewProject(aOutGDB, aProjectFolder)
        End If
        Dim lCnSwatInput As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & aOutGDB)
        lCnSwatInput.Open()

        Dim lCnSwatParm As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & aSwatGDB)
        lCnSwatParm.Open()
        Initialize(lCnSwatParm, lCnSwatInput, aProjectFolder, Nothing)
        pNeedToClose = True
    End Sub

    ''' <summary>
    ''' Close locally opened databases and unset other state variables  
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        If pNeedToClose Then
            If CnSwatInput IsNot Nothing Then
                CnSwatInput.Close()
                CnSwatInput = Nothing
            End If
            If CnSwatParm IsNot Nothing Then
                CnSwatParm.Close()
                CnSwatParm = Nothing
            End If
            OutputFolder = ""
            pNeedToClose = False
            StatusBar = Nothing
        End If
    End Sub
#End Region

#Region "Utility Routines - Public"
    ''' <summary>
    ''' Generic routine to query the SWAT parameter input database
    ''' </summary>
    ''' <param name="aQuery">SQL query</param>
    ''' <returns>DataTable of query results</returns>
    ''' <remarks></remarks>
    Public Function QueryInputDB(ByVal aQuery As String) As DataTable
        Dim lOleDbCommand As OleDbCommand = New OleDbCommand(aQuery, CnSwatInput)
        lOleDbCommand.CommandTimeout = 30
        Dim lOleDbDataAdapter As New OleDbDataAdapter
        lOleDbDataAdapter.SelectCommand = lOleDbCommand
        Dim lDataSet As New DataSet
        Dim lTableName As String = "lTable"
        lOleDbDataAdapter.Fill(lDataSet, lTableName)
        Return lDataSet.Tables(lTableName)
    End Function

    ''' <summary>
    ''' Generic routine to copy a table in the SWAT parameter input database
    ''' </summary>
    ''' <param name="aTableNameSource">Source table name</param>
    ''' <param name="aTableNameTarget">Target table name</param>
    ''' <remarks>Overwrites existing output table if required</remarks>
    Public Sub CopyTableInputDB(ByVal aTableNameSource As String, ByVal aTableNameTarget As String)
        Dim lTableSchema As DataTable = CnSwatInput.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, aTableNameSource, "TABLE"})
        If lTableSchema.Rows.Count = 1 Then
            lTableSchema = CnSwatInput.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, aTableNameTarget, "TABLE"})
            If lTableSchema.Rows.Count = 1 Then
                Dim lSQLDrop As String = "DROP TABLE " & aTableNameTarget
                Dim lDropCommand As OleDbCommand = New OleDbCommand(lSQLDrop, CnSwatInput)
                lDropCommand.CommandTimeout = 30
                lDropCommand.ExecuteNonQuery()
            End If
            Dim lSQL As String = "SELECT * INTO " & aTableNameTarget & " FROM(" & aTableNameSource & ")"
            Dim lUpdateCommand As OleDbCommand = New OleDbCommand(lSQL, CnSwatInput)
            lUpdateCommand.CommandTimeout = 30
            lUpdateCommand.ExecuteNonQuery()
        Else
            Throw New ApplicationException("Table " & aTableNameSource & " does not exist to copy")
        End If
    End Sub

    ''' <summary>
    ''' Generic routine to update a field value in a specified field in rows meeting specified criteria 
    ''' in a specified table in the SWAT parameter input database
    ''' </summary>
    ''' <param name="aTableName">Name of table containing values to update</param>
    ''' <param name="aIdFieldName">Match criteria field name</param>
    ''' <param name="aId">Match value</param>
    ''' <param name="aValueFieldName">Update field name</param>
    ''' <param name="aValue">New value</param>
    ''' <remarks></remarks>
    Public Sub UpdateInputDB(ByVal aTableName As String, _
                             ByVal aIdFieldName As String, ByVal aId As Integer, _
                             ByVal aValueFieldName As String, ByVal aValue As String)
        Dim lSQL As String = "UPDATE " & aTableName & _
                             " SET " & aValueFieldName & " = " & aValue & _
                             " WHERE " & aIdFieldName & " = " & aId
        Dim lUpdateCommand As OleDbCommand = New OleDbCommand(lSQL, CnSwatInput)
        lUpdateCommand.CommandTimeout = 30
        lUpdateCommand.ExecuteNonQuery()
    End Sub

    Friend Sub Status(ByVal aStatus As String)
        If StatusBar IsNot Nothing Then
            StatusBar.Text = aStatus
        End If
    End Sub
#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aOutGDB"></param>
    ''' <param name="aOutputFolder"></param>
    ''' <returns></returns>
    ''' <remarks>based on code from OpenSWAT</remarks>
    Private Function BuildNewProject(ByVal aOutGDB As String, _
                                     ByVal aOutputFolder As String) As Boolean

        'SaveConFig.US_SoilsDatabasePath = System.IO.Path.GetDirectoryName(Trim(txtSWATGDB.Text)) & "\SWAT_US_Soils.mdb"

        'First, try to create the project database... check if it's there first...
        ' If Not System.IO.File.Exists(prjDBName) Then
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios")
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios\Default") '
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios\Default\Scen")
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios\Default\TablesIn")
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios\Default\TablesOut")
        IO.Directory.CreateDirectory(aOutputFolder & "\Scenarios\Default\TxtInOut")
        IO.Directory.CreateDirectory(aOutputFolder & "\Watershed")
        IO.Directory.CreateDirectory(aOutputFolder & "\Watershed\Grid")
        IO.Directory.CreateDirectory(aOutputFolder & "\Watershed\Shapes")
        IO.Directory.CreateDirectory(aOutputFolder & "\Watershed\Tables")
        IO.Directory.CreateDirectory(aOutputFolder & "\Watershed\text")
        'end if

        CreateAccessDatabase(aOutGDB, aOutputFolder)

        'pSubWgn.TableCreate()
        'pSubWgn.Add(1, 1, 1, 1, 1)

        Return True
    End Function
    Private Function CreateAccessDatabase(ByVal DatabaseName As String, ByVal DatabaseFullPath As String) As Boolean
        Dim bAns As Boolean
        Dim conStr As String
        Dim cat As New ADOX.Catalog()

        Try

            Dim DatabaseFullPathAndFile As String
            DatabaseFullPathAndFile = DatabaseFullPath & "\" & DatabaseName
            If IO.File.Exists(DatabaseFullPathAndFile) Then
                IO.File.Delete(DatabaseFullPathAndFile)
            End If
            conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DatabaseFullPathAndFile
            cat.Create(conStr)
            bAns = True


            'If DatabaseName = "RasterStore.mdb" Then
            '    FindAndCreateFile(DatabaseFullPath, "rasterDBConfig.txt", conStr)
            'Else
            '    FindAndCreateFile(DatabaseFullPath, "prjDBConfig.txt", conStr)
            'End If

        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            Logger.Dbg(Excep.Message)
        Finally
            cat = Nothing
        End Try
        Return bAns
    End Function
    Private Function OpenADOConnection() As ADODB.Connection
        'Open the connection
        Dim lDataBaseName As String
        With CnSwatInput.ConnectionString
            lDataBaseName = .Substring(.IndexOf("Source=") + 8)
        End With
        Dim lConnection As New ADODB.Connection
        lConnection.Open(lDataBaseName)
        Return lConnection
    End Function
End Class


