Option Strict Off
Option Explicit On
Module modStatusOutputTimeseriesImplnd
    'Copyright 2006 AQUA TERRA Consultants - Royalty-free use permitted under open source license
	
	Public Sub UpdateOutputTimeseriesImplnd(ByRef O As HspfOperation, ByRef TimserStatus As HspfStatus)
		Dim ltable As HspfTable
		Dim nquals As Integer
        Dim i As Integer
		Dim iqadfg(20) As Integer
		Dim ctemp As String
		Dim nqsd, nqof, snopfg As Integer
		
		If O.TableExists("ACTIVITY") Then
			ltable = O.Tables.Item("ACTIVITY")
			
			'section atemp
            If ltable.Parms.Item("ATMPFG") = 1 Then
                TimserStatus.Change("ATEMP:AIRTMP", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            End If
			
			'section snow
			If O.TableExists("SNOW-FLAGS") Then
                snopfg = O.Tables.Item("SNOW-FLAGS").ParmValue("SNOPFG")
			Else
				snopfg = 0
			End If
            If ltable.Parms.Item("SNOWFG") = 1 Then
                TimserStatus.Change("SNOW:PACK", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:PACKF", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:PACKW", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:PACKI", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:PDEPTH", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:COVINX", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:NEGHTS", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:XLNMLT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:RDENPF", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:SKYCLR", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:SNOCOV", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                If snopfg = 0 Then
                    TimserStatus.Change("SNOW:DULL", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("SNOW:ALBEDO", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                End If
                TimserStatus.Change("SNOW:PAKTMP", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:SNOTMP", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:DWMTMP", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:SNOWF", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:PRAIN", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                If snopfg = 0 Then
                    TimserStatus.Change("SNOW:SNOWE", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                End If
                TimserStatus.Change("SNOW:WYIELD", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:MELT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SNOW:RAINF", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            End If
			
			'section iwater
            If ltable.Parms.Item("IWATFG") = 1 Then
                TimserStatus.Change("IWATER:IMPS", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:RETS", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:SURS", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:PETADJ", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:SUPY", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:SURO", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:PET", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:IMPEV", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWATER:SURI", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            End If
			
			'section solids
            If ltable.Parms.Item("SLDFG") = 1 Then
                TimserStatus.Change("SOLIDS:SLDS", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("SOLIDS:SOSLD", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            End If
			
			'section iwtgas
            If ltable.Parms.Item("IWGFG") = 1 Then
                TimserStatus.Change("IWTGAS:SOTMP", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWTGAS:SODOX", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWTGAS:SOCO2", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWTGAS:SOHT", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWTGAS:SODOXM", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                TimserStatus.Change("IWTGAS:SOCO2M", 1, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
            End If
			
			'section iqual
            If ltable.Parms.Item("IQALFG") = 1 Then
                If O.TableExists("NQUALS") Then
                    nquals = O.Tables.Item("NQUALS").ParmValue("NQUAL")
                Else
                    nquals = 1
                End If
                nqof = 0
                nqsd = 0
                For i = 1 To nquals
                    ctemp = "QUAL-PROPS" & CStr(i)
                    If O.TableExists(ctemp) Then
                        With O.Tables.Item(ctemp)
                            If .ParmValue("QSOFG") > 0 Then
                                nqof = nqof + 1
                            End If
                            If .ParmValue("QSDFG") > 0 Then
                                nqsd = nqsd + 1
                            End If
                        End With
                    End If
                Next i

                For i = 1 To nquals
                    TimserStatus.Change("IQUAL:SOQUAL", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:SOQC", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:IQADDR", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:IQADWT", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:IQADEP", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                Next i
                For i = 1 To nqof
                    TimserStatus.Change("IQUAL:SQO", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:SOQO", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:SOQOC", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                Next i
                For i = 1 To nqsd
                    TimserStatus.Change("IQUAL:SOQS", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                    TimserStatus.Change("IQUAL:SOQSP", i, HspfStatus.HspfStatusReqOptUnnEnum.HspfStatusOptional)
                Next i
            End If
			
		End If
	End Sub
End Module