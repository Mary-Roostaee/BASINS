Option Strict Off
Option Explicit On
Module modStatusTimeseriesUtility
    'Copyright 2006 AQUA TERRA Consultants - Royalty-free use permitted under open source license
	
	Public Sub UpdateInputTimeseriesDuranl(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'only timser for duranl is the input timser
		TimserStatus.Change("INPUT:TIMSER", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
	End Sub
	
	Public Sub UpdateOutputTimeseriesDuranl(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'no output timsers for duranl
	End Sub
	
	Public Sub UpdateInputTimeseriesCopy(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		Dim nmn, npt, i As Integer
		
        If O.TableExists("TIMESERIES") Then
            With O.Tables.Item("TIMESERIES")
                npt = .ParmValue("NPT")
                nmn = .ParmValue("NMN")
            End With
        Else
            npt = 0
            nmn = 0
        End If
		For i = 1 To npt
			TimserStatus.Change("INPUT:POINT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nmn
			TimserStatus.Change("INPUT:MEAN", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
	End Sub
	
	Public Sub UpdateOutputTimeseriesCopy(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		Dim nmn, npt, i As Integer
		
        If O.TableExists("TIMESERIES") Then
            With O.Tables.Item("TIMESERIES")
                npt = .ParmValue("NPT")
                nmn = .ParmValue("NMN")
            End With
        Else
            npt = 0
            nmn = 0
        End If
		For i = 1 To npt
			TimserStatus.Change("OUTPUT:POINT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nmn
			TimserStatus.Change("OUTPUT:MEAN", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
	End Sub
	
	Public Sub UpdateInputTimeseriesPltgen(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'only timser for pltgen is the input timser
		Dim nmn, npt, i As Integer
		
        If O.TableExists("PLOTINFO") Then
            With O.Tables.Item("PLOTINFO")
                npt = .ParmValue("NPT")
                nmn = .ParmValue("NMN")
            End With
        Else
            npt = 0
            nmn = 0
        End If
		For i = 1 To npt
			TimserStatus.Change("INPUT:POINT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		Next i
		For i = 1 To nmn
			TimserStatus.Change("INPUT:MEAN", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		Next i
	End Sub
	
	Public Sub UpdateOutputTimeseriesPltgen(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'no output timsers for pltgen
	End Sub
	
	Public Sub UpdateInputTimeseriesDisply(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'only timser for disply is the input timser
		TimserStatus.Change("INPUT:TIMSER", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
	End Sub
	
	Public Sub UpdateOutputTimeseriesDisply(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'no output timsers for disply
	End Sub
	
	Public Sub UpdateInputTimeseriesGener(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'two possible input timsers for gener
		Dim Opcode As Integer
		
		If O.TableExists("OPCODE") Then
            Opcode = O.Tables.Item("OPCODE").ParmValue("OPCODE")
		Else
			Opcode = 0
		End If
		If Opcode > 0 And Opcode <> 24 Then
			TimserStatus.Change("INPUT:ONE", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		End If
		If Opcode > 15 And Opcode < 24 Then
			TimserStatus.Change("INPUT:TWO", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		End If
	End Sub
	
	Public Sub UpdateOutputTimeseriesGener(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'only one output timser for gener
		TimserStatus.Change("OUTPUT:TIMSER", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
	End Sub
	
	Public Sub UpdateInputTimeseriesMutsin(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'no input timsers for mutsin
	End Sub
	
	Public Sub UpdateOutputTimeseriesMutsin(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'only timser for mutsin is the output timser
		Dim nmn, npt, i As Integer
		
        If O.TableExists("MUTSINFO") Then
            With O.Tables.Item("MUTSINFO")
                npt = .ParmValue("NPT")
                nmn = .ParmValue("NMN")
            End With
        Else
            npt = 0
            nmn = 0
        End If
		For i = 1 To npt
			TimserStatus.Change("OUTPUT:POINT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		Next i
		For i = 1 To nmn
			TimserStatus.Change("OUTPUT:MEAN", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
		Next i
	End Sub
	
	Public Sub UpdateInputTimeseriesReport(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		Dim ncon, i As Integer
		If O.TableExists("REPORT-FLAGS") Then
            ncon = O.Tables.Item("REPORT-FLAGS").ParmValue("NCON")
		Else
			ncon = 0
		End If
        For i = 1 To ncon
            TimserStatus.Change("INPUT:TIMSER", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusRequired)
        Next i
	End Sub
	
	Public Sub UpdateOutputTimeseriesReport(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'no output timsers for report
	End Sub
	
	Public Sub UpdateInputTimeseriesBmprac(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'input timsers for bmprac
		Dim nGqual, nCons, i As Integer
		
        If O.TableExists("GEN-INFO") Then
            With O.Tables.Item("GEN-INFO")
                nCons = .ParmValue("NCONS")
                nGqual = .ParmValue("NGQUAL")
            End With
        Else
            nCons = 0
            nGqual = 0
        End If
		
		'group inflow
		TimserStatus.Change("INFLOW:IVOL", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
        If Not O.Uci.CategoryBlock Is Nothing Then
            'have category block
            For i = 1 To O.Uci.CategoryBlock.Count
                TimserStatus.Change("INFLOW:CIVOL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            Next i
        End If
		For i = 1 To nCons
			TimserStatus.Change("INFLOW:ICON", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		TimserStatus.Change("INFLOW:IHEAT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		For i = 1 To 3
			TimserStatus.Change("INFLOW:ISED", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change("INFLOW:IDQAL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change2("INFLOW:ISQAL", 1, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("INFLOW:ISQAL", 2, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("INFLOW:ISQAL", 3, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("INFLOW:IOX", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 4
			TimserStatus.Change("INFLOW:IDNUT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 3
			TimserStatus.Change2("INFLOW:ISNUT", i, 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("INFLOW:ISNUT", i, 2, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 5
			TimserStatus.Change("INFLOW:IPLK", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("INFLOW:IPH", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		
	End Sub
	
	Public Sub UpdateOutputTimeseriesBmprac(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		'output timsers for bmprac
		Dim nGqual, nCons, i As Integer
		
        If O.TableExists("GEN-INFO") Then
            With O.Tables.Item("GEN-INFO")
                nCons = .ParmValue("NCONS")
                nGqual = .ParmValue("NGQUAL")
            End With
        Else
            nCons = 0
            nGqual = 0
        End If
		
		'group receiv
		TimserStatus.Change("RECEIV:IVOL", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
        If Not O.Uci.CategoryBlock Is Nothing Then
            'have category block
            For i = 1 To O.Uci.CategoryBlock.Count
                TimserStatus.Change("RECEIV:CIVOL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            Next i
        End If
		For i = 1 To nCons
			TimserStatus.Change("RECEIV:ICON", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		TimserStatus.Change("RECEIV:IHEAT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		For i = 1 To 3
			TimserStatus.Change("RECEIV:ISED", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change("RECEIV:IDQAL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change2("RECEIV:ISQAL", 1, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("RECEIV:ISQAL", 2, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("RECEIV:ISQAL", 3, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("RECEIV:IOX", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 4
			TimserStatus.Change("RECEIV:IDNUT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 3
			TimserStatus.Change2("RECEIV:ISNUT", i, 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("RECEIV:ISNUT", i, 2, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 5
			TimserStatus.Change("RECEIV:IPLK", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("RECEIV:IPH", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		
		'group roflow
		TimserStatus.Change("ROFLOW:ROVOL", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)		
		If Not O.Uci.CategoryBlock Is Nothing Then
			'have category block
            For i = 1 To O.Uci.CategoryBlock.Count
                TimserStatus.Change("ROFLOW:CROVOL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            Next i
		End If
		For i = 1 To nCons
			TimserStatus.Change("ROFLOW:ROCON", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		TimserStatus.Change("ROFLOW:ROHEAT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		For i = 1 To 3
			TimserStatus.Change("ROFLOW:ROSED", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change("ROFLOW:RODQAL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change2("ROFLOW:ROSQAL", 1, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("ROFLOW:ROSQAL", 2, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("ROFLOW:ROSQAL", 3, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("ROFLOW:ROOX", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 4
			TimserStatus.Change("ROFLOW:RODNUT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 3
			TimserStatus.Change2("ROFLOW:ROSNUT", i, 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("ROFLOW:ROSNUT", i, 2, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 5
			TimserStatus.Change("ROFLOW:ROPLK", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("ROFLOW:ROPH", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		
		'group remove
		TimserStatus.Change("REMOVE:RMVOL", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)		
		If Not O.Uci.CategoryBlock Is Nothing Then
			'have category block
            For i = 1 To O.Uci.CategoryBlock.Count
                TimserStatus.Change("REMOVE:CRMVOL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            Next i
		End If
		For i = 1 To nCons
			TimserStatus.Change("REMOVE:RMCON", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		TimserStatus.Change("REMOVE:RMHEAT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		For i = 1 To 3
			TimserStatus.Change("REMOVE:RMSED", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change("REMOVE:RMDQAL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To nGqual
			TimserStatus.Change2("REMOVE:RMSQAL", 1, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("REMOVE:RMSQAL", 2, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("REMOVE:RMSQAL", 3, i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("REMOVE:RMOX", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 4
			TimserStatus.Change("REMOVE:RMDNUT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 3
			TimserStatus.Change2("REMOVE:RMSNUT", i, 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
			TimserStatus.Change2("REMOVE:RMSNUT", i, 2, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 5
			TimserStatus.Change("REMOVE:RMPLK", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		For i = 1 To 2
			TimserStatus.Change("REMOVE:RMPH", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
		Next i
		
	End Sub
End Module