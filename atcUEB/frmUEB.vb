Imports atcUtility
Imports atcMwGisUtility
Imports MapWinUtility
Imports atcData
Imports System.Drawing
Imports System
Imports System.Windows.Forms

Public Class frmUEB
    Inherits System.Windows.Forms.Form

    Friend pProjectDescription As String
    Friend pParmData As clsUEBParameterFile
    Friend pSiteData As clsUEBSiteFile
    Friend pInputControlData As clsUEBInputControl
    Friend pOutputControlData As clsUEBOutputControl
    'Friend pWeatherData As clsUEBWeather

    Friend pBCParameterFileName As String
    Friend pBCDataArray(37) As Double
    Friend pOutputFileName As String
    Friend pRadOpt As Integer

    Friend WithEvents AtcGridModelParms As atcControls.atcGrid
    Friend WithEvents txtParameterFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSiteFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOutputFile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AtcGridSiteVars As atcControls.atcGrid
    Friend WithEvents AtcGridBCMonthly As atcControls.atcGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents AtcGridInputControl As atcControls.atcGrid
    Friend WithEvents AtcTextUTCOffset As atcControls.atcText

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdAbout As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBox14 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboBox15 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox16 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox17 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBox18 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ComboBox19 As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox20 As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ComboBox21 As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ComboBox22 As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents ComboBox23 As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ComboBox24 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox25 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ComboBox26 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ComboBox27 As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents ComboBox28 As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ComboBox29 As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ComboBox30 As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ComboBox31 As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ComboBox32 As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ComboBox33 As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ComboBox34 As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents ComboBox35 As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents ComboBox36 As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents ComboBox37 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox38 As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents ComboBox39 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents AtcTextEDay As atcControls.atcText
    Friend WithEvents AtcTextSDay As atcControls.atcText
    Friend WithEvents AtcTextSYear As atcControls.atcText
    Friend WithEvents AtcTextEMon As atcControls.atcText
    Friend WithEvents AtcTextSMonth As atcControls.atcText
    Friend WithEvents AtcTextEYear As atcControls.atcText
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSimulate As System.Windows.Forms.Button
    Friend WithEvents lblTimeStep As System.Windows.Forms.Label
    Friend WithEvents atcTextTimeStep As atcControls.atcText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AtcTextEHour As atcControls.atcText
    Friend WithEvents AtcTextSHour As atcControls.atcText
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents txtInputFile As System.Windows.Forms.TextBox
    Friend WithEvents txtMasterFile As System.Windows.Forms.TextBox
    Friend WithEvents txtWatershedFile As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUEB))
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.cmdAbout = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtWatershedFile = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.txtMasterFile = New System.Windows.Forms.TextBox
        Me.lblInstructions = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtInputFile = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTimeStep = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.txtSiteFile = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.txtOutputFile = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtParameterFile = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.ComboBox14 = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ComboBox15 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.ComboBox16 = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ComboBox17 = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.ComboBox18 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.ComboBox19 = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.ComboBox20 = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.ComboBox21 = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.ComboBox22 = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.ComboBox23 = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.ComboBox24 = New System.Windows.Forms.ComboBox
        Me.ComboBox25 = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.ComboBox26 = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.ComboBox27 = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.ComboBox28 = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.ComboBox29 = New System.Windows.Forms.ComboBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.ComboBox30 = New System.Windows.Forms.ComboBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.ComboBox31 = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.ComboBox32 = New System.Windows.Forms.ComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.ComboBox33 = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.ComboBox34 = New System.Windows.Forms.ComboBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.ComboBox35 = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.ComboBox36 = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.ComboBox37 = New System.Windows.Forms.ComboBox
        Me.ComboBox38 = New System.Windows.Forms.ComboBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.ComboBox39 = New System.Windows.Forms.ComboBox
        Me.cmdSimulate = New System.Windows.Forms.Button
        Me.atcTextTimeStep = New atcControls.atcText
        Me.AtcTextEHour = New atcControls.atcText
        Me.AtcTextSHour = New atcControls.atcText
        Me.AtcTextEDay = New atcControls.atcText
        Me.AtcTextSDay = New atcControls.atcText
        Me.AtcTextSYear = New atcControls.atcText
        Me.AtcTextEMon = New atcControls.atcText
        Me.AtcTextSMonth = New atcControls.atcText
        Me.AtcTextEYear = New atcControls.atcText
        Me.AtcGridSiteVars = New atcControls.atcGrid
        Me.AtcGridBCMonthly = New atcControls.atcGrid
        Me.AtcGridModelParms = New atcControls.atcGrid
        Me.Label8 = New System.Windows.Forms.Label
        Me.AtcTextUTCOffset = New atcControls.atcText
        Me.AtcGridInputControl = New atcControls.atcGrid
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(328, 500)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(73, 28)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Close"
        '
        'cmdHelp
        '
        Me.cmdHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.Location = New System.Drawing.Point(407, 500)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(65, 28)
        Me.cmdHelp.TabIndex = 6
        Me.cmdHelp.Text = "Help"
        '
        'cmdAbout
        '
        Me.cmdAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbout.Location = New System.Drawing.Point(478, 500)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(72, 28)
        Me.cmdAbout.TabIndex = 7
        Me.cmdAbout.Text = "About"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(60, 21)
        Me.TabControl1.Location = New System.Drawing.Point(15, 15)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(539, 474)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtWatershedFile)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtProjectName)
        Me.TabPage2.Controls.Add(Me.txtMasterFile)
        Me.TabPage2.Controls.Add(Me.lblInstructions)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label62)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(531, 445)
        Me.TabPage2.TabIndex = 12
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtWatershedFile
        '
        Me.txtWatershedFile.Location = New System.Drawing.Point(136, 171)
        Me.txtWatershedFile.Name = "txtWatershedFile"
        Me.txtWatershedFile.Size = New System.Drawing.Size(380, 20)
        Me.txtWatershedFile.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Watershed File Name:"
        '
        'txtProjectName
        '
        Me.txtProjectName.Location = New System.Drawing.Point(136, 64)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(380, 20)
        Me.txtProjectName.TabIndex = 46
        '
        'txtMasterFile
        '
        Me.txtMasterFile.Location = New System.Drawing.Point(136, 29)
        Me.txtMasterFile.Name = "txtMasterFile"
        Me.txtMasterFile.Size = New System.Drawing.Size(380, 20)
        Me.txtMasterFile.TabIndex = 45
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Location = New System.Drawing.Point(18, 19)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(0, 13)
        Me.lblInstructions.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Master Project File:"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(18, 67)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(99, 13)
        Me.Label62.TabIndex = 31
        Me.Label62.Text = "Project :Description"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.AtcGridInputControl)
        Me.TabPage3.Controls.Add(Me.txtInputFile)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(531, 445)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Input Control"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtInputFile
        '
        Me.txtInputFile.Location = New System.Drawing.Point(102, 12)
        Me.txtInputFile.Name = "txtInputFile"
        Me.txtInputFile.Size = New System.Drawing.Size(410, 20)
        Me.txtInputFile.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Input Control File:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.AtcTextUTCOffset)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblTimeStep)
        Me.GroupBox2.Controls.Add(Me.atcTextTimeStep)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.AtcTextEHour)
        Me.GroupBox2.Controls.Add(Me.AtcTextSHour)
        Me.GroupBox2.Controls.Add(Me.Label54)
        Me.GroupBox2.Controls.Add(Me.Label55)
        Me.GroupBox2.Controls.Add(Me.Label56)
        Me.GroupBox2.Controls.Add(Me.Label57)
        Me.GroupBox2.Controls.Add(Me.Label58)
        Me.GroupBox2.Controls.Add(Me.AtcTextEDay)
        Me.GroupBox2.Controls.Add(Me.AtcTextSDay)
        Me.GroupBox2.Controls.Add(Me.AtcTextSYear)
        Me.GroupBox2.Controls.Add(Me.AtcTextEMon)
        Me.GroupBox2.Controls.Add(Me.AtcTextSMonth)
        Me.GroupBox2.Controls.Add(Me.AtcTextEYear)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(493, 96)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Simulation Dates"
        '
        'lblTimeStep
        '
        Me.lblTimeStep.AutoSize = True
        Me.lblTimeStep.Location = New System.Drawing.Point(297, 38)
        Me.lblTimeStep.Name = "lblTimeStep"
        Me.lblTimeStep.Size = New System.Drawing.Size(78, 13)
        Me.lblTimeStep.TabIndex = 42
        Me.lblTimeStep.Text = "Time Step (hrs)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(224, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Hour"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(20, 64)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(26, 13)
        Me.Label54.TabIndex = 37
        Me.Label54.Text = "End"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(16, 38)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(29, 13)
        Me.Label55.TabIndex = 36
        Me.Label55.Text = "Start"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(175, 20)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(26, 13)
        Me.Label56.TabIndex = 35
        Me.Label56.Text = "Day"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(126, 20)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(37, 13)
        Me.Label57.TabIndex = 34
        Me.Label57.Text = "Month"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(58, 20)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(29, 13)
        Me.Label58.TabIndex = 33
        Me.Label58.Text = "Year"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.AtcGridSiteVars)
        Me.TabPage7.Controls.Add(Me.txtSiteFile)
        Me.TabPage7.Controls.Add(Me.Label5)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(531, 445)
        Me.TabPage7.TabIndex = 8
        Me.TabPage7.Text = "Site Vars/Init Conds"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'txtSiteFile
        '
        Me.txtSiteFile.Location = New System.Drawing.Point(85, 18)
        Me.txtSiteFile.Name = "txtSiteFile"
        Me.txtSiteFile.Size = New System.Drawing.Size(410, 20)
        Me.txtSiteFile.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Site File:"
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.AtcGridBCMonthly)
        Me.TabPage8.Controls.Add(Me.txtOutputFile)
        Me.TabPage8.Controls.Add(Me.Label6)
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(531, 445)
        Me.TabPage8.TabIndex = 9
        Me.TabPage8.Text = "Output Control"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'txtOutputFile
        '
        Me.txtOutputFile.Location = New System.Drawing.Point(115, 9)
        Me.txtOutputFile.Name = "txtOutputFile"
        Me.txtOutputFile.Size = New System.Drawing.Size(403, 20)
        Me.txtOutputFile.TabIndex = 61
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Output Control File:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.AtcGridModelParms)
        Me.TabPage1.Controls.Add(Me.txtParameterFile)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(531, 445)
        Me.TabPage1.TabIndex = 11
        Me.TabPage1.Text = "Constant Parameters"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtParameterFile
        '
        Me.txtParameterFile.Location = New System.Drawing.Point(94, 14)
        Me.txtParameterFile.Name = "txtParameterFile"
        Me.txtParameterFile.Size = New System.Drawing.Size(410, 20)
        Me.txtParameterFile.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Parameter File:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(27, 362)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(137, 13)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Max Impervious Cover Grid:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox14
        '
        Me.ComboBox14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox14.Location = New System.Drawing.Point(183, 359)
        Me.ComboBox14.Name = "ComboBox14"
        Me.ComboBox14.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox14.TabIndex = 47
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(27, 335)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 13)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "Downstream Basin ID Grid:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox15
        '
        Me.ComboBox15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox15.Location = New System.Drawing.Point(183, 333)
        Me.ComboBox15.Name = "ComboBox15"
        Me.ComboBox15.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox15.TabIndex = 45
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(27, 309)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 13)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Stream Link Grid:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox16
        '
        Me.ComboBox16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox16.Location = New System.Drawing.Point(183, 306)
        Me.ComboBox16.Name = "ComboBox16"
        Me.ComboBox16.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox16.TabIndex = 43
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(27, 282)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(152, 13)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "Downstream Flow Length Grid:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox17
        '
        Me.ComboBox17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox17.Location = New System.Drawing.Point(183, 279)
        Me.ComboBox17.Name = "ComboBox17"
        Me.ComboBox17.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox17.TabIndex = 41
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(27, 255)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(137, 13)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Hydraulic Conductivity Grid:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox18
        '
        Me.ComboBox18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox18.Location = New System.Drawing.Point(183, 252)
        Me.ComboBox18.Name = "ComboBox18"
        Me.ComboBox18.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox18.TabIndex = 39
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(27, 228)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "Soil Texture Grid:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox19
        '
        Me.ComboBox19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox19.Location = New System.Drawing.Point(183, 225)
        Me.ComboBox19.Name = "ComboBox19"
        Me.ComboBox19.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox19.TabIndex = 37
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(27, 201)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(81, 13)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "Soil Depth Grid:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox20
        '
        Me.ComboBox20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox20.Location = New System.Drawing.Point(183, 198)
        Me.ComboBox20.Name = "ComboBox20"
        Me.ComboBox20.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox20.TabIndex = 35
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(27, 174)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(144, 13)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Water Holding Capacity Grid:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox21
        '
        Me.ComboBox21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox21.Location = New System.Drawing.Point(183, 171)
        Me.ComboBox21.Name = "ComboBox21"
        Me.ComboBox21.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox21.TabIndex = 33
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(27, 147)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(135, 13)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "Runoff Curve Number Grid:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox22
        '
        Me.ComboBox22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox22.Location = New System.Drawing.Point(183, 144)
        Me.ComboBox22.Name = "ComboBox22"
        Me.ComboBox22.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox22.TabIndex = 31
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(27, 120)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(82, 13)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "Hill Length Grid:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox23
        '
        Me.ComboBox23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox23.Location = New System.Drawing.Point(183, 117)
        Me.ComboBox23.Name = "ComboBox23"
        Me.ComboBox23.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox23.TabIndex = 29
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(27, 92)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 13)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "Flow Accumulation Grid:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox24
        '
        Me.ComboBox24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox24.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox24.Location = New System.Drawing.Point(183, 90)
        Me.ComboBox24.Name = "ComboBox24"
        Me.ComboBox24.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox24.TabIndex = 27
        '
        'ComboBox25
        '
        Me.ComboBox25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox25.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox25.Location = New System.Drawing.Point(183, 36)
        Me.ComboBox25.Name = "ComboBox25"
        Me.ComboBox25.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox25.TabIndex = 25
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(27, 38)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 24
        Me.Label31.Text = "Basin Grid:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(27, 65)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(87, 13)
        Me.Label32.TabIndex = 20
        Me.Label32.Text = "Processed DEM:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox26
        '
        Me.ComboBox26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox26.Location = New System.Drawing.Point(183, 63)
        Me.ComboBox26.Name = "ComboBox26"
        Me.ComboBox26.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox26.TabIndex = 23
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(27, 362)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(137, 13)
        Me.Label33.TabIndex = 46
        Me.Label33.Text = "Max Impervious Cover Grid:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox27
        '
        Me.ComboBox27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox27.Location = New System.Drawing.Point(183, 359)
        Me.ComboBox27.Name = "ComboBox27"
        Me.ComboBox27.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox27.TabIndex = 47
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(27, 335)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(134, 13)
        Me.Label34.TabIndex = 44
        Me.Label34.Text = "Downstream Basin ID Grid:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox28
        '
        Me.ComboBox28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox28.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox28.Location = New System.Drawing.Point(183, 333)
        Me.ComboBox28.Name = "ComboBox28"
        Me.ComboBox28.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox28.TabIndex = 45
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(27, 309)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(88, 13)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "Stream Link Grid:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox29
        '
        Me.ComboBox29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox29.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox29.Location = New System.Drawing.Point(183, 306)
        Me.ComboBox29.Name = "ComboBox29"
        Me.ComboBox29.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox29.TabIndex = 43
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(27, 282)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(152, 13)
        Me.Label36.TabIndex = 40
        Me.Label36.Text = "Downstream Flow Length Grid:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox30
        '
        Me.ComboBox30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox30.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox30.Location = New System.Drawing.Point(183, 279)
        Me.ComboBox30.Name = "ComboBox30"
        Me.ComboBox30.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox30.TabIndex = 41
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(27, 255)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(137, 13)
        Me.Label37.TabIndex = 38
        Me.Label37.Text = "Hydraulic Conductivity Grid:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox31
        '
        Me.ComboBox31.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox31.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox31.Location = New System.Drawing.Point(183, 252)
        Me.ComboBox31.Name = "ComboBox31"
        Me.ComboBox31.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox31.TabIndex = 39
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(27, 228)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(88, 13)
        Me.Label38.TabIndex = 36
        Me.Label38.Text = "Soil Texture Grid:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox32
        '
        Me.ComboBox32.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox32.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox32.Location = New System.Drawing.Point(183, 225)
        Me.ComboBox32.Name = "ComboBox32"
        Me.ComboBox32.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox32.TabIndex = 37
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(27, 201)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(81, 13)
        Me.Label39.TabIndex = 34
        Me.Label39.Text = "Soil Depth Grid:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox33
        '
        Me.ComboBox33.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox33.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox33.Location = New System.Drawing.Point(183, 198)
        Me.ComboBox33.Name = "ComboBox33"
        Me.ComboBox33.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox33.TabIndex = 35
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(27, 174)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(144, 13)
        Me.Label40.TabIndex = 32
        Me.Label40.Text = "Water Holding Capacity Grid:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox34
        '
        Me.ComboBox34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox34.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox34.Location = New System.Drawing.Point(183, 171)
        Me.ComboBox34.Name = "ComboBox34"
        Me.ComboBox34.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox34.TabIndex = 33
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(27, 147)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(135, 13)
        Me.Label41.TabIndex = 30
        Me.Label41.Text = "Runoff Curve Number Grid:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox35
        '
        Me.ComboBox35.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox35.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox35.Location = New System.Drawing.Point(183, 144)
        Me.ComboBox35.Name = "ComboBox35"
        Me.ComboBox35.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox35.TabIndex = 31
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(27, 120)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(82, 13)
        Me.Label42.TabIndex = 28
        Me.Label42.Text = "Hill Length Grid:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox36
        '
        Me.ComboBox36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox36.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox36.Location = New System.Drawing.Point(183, 117)
        Me.ComboBox36.Name = "ComboBox36"
        Me.ComboBox36.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox36.TabIndex = 29
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(27, 92)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(121, 13)
        Me.Label43.TabIndex = 26
        Me.Label43.Text = "Flow Accumulation Grid:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox37
        '
        Me.ComboBox37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox37.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox37.Location = New System.Drawing.Point(183, 90)
        Me.ComboBox37.Name = "ComboBox37"
        Me.ComboBox37.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox37.TabIndex = 27
        '
        'ComboBox38
        '
        Me.ComboBox38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox38.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox38.Location = New System.Drawing.Point(183, 36)
        Me.ComboBox38.Name = "ComboBox38"
        Me.ComboBox38.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox38.TabIndex = 25
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(27, 38)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(58, 13)
        Me.Label44.TabIndex = 24
        Me.Label44.Text = "Basin Grid:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(27, 65)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 20
        Me.Label45.Text = "Processed DEM:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox39
        '
        Me.ComboBox39.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox39.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox39.Location = New System.Drawing.Point(183, 63)
        Me.ComboBox39.Name = "ComboBox39"
        Me.ComboBox39.Size = New System.Drawing.Size(312, 21)
        Me.ComboBox39.TabIndex = 23
        '
        'cmdSimulate
        '
        Me.cmdSimulate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSimulate.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSimulate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSimulate.Location = New System.Drawing.Point(14, 499)
        Me.cmdSimulate.Name = "cmdSimulate"
        Me.cmdSimulate.Size = New System.Drawing.Size(73, 28)
        Me.cmdSimulate.TabIndex = 10
        Me.cmdSimulate.Text = "Simulate"
        '
        'atcTextTimeStep
        '
        Me.atcTextTimeStep.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.atcTextTimeStep.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.atcTextTimeStep.DefaultValue = ""
        Me.atcTextTimeStep.HardMax = 24
        Me.atcTextTimeStep.HardMin = 1
        Me.atcTextTimeStep.InsideLimitsBackground = System.Drawing.Color.White
        Me.atcTextTimeStep.Location = New System.Drawing.Point(391, 38)
        Me.atcTextTimeStep.MaxWidth = 20
        Me.atcTextTimeStep.Name = "atcTextTimeStep"
        Me.atcTextTimeStep.NumericFormat = "0"
        Me.atcTextTimeStep.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.atcTextTimeStep.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.atcTextTimeStep.SelLength = 0
        Me.atcTextTimeStep.SelStart = 0
        Me.atcTextTimeStep.Size = New System.Drawing.Size(54, 21)
        Me.atcTextTimeStep.SoftMax = -999
        Me.atcTextTimeStep.SoftMin = -999
        Me.atcTextTimeStep.TabIndex = 41
        Me.atcTextTimeStep.ValueDouble = 1
        Me.atcTextTimeStep.ValueInteger = 1
        '
        'AtcTextEHour
        '
        Me.AtcTextEHour.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextEHour.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextEHour.DefaultValue = ""
        Me.AtcTextEHour.HardMax = 24
        Me.AtcTextEHour.HardMin = 0
        Me.AtcTextEHour.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextEHour.Location = New System.Drawing.Point(227, 64)
        Me.AtcTextEHour.MaxWidth = 20
        Me.AtcTextEHour.Name = "AtcTextEHour"
        Me.AtcTextEHour.NumericFormat = "0"
        Me.AtcTextEHour.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextEHour.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextEHour.SelLength = 0
        Me.AtcTextEHour.SelStart = 0
        Me.AtcTextEHour.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextEHour.SoftMax = -999
        Me.AtcTextEHour.SoftMin = -999
        Me.AtcTextEHour.TabIndex = 39
        Me.AtcTextEHour.ValueDouble = 0
        Me.AtcTextEHour.ValueInteger = 0
        '
        'AtcTextSHour
        '
        Me.AtcTextSHour.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextSHour.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextSHour.DefaultValue = ""
        Me.AtcTextSHour.HardMax = 24
        Me.AtcTextSHour.HardMin = 0
        Me.AtcTextSHour.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextSHour.Location = New System.Drawing.Point(227, 38)
        Me.AtcTextSHour.MaxWidth = 20
        Me.AtcTextSHour.Name = "AtcTextSHour"
        Me.AtcTextSHour.NumericFormat = "0"
        Me.AtcTextSHour.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextSHour.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextSHour.SelLength = 0
        Me.AtcTextSHour.SelStart = 0
        Me.AtcTextSHour.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextSHour.SoftMax = -999
        Me.AtcTextSHour.SoftMin = -999
        Me.AtcTextSHour.TabIndex = 38
        Me.AtcTextSHour.ValueDouble = 0
        Me.AtcTextSHour.ValueInteger = 0
        '
        'AtcTextEDay
        '
        Me.AtcTextEDay.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextEDay.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextEDay.DefaultValue = ""
        Me.AtcTextEDay.HardMax = 31
        Me.AtcTextEDay.HardMin = 1
        Me.AtcTextEDay.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextEDay.Location = New System.Drawing.Point(178, 64)
        Me.AtcTextEDay.MaxWidth = 20
        Me.AtcTextEDay.Name = "AtcTextEDay"
        Me.AtcTextEDay.NumericFormat = "0"
        Me.AtcTextEDay.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextEDay.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextEDay.SelLength = 0
        Me.AtcTextEDay.SelStart = 0
        Me.AtcTextEDay.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextEDay.SoftMax = -999
        Me.AtcTextEDay.SoftMin = -999
        Me.AtcTextEDay.TabIndex = 32
        Me.AtcTextEDay.ValueDouble = 31
        Me.AtcTextEDay.ValueInteger = 31
        '
        'AtcTextSDay
        '
        Me.AtcTextSDay.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextSDay.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextSDay.DefaultValue = ""
        Me.AtcTextSDay.HardMax = 31
        Me.AtcTextSDay.HardMin = 1
        Me.AtcTextSDay.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextSDay.Location = New System.Drawing.Point(178, 38)
        Me.AtcTextSDay.MaxWidth = 20
        Me.AtcTextSDay.Name = "AtcTextSDay"
        Me.AtcTextSDay.NumericFormat = "0"
        Me.AtcTextSDay.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextSDay.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextSDay.SelLength = 0
        Me.AtcTextSDay.SelStart = 0
        Me.AtcTextSDay.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextSDay.SoftMax = -999
        Me.AtcTextSDay.SoftMin = -999
        Me.AtcTextSDay.TabIndex = 31
        Me.AtcTextSDay.ValueDouble = 1
        Me.AtcTextSDay.ValueInteger = 1
        '
        'AtcTextSYear
        '
        Me.AtcTextSYear.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextSYear.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextSYear.DefaultValue = ""
        Me.AtcTextSYear.HardMax = 9999
        Me.AtcTextSYear.HardMin = 0
        Me.AtcTextSYear.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextSYear.Location = New System.Drawing.Point(60, 38)
        Me.AtcTextSYear.MaxWidth = 20
        Me.AtcTextSYear.Name = "AtcTextSYear"
        Me.AtcTextSYear.NumericFormat = "0"
        Me.AtcTextSYear.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextSYear.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextSYear.SelLength = 0
        Me.AtcTextSYear.SelStart = 0
        Me.AtcTextSYear.Size = New System.Drawing.Size(64, 21)
        Me.AtcTextSYear.SoftMax = -999
        Me.AtcTextSYear.SoftMin = -999
        Me.AtcTextSYear.TabIndex = 30
        Me.AtcTextSYear.ValueDouble = 2000
        Me.AtcTextSYear.ValueInteger = 2000
        '
        'AtcTextEMon
        '
        Me.AtcTextEMon.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextEMon.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextEMon.DefaultValue = ""
        Me.AtcTextEMon.HardMax = 12
        Me.AtcTextEMon.HardMin = 1
        Me.AtcTextEMon.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextEMon.Location = New System.Drawing.Point(129, 64)
        Me.AtcTextEMon.MaxWidth = 20
        Me.AtcTextEMon.Name = "AtcTextEMon"
        Me.AtcTextEMon.NumericFormat = "0"
        Me.AtcTextEMon.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextEMon.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextEMon.SelLength = 0
        Me.AtcTextEMon.SelStart = 0
        Me.AtcTextEMon.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextEMon.SoftMax = -999
        Me.AtcTextEMon.SoftMin = -999
        Me.AtcTextEMon.TabIndex = 29
        Me.AtcTextEMon.ValueDouble = 12
        Me.AtcTextEMon.ValueInteger = 12
        '
        'AtcTextSMonth
        '
        Me.AtcTextSMonth.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextSMonth.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextSMonth.DefaultValue = ""
        Me.AtcTextSMonth.HardMax = 12
        Me.AtcTextSMonth.HardMin = 1
        Me.AtcTextSMonth.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextSMonth.Location = New System.Drawing.Point(129, 38)
        Me.AtcTextSMonth.MaxWidth = 20
        Me.AtcTextSMonth.Name = "AtcTextSMonth"
        Me.AtcTextSMonth.NumericFormat = "0"
        Me.AtcTextSMonth.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextSMonth.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextSMonth.SelLength = 0
        Me.AtcTextSMonth.SelStart = 0
        Me.AtcTextSMonth.Size = New System.Drawing.Size(44, 21)
        Me.AtcTextSMonth.SoftMax = -999
        Me.AtcTextSMonth.SoftMin = -999
        Me.AtcTextSMonth.TabIndex = 28
        Me.AtcTextSMonth.ValueDouble = 1
        Me.AtcTextSMonth.ValueInteger = 1
        '
        'AtcTextEYear
        '
        Me.AtcTextEYear.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextEYear.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextEYear.DefaultValue = ""
        Me.AtcTextEYear.HardMax = 9999
        Me.AtcTextEYear.HardMin = 0
        Me.AtcTextEYear.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextEYear.Location = New System.Drawing.Point(60, 64)
        Me.AtcTextEYear.MaxWidth = 20
        Me.AtcTextEYear.Name = "AtcTextEYear"
        Me.AtcTextEYear.NumericFormat = "0"
        Me.AtcTextEYear.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextEYear.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextEYear.SelLength = 0
        Me.AtcTextEYear.SelStart = 0
        Me.AtcTextEYear.Size = New System.Drawing.Size(64, 21)
        Me.AtcTextEYear.SoftMax = -999
        Me.AtcTextEYear.SoftMin = -999
        Me.AtcTextEYear.TabIndex = 27
        Me.AtcTextEYear.ValueDouble = 2000
        Me.AtcTextEYear.ValueInteger = 2000
        '
        'AtcGridSiteVars
        '
        Me.AtcGridSiteVars.AllowHorizontalScrolling = True
        Me.AtcGridSiteVars.AllowNewValidValues = False
        Me.AtcGridSiteVars.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AtcGridSiteVars.CellBackColor = System.Drawing.SystemColors.Window
        Me.AtcGridSiteVars.Fixed3D = False
        Me.AtcGridSiteVars.LineColor = System.Drawing.SystemColors.Control
        Me.AtcGridSiteVars.LineWidth = 1.0!
        Me.AtcGridSiteVars.Location = New System.Drawing.Point(3, 44)
        Me.AtcGridSiteVars.Name = "AtcGridSiteVars"
        Me.AtcGridSiteVars.Size = New System.Drawing.Size(525, 377)
        Me.AtcGridSiteVars.Source = Nothing
        Me.AtcGridSiteVars.TabIndex = 63
        '
        'AtcGridBCMonthly
        '
        Me.AtcGridBCMonthly.AllowHorizontalScrolling = True
        Me.AtcGridBCMonthly.AllowNewValidValues = False
        Me.AtcGridBCMonthly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AtcGridBCMonthly.CellBackColor = System.Drawing.Color.Empty
        Me.AtcGridBCMonthly.Fixed3D = False
        Me.AtcGridBCMonthly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtcGridBCMonthly.LineColor = System.Drawing.Color.Empty
        Me.AtcGridBCMonthly.LineWidth = 0.0!
        Me.AtcGridBCMonthly.Location = New System.Drawing.Point(0, 46)
        Me.AtcGridBCMonthly.Name = "AtcGridBCMonthly"
        Me.AtcGridBCMonthly.Size = New System.Drawing.Size(531, 353)
        Me.AtcGridBCMonthly.Source = Nothing
        Me.AtcGridBCMonthly.TabIndex = 62
        '
        'AtcGridModelParms
        '
        Me.AtcGridModelParms.AllowHorizontalScrolling = True
        Me.AtcGridModelParms.AllowNewValidValues = False
        Me.AtcGridModelParms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AtcGridModelParms.CellBackColor = System.Drawing.SystemColors.Window
        Me.AtcGridModelParms.Fixed3D = False
        Me.AtcGridModelParms.LineColor = System.Drawing.SystemColors.Control
        Me.AtcGridModelParms.LineWidth = 1.0!
        Me.AtcGridModelParms.Location = New System.Drawing.Point(3, 53)
        Me.AtcGridModelParms.Name = "AtcGridModelParms"
        Me.AtcGridModelParms.Size = New System.Drawing.Size(525, 392)
        Me.AtcGridModelParms.Source = Nothing
        Me.AtcGridModelParms.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(297, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "UTC Offset (hrs)"
        '
        'AtcTextUTCOffset
        '
        Me.AtcTextUTCOffset.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.AtcTextUTCOffset.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.AtcTextUTCOffset.DefaultValue = ""
        Me.AtcTextUTCOffset.HardMax = 24
        Me.AtcTextUTCOffset.HardMin = 1
        Me.AtcTextUTCOffset.InsideLimitsBackground = System.Drawing.Color.White
        Me.AtcTextUTCOffset.Location = New System.Drawing.Point(391, 64)
        Me.AtcTextUTCOffset.MaxWidth = 20
        Me.AtcTextUTCOffset.Name = "AtcTextUTCOffset"
        Me.AtcTextUTCOffset.NumericFormat = "0"
        Me.AtcTextUTCOffset.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.AtcTextUTCOffset.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.AtcTextUTCOffset.SelLength = 0
        Me.AtcTextUTCOffset.SelStart = 0
        Me.AtcTextUTCOffset.Size = New System.Drawing.Size(54, 21)
        Me.AtcTextUTCOffset.SoftMax = -999
        Me.AtcTextUTCOffset.SoftMin = -999
        Me.AtcTextUTCOffset.TabIndex = 44
        Me.AtcTextUTCOffset.ValueDouble = 1
        Me.AtcTextUTCOffset.ValueInteger = 1
        '
        'AtcGridInputControl
        '
        Me.AtcGridInputControl.AllowHorizontalScrolling = True
        Me.AtcGridInputControl.AllowNewValidValues = False
        Me.AtcGridInputControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AtcGridInputControl.CellBackColor = System.Drawing.SystemColors.Window
        Me.AtcGridInputControl.Fixed3D = False
        Me.AtcGridInputControl.LineColor = System.Drawing.SystemColors.Control
        Me.AtcGridInputControl.LineWidth = 1.0!
        Me.AtcGridInputControl.Location = New System.Drawing.Point(3, 161)
        Me.AtcGridInputControl.Name = "AtcGridInputControl"
        Me.AtcGridInputControl.Size = New System.Drawing.Size(525, 281)
        Me.AtcGridInputControl.Source = Nothing
        Me.AtcGridInputControl.TabIndex = 64
        '
        'frmUEB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(570, 537)
        Me.Controls.Add(Me.cmdSimulate)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdAbout)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmUEB"
        Me.Text = "Utah Energy Balance Snow Accumulation and Melt Model (UEB) for BASINS"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        Logger.Msg("UEB for BASINS/MapWindow" & vbCrLf & vbCrLf & "Version 1.01", MsgBoxStyle.OkOnly, "BASINS UEB")
    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click
        ShowHelp("BASINS Details\Watershed and Instream Model Setup\UEB.html")
    End Sub

    Private Sub frmUEB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Windows.Forms.Keys.F1 Then
            ShowHelp("BASINS Details\Watershed and Instream Model Setup\UEB.html")
        End If
    End Sub

    Friend Sub EnableControls(ByVal aEnabled As Boolean)
        cmdCancel.Enabled = aEnabled
        cmdHelp.Enabled = aEnabled
        cmdAbout.Enabled = aEnabled
    End Sub

    Public Sub InitializeUI(ByVal aPlugIn As PlugIn)

        lblInstructions.Text = "Select existing UEB project by clicking in the Master Project File box OR " & vbCrLf & _
                               "build new UEB project by defining all fields on all tabs." & vbCrLf & _
                               "Existing data files (e.g. Weather, Parameter, ...) may be accessed on other tabs."

        pParmData = New clsUEBParameterFile("")
        With AtcGridModelParms
            .Source = New atcControls.atcGridSource
            .AllowHorizontalScrolling = False
        End With
        SetParmGrid()

        pSiteData = New clsUEBSiteFile("")
        With AtcGridSiteVars
            .Source = New atcControls.atcGridSource
            .AllowHorizontalScrolling = False
        End With
        SetSiteGrid()

        pInputControlData = New clsUEBInputControl("")
        With AtcGridInputControl
            .Source = New atcControls.atcGridSource
            .AllowHorizontalScrolling = False
        End With

        pOutputControlData = New clsUEBOutputControl("")


        'With AtcGridBCMonthly
        '    .Source = New atcControls.atcGridSource
        '    .AllowHorizontalScrolling = False
        'End With
        'AtcGridBCMonthly.Clear()
        'With AtcGridBCMonthly.Source
        '    .Columns = 2
        '    .ColorCells = True
        '    .FixedRows = 1
        '    .FixedColumns = 1
        '    .Rows = 13
        '    For i As Integer = 0 To .Rows - 1
        '        .CellColor(i, 0) = SystemColors.ControlDark
        '        .CellEditable(i, 1) = True
        '    Next
        '    .CellValue(0, 0) = "Month"
        '    .CellValue(0, 1) = "Avg. diurnal temp range"
        '    .CellValue(1, 0) = "January"
        '    .CellValue(2, 0) = "February"
        '    .CellValue(3, 0) = "March"
        '    .CellValue(4, 0) = "April"
        '    .CellValue(5, 0) = "May"
        '    .CellValue(6, 0) = "June"
        '    .CellValue(7, 0) = "July"
        '    .CellValue(8, 0) = "August"
        '    .CellValue(9, 0) = "September"
        '    .CellValue(10, 0) = "October"
        '    .CellValue(11, 0) = "November"
        '    .CellValue(12, 0) = "December"
        'End With
        'AtcGridBCMonthly.ColumnWidth(0) = 300

    End Sub

    'Private Sub rdoMeasuredNet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rdoMeasuredNet.Checked Then
    '        txtNetRadStation.Enabled = True
    '    Else
    '        txtNetRadStation.Enabled = False
    '    End If
    'End Sub

    'Private Sub rdoRadMeasuredInput_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rdoRadMeasuredInput.Checked Then
    '        txtShortRadStation.Enabled = True
    '    Else
    '        txtShortRadStation.Enabled = False
    '    End If
    'End Sub

    'Private Sub rdoRadEstimate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rdoRadEstimate.Checked Then 'no need for Input Shortwave or Net Radition Timeseries
    '        txtNetRadStation.Enabled = False
    '        txtShortRadStation.Enabled = False
    '    End If
    'End Sub

    Private Sub txtWeatherFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInputFile.Click
        Dim cdlg As New Windows.Forms.OpenFileDialog
        cdlg.Title = "Open UEB Weather File"
        cdlg.Filter = "UEB Weather files|*.in|All Files|*.*"
        If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtInputFile.Text = cdlg.FileName
        End If

    End Sub

    Private Sub txtMasterFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMasterFile.Click
        Dim cdlg As New Windows.Forms.OpenFileDialog
        cdlg.Title = "Open UEB master file containing all model data files"
        cdlg.Filter = "Master Input files|*.in|All Files|*.*"
        If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim lFilename As String = cdlg.FileName
            txtMasterFile.Text = lFilename
            OpenMasterFile(lFilename, pProjectDescription, pParmData.FileName, pSiteData.FileName, pInputControlData.FileName, pOutputControlData.FileName, pBCParameterFileName, pRadOpt)
            txtInputFile.Text = pInputControlData.FileName
            txtWatershedFile.Text = pOutputFileName
            txtParameterFile.Text = pParmData.FileName
            txtSiteFile.Text = pSiteData.FileName
            txtOutputFile.Text = pBCParameterFileName
            'Select Case pRadOpt
            '    Case 0
            '        rdoRadEstimate.Checked = True
            '    Case 1
            '        rdoRadMeasuredInput.Checked = True
            '    Case 2
            '        rdoMeasuredNet.Checked = True
            'End Select
        End If
    End Sub

    Private Sub txtWeatherFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInputFile.TextChanged
        'pWeatherData.FileName = txtWeatherFile.Text
        'If FileExists(txtWeatherFile.Text) Then
        '    pWeatherData.ReadWeatherFile()
        '    Dim lDate(5) As Integer
        '    J2Date(pWeatherData.SJDate, lDate)
        '    AtcTextSYear.ValueInteger = lDate(0)
        '    AtcTextSMonth.ValueInteger = lDate(1)
        '    AtcTextSDay.ValueInteger = lDate(2)
        '    AtcTextSHour.ValueInteger = lDate(3)
        '    atcTextTimeStep.ValueInteger = pWeatherData.TimeStep
        '    AtcTextIniEnergyContent.Text = pWeatherData.InitialEnergy
        '    AtcTextIniWaterEquiv.Text = pWeatherData.InitialH2OEquiv
        '    AtcTextSnowAge.Text = pWeatherData.InitialSnowAge
        'End If
    End Sub

    Private Sub txtParameterFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cdlg As New Windows.Forms.OpenFileDialog
        cdlg.Title = "Open UEB Parameter File"
        cdlg.Filter = "UEB Parameter files|*.dat|All Files|*.*"
        If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtParameterFile.Text = cdlg.FileName
        End If

    End Sub

    Private Sub txtParameterFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pParmData.FileName = txtParameterFile.Text
        If FileExists(pParmData.FileName) Then
            pParmData = Nothing
            pParmData = New clsUEBParameterFile(pParmData.FileName)
            SetParmGrid()
        End If
    End Sub

    Private Sub txtSiteFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cdlg As New Windows.Forms.OpenFileDialog
        cdlg.Title = "Open UEB Site File"
        cdlg.Filter = "UEB Site files|*.dat|All Files|*.*"
        If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtSiteFile.Text = cdlg.FileName
        End If

    End Sub

    Private Sub txtSiteFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pSiteData.FileName = txtSiteFile.Text
        If FileExists(pSiteData.FileName) Then
            pSiteData = Nothing
            pSiteData = New clsUEBSiteFile(pSiteData.FileName)
            SetSiteGrid()
        End If
    End Sub

    Private Sub txtBCParameterFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cdlg As New Windows.Forms.OpenFileDialog
        cdlg.Title = "Open UEB BC Parameter File"
        cdlg.Filter = "UEB BC Parameter files|*.dat|All Files|*.*"
        If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtOutputFile.Text = cdlg.FileName
        End If

    End Sub

    Private Sub txtBCParameterFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lMonth As Integer
        pBCParameterFileName = txtOutputFile.Text
        If FileExists(txtOutputFile.Text) Then
            ReadDataFile(txtOutputFile.Text, pBCDataArray)
            'AtcTextAParm.ValueDouble = pBCDataArray(0)
            'AtcTextCParm.ValueDouble = pBCDataArray(1)
            For i As Integer = 1 To 12
                lMonth = pBCDataArray(3 * i - 1)
                AtcGridBCMonthly.Source.CellValue(lMonth, 1) = pBCDataArray(3 * i)
            Next
            AtcGridBCMonthly.Refresh()
        End If
    End Sub

    Private Sub cmdSimulate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSimulate.Click

        UpdateInputFiles()

    End Sub

    Private Sub UpdateInputFiles()
        Dim lMsg As String
        Dim lValue As String

        lMsg = ""
        If pParmData.FileName.Length > 0 Then 'check parameter file inputs
            For i As Integer = 1 To pParmData.Variables.Count
                lValue = AtcGridModelParms.Source.CellValue(i, 1)
                If IsNumeric(lValue) Then
                    pParmData.Variables(i - 1).Value = lValue
                Else 'problem with a parameter value
                    lMsg = "Problem processing value on Model Parameters tab in row " & i
                    Exit For
                End If
            Next
            If lMsg.Length = 0 Then
                pParmData.WriteParameterFile()
            End If
        End If

        lMsg = ""
        If pSiteData.FileName.Length > 0 Then 'check site variable inputs
            For i As Integer = 1 To pSiteData.Variables.Count
                With AtcGridSiteVars.Source
                    If FileExists(.CellValue(i, 2)) Then 'valid NetCDF file entered
                        pSiteData.Variables(i - 1).GridFileName = .CellValue(i, 2)
                        If .CellValue(i, 3).Length > 0 Then
                            'TODO: check validity of Grid Variable name
                            pSiteData.Variables(i - 1).GridVariableName = .CellValue(i, 3)
                            pSiteData.Variables(i - 1).SpaceVarying = True
                        Else
                            lMsg = "No grid variable specified in row " & i
                            Exit For
                        End If
                    ElseIf IsNumeric(.CellValue(i, 1)) Then
                        pSiteData.Variables(i - 1).Value = .CellValue(i, 1)
                        pSiteData.Variables(i - 1).SpaceVarying = False
                    Else 'problem with a site value
                        lMsg = "Problem processing value on Site Variables tab in row " & i
                        Exit For
                    End If
                End With
            Next
            If lMsg.Length = 0 Then
                pSiteData.WriteSiteFile()
            End If
        End If

        lMsg = ""
        If pBCParameterFileName.Length > 0 Then
            'pBCDataArray(0) = AtcTextAParm.ValueDouble
            'pBCDataArray(1) = AtcTextCParm.ValueDouble
            Dim lMonth As Integer
            For i As Integer = 1 To 12
                If IsNumeric(AtcGridBCMonthly.Source.CellValue(i, 1)) Then
                    lMonth = pBCDataArray(3 * i - 1)
                    pBCDataArray(3 * i) = AtcGridBCMonthly.Source.CellValue(lMonth, 1)
                Else 'problem with a site value
                    lMsg = "Problem processing value on Bristow-Campbell Parameters tab in row " & i
                    Exit For
                End If
            Next
            If lMsg.Length = 0 Then
                WriteBCParmsFile(pBCParameterFileName, pBCDataArray)
            End If
        End If

    End Sub

    Private Sub SetParmGrid()

        AtcGridModelParms.Clear()
        With AtcGridModelParms.Source
            .Columns = 2
            .ColorCells = True
            .FixedRows = 1
            .FixedColumns = 1
            .CellValue(0, 0) = "Model Parameter"
            .CellValue(0, 1) = "Value"
            For i As Integer = 1 To pParmData.Variables.Count
                .CellValue(i, 0) = pParmData.Variables(i - 1).Description
                .CellColor(i, 0) = SystemColors.ControlDark
                .CellEditable(i, 1) = True
                .CellValue(i, 1) = pParmData.Variables(i - 1).Value
            Next
        End With
        AtcGridModelParms.Refresh()

    End Sub

    Private Sub SetSiteGrid()

        AtcGridSiteVars.Clear()
        With AtcGridSiteVars.Source
            .Columns = 4
            .ColorCells = True
            .FixedRows = 1
            .FixedColumns = 1
            .CellValue(0, 0) = "Site Variable"
            .CellValue(0, 1) = "Grid File"
            .CellValue(0, 2) = "Grid Variable Name"
            .CellValue(0, 3) = "Constant Value"
            For i As Integer = 1 To pSiteData.Variables.Count
                .CellValue(i, 0) = pSiteData.Variables(i - 1).Description
                .CellColor(i, 0) = SystemColors.ControlDark
                .CellValue(i, 1) = pSiteData.Variables(i - 1).GridFileName
                .CellEditable(i, 1) = True
                .CellValue(i, 2) = pSiteData.Variables(i - 1).GridVariableName
                .CellEditable(i, 2) = True
                .CellValue(i, 3) = pSiteData.Variables(i - 1).Value
                .CellEditable(i, 3) = True
            Next
        End With

    End Sub

    Private Sub SetInputControl()
        AtcGridInputControl.Clear()
        With AtcGridInputControl.Source
            .FixedColumns = 1
            .FixedRows = 1
            .CellValue(0, 0) = "Input Variable"
            .CellValue(0, 1) = "Grid File"
            .CellValue(0, 2) = "Grid Variable Name"
            .CellValue(0, 3) = "Timeseries File"
            .CellValue(0, 4) = "Constant Value"
            For i As Integer = 1 To pInputControlData.Variables.Count
                .CellValue(i, 0) = pInputControlData.Variables(i - 1).Description
                .CellColor(i, 0) = SystemColors.ControlDark
                .CellValue(i, 1) = pInputControlData.Variables(i - 1).GridFileName
                .CellEditable(i, 1) = True
                .CellValue(i, 2) = pInputControlData.Variables(i - 1).GridVariableName
                .CellEditable(i, 2) = True
                .CellValue(i, 3) = pInputControlData.Variables(i - 1).TimeFileName
                .CellEditable(i, 3) = True
                .CellValue(i, 4) = pInputControlData.Variables(i - 1).Value
                .CellEditable(i, 4) = True
            Next
        End With
    End Sub

    Private Sub AtcGridSiteVars_MouseDownCell(ByVal aGrid As atcControls.atcGrid, ByVal aRow As Integer, ByVal aColumn As Integer) Handles AtcGridSiteVars.MouseDownCell
        If aColumn = 2 Then
            Dim cdlg As New Windows.Forms.OpenFileDialog
            cdlg.Title = "Open Grid File for " & aGrid.Source.CellValue(aRow, 0)
            cdlg.Filter = "NetCDF files|*.nc|All Files|*.*"
            If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                aGrid.Source.CellValue(aRow, aColumn) = cdlg.FileName
            End If
        End If
    End Sub
End Class