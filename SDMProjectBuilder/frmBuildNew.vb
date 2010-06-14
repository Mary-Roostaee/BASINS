Imports atcUtility
Imports MapWinUtility

Public Class frmBuildNew
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtInstructions.Text = "To Build a New " & g_AppNameShort & " Project, " & _
           "zoom/pan to your geographic area of interest, select (highlight) it, " & _
           "and then click 'Build'.  " '& _
        '"If your area is outside the US, then click 'Build' " & _
        '"with no features selected to create an international project."

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
    Friend WithEvents btnBuild As System.Windows.Forms.Button
    Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbxHSPF As System.Windows.Forms.CheckBox
    Friend WithEvents cbxSWAT As System.Windows.Forms.CheckBox
    Friend WithEvents atxSize As atcControls.atcText
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents atxLength As atcControls.atcText
    Friend WithEvents lblLU As System.Windows.Forms.Label
    Friend WithEvents atxLU As atcControls.atcText
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents lblSWAT As System.Windows.Forms.Label
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lblSimulationStartYear As System.Windows.Forms.Label
    Friend WithEvents txtSimulationStartYear As atcControls.atcText
    Friend WithEvents lblSimulationEndYear As System.Windows.Forms.Label
    Friend WithEvents txtSimulationEndYear As atcControls.atcText
    Friend WithEvents txtSelected As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnBuild = New System.Windows.Forms.Button
        Me.txtInstructions = New System.Windows.Forms.TextBox
        Me.txtSelected = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cbxHSPF = New System.Windows.Forms.CheckBox
        Me.cbxSWAT = New System.Windows.Forms.CheckBox
        Me.atxSize = New atcControls.atcText
        Me.lblSize = New System.Windows.Forms.Label
        Me.lblLength = New System.Windows.Forms.Label
        Me.atxLength = New atcControls.atcText
        Me.lblLU = New System.Windows.Forms.Label
        Me.atxLU = New atcControls.atcText
        Me.cmdSet = New System.Windows.Forms.Button
        Me.lblSWAT = New System.Windows.Forms.Label
        Me.lblFile = New System.Windows.Forms.Label
        Me.lblSimulationStartYear = New System.Windows.Forms.Label
        Me.txtSimulationStartYear = New atcControls.atcText
        Me.lblSimulationEndYear = New System.Windows.Forms.Label
        Me.txtSimulationEndYear = New atcControls.atcText
        Me.SuspendLayout()
        '
        'btnBuild
        '
        Me.btnBuild.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuild.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuild.Location = New System.Drawing.Point(354, 323)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(80, 28)
        Me.btnBuild.TabIndex = 1
        Me.btnBuild.Text = "Build"
        '
        'txtInstructions
        '
        Me.txtInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstructions.BackColor = System.Drawing.SystemColors.Control
        Me.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructions.Location = New System.Drawing.Point(13, 14)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(507, 65)
        Me.txtInstructions.TabIndex = 2
        Me.txtInstructions.TabStop = False
        '
        'txtSelected
        '
        Me.txtSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelected.BackColor = System.Drawing.SystemColors.Menu
        Me.txtSelected.Location = New System.Drawing.Point(12, 76)
        Me.txtSelected.Multiline = True
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(508, 67)
        Me.txtSelected.TabIndex = 3
        Me.txtSelected.TabStop = False
        Me.txtSelected.Text = "Selected Features:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(440, 323)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 28)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'cbxHSPF
        '
        Me.cbxHSPF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxHSPF.AutoSize = True
        Me.cbxHSPF.Checked = True
        Me.cbxHSPF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxHSPF.Location = New System.Drawing.Point(12, 149)
        Me.cbxHSPF.Name = "cbxHSPF"
        Me.cbxHSPF.Size = New System.Drawing.Size(54, 17)
        Me.cbxHSPF.TabIndex = 5
        Me.cbxHSPF.Text = "HSPF"
        Me.cbxHSPF.UseVisualStyleBackColor = True
        '
        'cbxSWAT
        '
        Me.cbxSWAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxSWAT.AutoSize = True
        Me.cbxSWAT.Checked = True
        Me.cbxSWAT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxSWAT.Location = New System.Drawing.Point(72, 149)
        Me.cbxSWAT.Name = "cbxSWAT"
        Me.cbxSWAT.Size = New System.Drawing.Size(58, 17)
        Me.cbxSWAT.TabIndex = 6
        Me.cbxSWAT.Text = "SWAT"
        Me.cbxSWAT.UseVisualStyleBackColor = True
        '
        'atxSize
        '
        Me.atxSize.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.atxSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.atxSize.DataType = atcControls.atcText.ATCoDataType.ATCoDbl
        Me.atxSize.DefaultValue = "1.0"
        Me.atxSize.HardMax = -999
        Me.atxSize.HardMin = 0
        Me.atxSize.InsideLimitsBackground = System.Drawing.Color.White
        Me.atxSize.Location = New System.Drawing.Point(12, 172)
        Me.atxSize.MaxWidth = 20
        Me.atxSize.Name = "atxSize"
        Me.atxSize.NumericFormat = "0.#####"
        Me.atxSize.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.atxSize.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.atxSize.SelLength = 0
        Me.atxSize.SelStart = 0
        Me.atxSize.Size = New System.Drawing.Size(49, 19)
        Me.atxSize.SoftMax = -999
        Me.atxSize.SoftMin = -999
        Me.atxSize.TabIndex = 7
        Me.atxSize.ValueDouble = 1
        Me.atxSize.ValueInteger = 1
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(69, 178)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(216, 13)
        Me.lblSize.TabIndex = 8
        Me.lblSize.Text = "Minimum Catchment Size (square kilometers)"
        '
        'lblLength
        '
        Me.lblLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLength.AutoSize = True
        Me.lblLength.Location = New System.Drawing.Point(69, 202)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(181, 13)
        Me.lblLength.TabIndex = 10
        Me.lblLength.Text = "Minimum Flowline Length (kilometers)"
        '
        'atxLength
        '
        Me.atxLength.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.atxLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.atxLength.DataType = atcControls.atcText.ATCoDataType.ATCoDbl
        Me.atxLength.DefaultValue = "1.0"
        Me.atxLength.HardMax = -999
        Me.atxLength.HardMin = 0
        Me.atxLength.InsideLimitsBackground = System.Drawing.Color.White
        Me.atxLength.Location = New System.Drawing.Point(12, 197)
        Me.atxLength.MaxWidth = 20
        Me.atxLength.Name = "atxLength"
        Me.atxLength.NumericFormat = "0.#####"
        Me.atxLength.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.atxLength.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.atxLength.SelLength = 0
        Me.atxLength.SelStart = 0
        Me.atxLength.Size = New System.Drawing.Size(49, 18)
        Me.atxLength.SoftMax = -999
        Me.atxLength.SoftMin = -999
        Me.atxLength.TabIndex = 9
        Me.atxLength.ValueDouble = 5
        Me.atxLength.ValueInteger = 5
        '
        'lblLU
        '
        Me.lblLU.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLU.AutoSize = True
        Me.lblLU.Location = New System.Drawing.Point(69, 226)
        Me.lblLU.Name = "lblLU"
        Me.lblLU.Size = New System.Drawing.Size(184, 13)
        Me.lblLU.TabIndex = 12
        Me.lblLU.Text = "Ignore Landuse Areas Below Fraction"
        '
        'atxLU
        '
        Me.atxLU.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.atxLU.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.atxLU.DataType = atcControls.atcText.ATCoDataType.ATCoDbl
        Me.atxLU.DefaultValue = "0.07"
        Me.atxLU.HardMax = 1
        Me.atxLU.HardMin = 0
        Me.atxLU.InsideLimitsBackground = System.Drawing.Color.White
        Me.atxLU.Location = New System.Drawing.Point(12, 221)
        Me.atxLU.MaxWidth = 20
        Me.atxLU.Name = "atxLU"
        Me.atxLU.NumericFormat = "0.#####"
        Me.atxLU.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.atxLU.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.atxLU.SelLength = 0
        Me.atxLU.SelStart = 0
        Me.atxLU.Size = New System.Drawing.Size(49, 18)
        Me.atxLU.SoftMax = -999
        Me.atxLU.SoftMin = -999
        Me.atxLU.TabIndex = 11
        Me.atxLU.ValueDouble = 0.07
        Me.atxLU.ValueInteger = 0
        '
        'cmdSet
        '
        Me.cmdSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSet.Location = New System.Drawing.Point(491, 297)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(29, 20)
        Me.cmdSet.TabIndex = 13
        Me.cmdSet.Text = "..."
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'lblSWAT
        '
        Me.lblSWAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSWAT.AutoSize = True
        Me.lblSWAT.Location = New System.Drawing.Point(12, 302)
        Me.lblSWAT.Name = "lblSWAT"
        Me.lblSWAT.Size = New System.Drawing.Size(107, 13)
        Me.lblSWAT.TabIndex = 14
        Me.lblSWAT.Text = "SWAT Database File"
        '
        'lblFile
        '
        Me.lblFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFile.Location = New System.Drawing.Point(125, 300)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile.Size = New System.Drawing.Size(360, 15)
        Me.lblFile.TabIndex = 15
        Me.lblFile.Text = "SWAT2005.mdb"
        Me.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSimulationStartYear
        '
        Me.lblSimulationStartYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSimulationStartYear.AutoSize = True
        Me.lblSimulationStartYear.Location = New System.Drawing.Point(69, 250)
        Me.lblSimulationStartYear.Name = "lblSimulationStartYear"
        Me.lblSimulationStartYear.Size = New System.Drawing.Size(105, 13)
        Me.lblSimulationStartYear.TabIndex = 17
        Me.lblSimulationStartYear.Text = "Simulation Start Year"
        '
        'txtSimulationStartYear
        '
        Me.txtSimulationStartYear.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSimulationStartYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSimulationStartYear.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.txtSimulationStartYear.DefaultValue = "0.0"
        Me.txtSimulationStartYear.HardMax = 3000
        Me.txtSimulationStartYear.HardMin = 0
        Me.txtSimulationStartYear.InsideLimitsBackground = System.Drawing.Color.White
        Me.txtSimulationStartYear.Location = New System.Drawing.Point(12, 245)
        Me.txtSimulationStartYear.MaxWidth = 20
        Me.txtSimulationStartYear.Name = "txtSimulationStartYear"
        Me.txtSimulationStartYear.NumericFormat = "0.#####"
        Me.txtSimulationStartYear.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.txtSimulationStartYear.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.txtSimulationStartYear.SelLength = 0
        Me.txtSimulationStartYear.SelStart = 0
        Me.txtSimulationStartYear.Size = New System.Drawing.Size(49, 18)
        Me.txtSimulationStartYear.SoftMax = -999
        Me.txtSimulationStartYear.SoftMin = -999
        Me.txtSimulationStartYear.TabIndex = 16
        Me.txtSimulationStartYear.ValueDouble = 1990
        Me.txtSimulationStartYear.ValueInteger = 1990
        '
        'lblSimulationEndYear
        '
        Me.lblSimulationEndYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSimulationEndYear.AutoSize = True
        Me.lblSimulationEndYear.Location = New System.Drawing.Point(69, 274)
        Me.lblSimulationEndYear.Name = "lblSimulationEndYear"
        Me.lblSimulationEndYear.Size = New System.Drawing.Size(102, 13)
        Me.lblSimulationEndYear.TabIndex = 19
        Me.lblSimulationEndYear.Text = "Simulation End Year"
        '
        'txtSimulationEndYear
        '
        Me.txtSimulationEndYear.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSimulationEndYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSimulationEndYear.DataType = atcControls.atcText.ATCoDataType.ATCoInt
        Me.txtSimulationEndYear.DefaultValue = "0.0"
        Me.txtSimulationEndYear.HardMax = 3000
        Me.txtSimulationEndYear.HardMin = 0
        Me.txtSimulationEndYear.InsideLimitsBackground = System.Drawing.Color.White
        Me.txtSimulationEndYear.Location = New System.Drawing.Point(12, 269)
        Me.txtSimulationEndYear.MaxWidth = 20
        Me.txtSimulationEndYear.Name = "txtSimulationEndYear"
        Me.txtSimulationEndYear.NumericFormat = "0.#####"
        Me.txtSimulationEndYear.OutsideHardLimitBackground = System.Drawing.Color.Coral
        Me.txtSimulationEndYear.OutsideSoftLimitBackground = System.Drawing.Color.Yellow
        Me.txtSimulationEndYear.SelLength = 0
        Me.txtSimulationEndYear.SelStart = 0
        Me.txtSimulationEndYear.Size = New System.Drawing.Size(49, 18)
        Me.txtSimulationEndYear.SoftMax = -999
        Me.txtSimulationEndYear.SoftMin = -999
        Me.txtSimulationEndYear.TabIndex = 18
        Me.txtSimulationEndYear.ValueDouble = 2000
        Me.txtSimulationEndYear.ValueInteger = 2000
        '
        'frmBuildNew
        '
        Me.AcceptButton = Me.btnBuild
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(532, 363)
        Me.Controls.Add(Me.lblSimulationEndYear)
        Me.Controls.Add(Me.txtSimulationEndYear)
        Me.Controls.Add(Me.lblSimulationStartYear)
        Me.Controls.Add(Me.txtSimulationStartYear)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.lblSWAT)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.lblLU)
        Me.Controls.Add(Me.atxLU)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.atxLength)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.atxSize)
        Me.Controls.Add(Me.cbxSWAT)
        Me.Controls.Add(Me.cbxHSPF)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtSelected)
        Me.Controls.Add(Me.txtInstructions)
        Me.Controls.Add(Me.btnBuild)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuildNew"
        Me.Opacity = 0.8
        Me.Text = "Build Project"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub cmdBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuild.Click
        SaveSetting(g_AppNameRegistry, "Window Positions", "BuildTop", Me.Top)
        SaveSetting(g_AppNameRegistry, "Window Positions", "BuildLeft", Me.Left)

        g_DoHSPF = cbxHSPF.Checked
        g_DoSWAT = cbxSWAT.Checked
        g_MinCatchmentKM2 = atxSize.Text
        g_MinFlowlineKM = atxLength.Text
        g_LandUseIgnoreBelowFraction = atxLU.Text
        g_SimulationStartYear = txtSimulationStartYear.ValueInteger
        g_SimulationEndYear = txtSimulationEndYear.ValueInteger
        g_SWATDatabaseName = lblFile.Text

        Me.Visible = False

        Dim lCreatedMapWindowProjectFilename As String = SpecifyAndCreateNewProject()

        If IO.File.Exists(lCreatedMapWindowProjectFilename) Then
            Me.Close()
        Else
            Me.Visible = True
            modSDM.pBuildFrm = Me
        End If
    End Sub

    Private Sub frmBuildNew_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 1
    End Sub

    Private Sub frmBuildNew_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.8
    End Sub

    Private Sub frmBuildNew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Windows.Forms.Keys.F1 Then
            ShowHelp("BASINS Details\Welcome to BASINS 4 Window\Build BASINS Project.html")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBuildNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = g_MapWin.ApplicationInfo.FormIcon
        Me.Text = "Build " & g_AppNameLong & " Project"

        cbxHSPF.Checked = g_DoHSPF
        cbxSWAT.Checked = g_DoSWAT
        atxSize.Text = g_MinCatchmentKM2
        atxLength.Text = g_MinFlowlineKM
        atxLU.Text = g_LandUseIgnoreBelowFraction
        txtSimulationStartYear.ValueInteger = g_SimulationStartYear
        txtSimulationEndYear.ValueInteger = g_SimulationEndYear
        lblFile.Text = g_SWATDatabaseName
    End Sub

    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click
        g_SWATDatabaseName = FindFile("Please locate SWAT2005.mdb", "SWAT2005.mdb").Replace("swat", "SWAT")
        lblFile.Text = g_SWATDatabaseName
    End Sub
End Class
