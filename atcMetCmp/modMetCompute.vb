Option Strict Off
Option Explicit On 
Imports atcData
Imports atcUtility
Module modMetCompute
  'Copyright 2005 by AQUA TERRA Consultants
  Dim X1() As Double = {0, 10.00028, 41.0003, 69.22113, 100.5259, 130.8852, 161.2853, _
                        191.7178, 222.1775, 253.66, 281.1629, 309.6838, 341.221}
  Dim c(,) As Double = { _
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
    {0, 4.0, 2.0, -1.5, -3.0, -2.0, 1.0, 3.0, 2.5, 1.0, 1.0, 2.0, 1.0}, _
    {0, 3.0, 4.0, 0.0, -3.0, -2.5, 0.0, 2.0, 3.0, 2.0, 1.5, 2.0, 1.0}, _
    {0, 0.0, 3.5, 1.5, -1.0, -2.0, -1.0, 1.5, 3.0, 3.0, 1.5, 2.0, 1.0}, _
    {0, -2.0, 2.5, 3.5, 0.0, -2.0, -1.0, 0.5, 3.0, 3.0, 2.0, 2.0, 1.0}, _
    {0, -4.0, 0.5, 3.0, 1.0, -0.5, -1.0, 0.0, 2.0, 2.5, 2.5, 2.0, 1.0}, _
    {0, -5.0, -1.5, 2.0, 3.0, 0.5, -1.0, -0.5, 1.0, 2.5, 2.5, 2.0, 1.0}, _
    {0, -5.0, -3.5, 1.0, 3.0, 1.5, 0.0, -0.5, 1.0, 2.0, 2.0, 2.0, 1.0}, _
    {0, -4.0, -4.5, -1.0, 2.5, 3.0, 1.0, 0.0, 0.0, 1.5, 2.0, 2.0, 1.0}, _
    {0, -2.0, -4.0, -3.0, 1.0, 3.0, 2.0, 0.5, 0.0, 1.5, 2.0, 1.0, 1.0}, _
    {0, 0.0, -3.5, -4.0, -0.5, 3.0, 3.0, 1.5, 1.0, 1.0, 2.0, 1.0, 1.0}}
   '{0, 4, 3, 0, -2, -4, -5, -5, -4, -2, 0}, _
  '{0, 2, 4, 3.5, 2.5, 0.5, -1.5, -3.5, -4.5, -4, -3.5}, _
  '{0, -1.5, 0, 1.5, 3.5, 3, 2, 1, -1, -3, -4}, _
  '{0, -3, -3, -1, 0, 1, 3, 3, 2.5, 1, -0.5}, _
  '{0, -2, -2.5, -2, -2, -0.5, 0.5, 1.5, 3, 3, 3}, _
  '{0, 1, 0, -1, -1, -1, -1, 0, 1, 2, 3}, _
  '{0, 3, 2, 1.5, 0.5, 0, -0.5, -0.5, 0, 0.5, 1.5}, _
  '{0, 2.5, 3, 3, 3, 2, 1, 1, 0, 0, 1}, _
  '{0, 1, 2, 3, 3, 2.5, 2.5, 2, 1.5, 1.5, 1}, _
  '{0, 1, 1.5, 1.5, 2, 2.5, 2.5, 2, 2, 2, 2}, _
  '{0, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1}, _
  '{0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}}
  Dim XLax(,) As Double = { _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, -9, -9, -9, -9, -9, -9}, _
    {-9, 616.17, -147.83, -27.17, -3.17, 11.84, 2.02}, _
    {-9, 609.97, -154.71, -27.49, -2.97, 12.04, 1.3}, _
    {-9, 603.69, -161.55, -27.69, -2.78, 12.22, 0.64}, _
    {-9, 597.29, -168.33, -27.78, -2.6, 12.38, 0.02}, _
    {-9, 590.81, -175.05, -27.74, -2.43, 12.53, -0.56}, _
    {-9, 584.21, -181.72, -27.57, -2.28, 12.67, -1.1}, _
    {-9, 577.53, -188.34, -27.29, -2.14, 12.8, -1.6}, _
    {-9, 570.73, -194.91, -26.89, -2.02, 12.92, -2.05}, _
    {-9, 563.85, -201.42, -26.37, -1.91, 13.03, -2.45}, _
    {-9, 556.85, -207.29, -25.72, -1.81, 13.13, -2.8}, _
    {-9, 549.77, -214.29, -24.96, -1.72, 13.22, -3.1}, _
    {-9, 542.57, -220.65, -24.07, -1.64, 13.3, -3.35}, _
    {-9, 535.3, -226.96, -23.07, -1.59, 13.36, -3.58}, _
    {-9, 527.9, -233.22, -21.95, -1.55, 13.4, -3.77}, _
    {-9, 520.44, -239.43, -20.7, -1.52, 13.42, -3.92}, _
    {-9, 512.84, -245.59, -19.33, -1.51, 13.42, -4.03}, _
    {-9, 505.19, -251.69, -17.83, -1.51, 13.41, -4.1}, _
    {-9, 497.4, -257.74, -16.22, -1.52, 13.39, -4.13}, _
    {-9, 489.52, -263.74, -14.49, -1.54, 13.36, -4.12}, _
    {-9, 481.53, -269.7, -12.63, -1.57, 13.32, -4.07}, _
    {-9, 473.45, -275.6, -10.65, -1.63, 13.27, -3.98}, _
    {-9, 465.27, -281.45, -8.55, -1.71, 13.21, -3.85}, _
    {-9, 456.99, -287.25, -6.33, -1.8, 13.14, -3.68}, _
    {-9, 448.61, -292.99, -3.98, -1.9, 13.07, -3.47}, _
    {-9, 440.14, -298.68, -1.51, -2.01, 13.0#, -3.3}, _
    {-9, 431.55, -304.32, 1.08, -2.13, 12.92, -3.17}, _
    {-9, 431.55, -304.32, 1.08, -2.13, 12.92, -3.17}}
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '616.17, 609.97, 603.69, 597.29, 590.81, 584.21, 577.53, 570.73, 563.85, _
  '556.85, 549.77, 542.57, 535.3, 527.9, 520.44, 512.84, 505.19, 497.4, _
  '489.52, 481.53, 473.45, 465.27, 456.99, 448.61, 440.14, 431.55, 431.55}, _
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '-147.83, -154.71, -161.55, -168.33, -175.05, -181.72, -188.34, -194.91, -201.42, _
  '-207.29, -214.29, -220.65, -226.96, -233.22, -239.43, -245.59, -251.69, -257.74, _
  '-263.74, -269.7, -275.6, -281.45, -287.25, -292.99, -298.68, -304.32, -304.32}, _
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '-27.17, -27.49, -27.69, -27.78, -27.74, -27.57, -27.29, -26.89, -26.37, _
  '-25.72, -24.96, -24.07, -23.07, -21.95, -20.7, -19.33, -17.83, -16.22, _
  '-14.49, -12.63, -10.65, -8.55, -6.33, -3.98, -1.51, 1.08, 1.08}, _
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '-3.17, -2.97, -2.78, -2.6, -2.43, -2.28, -2.14, -2.02, -1.91, _
  '-1.81, -1.72, -1.64, -1.59, -1.55, -1.52, -1.51, -1.51, -1.52, _
  '-1.54, -1.57, -1.63, -1.71, -1.8, -1.9, -2.01, -2.13, -2.13}, _
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '11.84, 12.04, 12.22, 12.38, 12.53, 12.67, 12.8, 12.92, 13.03, _
  '13.13, 13.22, 13.3, 13.36, 13.4, 13.42, 13.42, 13.41, 13.39, _
  '13.36, 13.32, 13.27, 13.21, 13.14, 13.07, 13.0, 12.92, 12.92}, _
  '{-9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, -9, _
  '2.02, 1.3, 0.64, 0.02, -0.56, -1.1, -1.6, -2.05, -2.45, _
  '-2.8, -3.1, -3.35, -3.58, -3.77, -3.92, -4.03, -4.1, -4.13, _
  '-4.12, -4.07, -3.98, -3.85, -3.68, -3.47, -3.3, -3.17, -3.17}}


  Public Function CmpSol(ByVal aCldTSer As atcTimeseries, ByVal aSource As atcDataSource, ByVal aLatDeg As Double) As atcTimeseries
    'compute daily solar radiation based on daily cloud cover
    Dim i As Integer
    Dim ldate(5) As Integer
    Dim SolRad(aCldTSer.numValues) As Double
    Dim CldCov(aCldTSer.numValues) As Double
    Dim lCmpTs As New atcTimeseries(aSource)
    Dim lPoint As Boolean = aCldTSer.Attributes.GetValue("point", False)

    CopyBaseAttributes(aCldTSer, lCmpTs)
    lCmpTs.Attributes.SetValue("Constituent", "DSOL")
    lCmpTs.Attributes.SetValue("TSTYPE", "DSOL")
    lCmpTs.Attributes.SetValue("Scenario", "COMPUTED")
    lCmpTs.Attributes.SetValue("Description", "Daily Solar Radiation (langleys) computed from Daily Cloud Cover")
    lCmpTs.Attributes.AddHistory("Computed Daily Solar Radiation - inputs: DCLD, Latitude")
    lCmpTs.Attributes.Add("DCLD", aCldTSer.ToString)
    lCmpTs.Attributes.Add("Latitude", aLatDeg)
    lCmpTs.Dates = aCldTSer.Dates
    lCmpTs.numValues = aCldTSer.numValues
    Array.Copy(aCldTSer.Values, 1, CldCov, 1, aCldTSer.numValues)

    For i = 1 To lCmpTs.numValues
      If CldCov(i) <= 0.0# Then CldCov(i) = 0.000001
      If lPoint Then
        Call J2Date(aCldTSer.Dates.Value(i), ldate)
      Else
        Call J2Date(aCldTSer.Dates.Value(i - 1), ldate)
      End If
      Call RadClc(aLatDeg, CldCov(i), ldate(1), ldate(2), SolRad(i))
    Next i
    Array.Copy(SolRad, 1, lCmpTs.Values, 1, lCmpTs.numValues)

    Return lCmpTs

  End Function

  Public Function CmpJen(ByVal aTMinTS As atcTimeseries, ByVal aTMaxTS As atcTimeseries, ByVal aSRadTS As atcTimeseries, ByVal aSource As atcDataSource, ByVal aDegF As Boolean, ByVal aCTX As Double, ByVal aCTS() As Double) As atcTimeseries
    'compute JENSEN-HAISE - PET
    'aTMinTS/aTMaxTS - min/max temp timeseries
    'aSRadTS - solar radiation timeseries
    'aCTS    - monthly variable coefficients
    'aCTX    - constant coefficient
    'aDegF   - temperature in Fahrenheit (True) or Celsius (False)

    Dim i As Integer
    Dim lRetCod As Integer
    Dim lDate(5) As Integer
    Dim lAirTmp(aTMinTS.numValues) As Double
    Dim lPanEvp(aTMinTS.numValues) As Double
    Dim lCmpTs As New atcTimeseries(aSource)
    Dim tsfil(3) As Double
    Dim lPoint As Boolean = aTMinTS.Attributes.GetValue("point", False)

    CopyBaseAttributes(aTMinTS, lCmpTs)
    lCmpTs.Attributes.SetValue("Constituent", "DPET")
    lCmpTs.Attributes.SetValue("TSTYPE", "DPET")
    lCmpTs.Attributes.SetValue("Scenario", "COMPUTED")
    lCmpTs.Attributes.SetValue("Description", "Daily Potential ET (in) computed using Jensen algorithm")
    lCmpTs.Attributes.AddHistory("Daily Potential ET using Jensen - inputs: TMIN, TMAX, SRAD, Degrees F, Constant Coefficient, Monthly Coefficient")
    lCmpTs.Attributes.Add("TMIN", aTMinTS.ToString)
    lCmpTs.Attributes.Add("TMAX", aTMaxTS.ToString)
    lCmpTs.Attributes.Add("SRAD", aSRadTS.ToString)
    lCmpTs.Attributes.Add("Degrees F", aDegF)
    lCmpTs.Attributes.Add("Constant Coefficient", aCTX)
    Dim ls As String = "("
    For i = 1 To 12
      ls &= aCTS(i) & ", "
    Next
    ls = Left(ls, Len(ls) - 2) & ")"
    lCmpTs.Attributes.Add("Monthly Coefficients", ls)
    lCmpTs.Dates = aTMinTS.Dates
    lCmpTs.numValues = aTMinTS.numValues

    tsfil(1) = aTMinTS.Attributes.GetValue("TSFILL", -999)
    tsfil(2) = aTMaxTS.Attributes.GetValue("TSFILL", -999)
    tsfil(3) = aSRadTS.Attributes.GetValue("TSFILL", -999)

    For i = 1 To lCmpTs.numValues
      If Math.Abs(aTMinTS.Value(i) - tsfil(1)) < 0.000001 Or _
         Math.Abs(aTMaxTS.Value(i) - tsfil(2)) < 0.000001 Or _
         Math.Abs(aSRadTS.Value(i) - tsfil(3)) < 0.000001 Then
        'missing data
        lPanEvp(i) = tsfil(1)
      Else 'compute pet
        lAirTmp(i) = (aTMinTS.Value(i) + aTMaxTS.Value(i)) / 2
        If lPoint Then
          Call J2Date(lCmpTs.Dates.Value(i), lDate)
        Else
          Call J2Date(lCmpTs.Dates.Value(i - 1), lDate)
        End If
        Call Jensen(lDate(1), aCTS, lAirTmp(i), aDegF, aCTX, aSRadTS.Value(i), lPanEvp(i), lRetCod)
      End If
    Next i
    Array.Copy(lPanEvp, 1, lCmpTs.Values, 1, lCmpTs.numValues)
    Return lCmpTs

  End Function

  Public Function CmpHam(ByVal aTMinTS As atcTimeseries, ByVal aTMaxTS As atcTimeseries, ByVal aSource As atcDataSource, ByVal aDegF As Boolean, ByVal aLatDeg As Double, ByVal aCTS() As Double) As atcTimeseries
    'compute HAMON - PET
    'aTminTS/aTMaxTS - min/max temp timeseries
    'aDegF   - Temperature in Degrees F (True) or C (False)
    'aLatDeg - latitude, in degrees
    'aCTS    - monthly variable coefficients

    Dim i As Integer
    Dim lRetCod As Integer
    Dim ldate(5) As Integer
    Dim lAirTmp(aTMinTS.numValues) As Double
    Dim lPanEvp(aTMinTS.numValues) As Double
    Dim tsfil(2) As Double
    Dim lCmpTs As New atcTimeseries(aSource)
    Dim lPoint As Boolean = aTMinTS.Attributes.GetValue("point", False)

    CopyBaseAttributes(aTMinTS, lCmpTs)
    lCmpTs.Attributes.SetValue("Constituent", "DPET")
    lCmpTs.Attributes.SetValue("TSTYPE", "DPET")
    lCmpTs.Attributes.SetValue("Scenario", "COMPUTED")
    lCmpTs.Attributes.SetValue("Description", "Daily Potential ET (in) computed using Hamon algorithm")
    lCmpTs.Attributes.AddHistory("Computed Daily Potential ET using Hamon - inputs: TMIN, TMAX, Degrees F, Latitude, Monthly Coefficients")
    lCmpTs.Attributes.Add("TMIN", aTMinTS.ToString)
    lCmpTs.Attributes.Add("TMAX", aTMaxTS.ToString)
    lCmpTs.Attributes.Add("Degrees F", aDegF)
    lCmpTs.Attributes.Add("Latitude", aLatDeg)
    Dim ls As String = "("
    For i = 1 To 12
      ls &= aCTS(i) & ", "
    Next
    ls = Left(ls, Len(ls) - 2) & ")"
    lCmpTs.Attributes.Add("Monthly Coefficients", ls)
    lCmpTs.Dates = aTMinTS.Dates
    lCmpTs.numValues = aTMinTS.numValues

    'get fill value for input dsns
    tsfil(1) = aTMinTS.Attributes.GetValue("TSFILL", -999)
    tsfil(2) = aTMaxTS.Attributes.GetValue("TSFILL", -999)

    For i = 1 To lCmpTs.numValues
      If Math.Abs(aTMinTS.Value(i) - tsfil(1)) < 0.000001 Or _
         Math.Abs(aTMaxTS.Value(i) - tsfil(2)) < 0.000001 Then
        'missing data
        lPanEvp(i) = tsfil(1)
      Else 'compute pet
        lAirTmp(i) = (aTMinTS.Value(i) + aTMaxTS.Value(i)) / 2
        If lPoint Then
          Call J2Date(lCmpTs.Dates.Value(i), ldate)
        Else
          Call J2Date(lCmpTs.Dates.Value(i - 1), ldate)
        End If
        Call Hamon(ldate(1), ldate(2), aCTS, aLatDeg, lAirTmp(i), aDegF, lPanEvp(i), lRetCod)
      End If
    Next i
    Array.Copy(lPanEvp, 1, lCmpTs.Values, 1, lCmpTs.numValues)
    Return lCmpTs

  End Function

  'Public Function CmpPen(ByRef InTs As Collection) As atcData.ATCclsTserData
  '  'compute PENMAN - PET
  '  'InTS - input timeseries (1/2 - Min/Max Temp,
  '  '3 - Dewpoint Temp, 4 - Wind Movement, 5 - Solar Radiation)

  '  Dim j, i, lret As Integer
  '  Dim PanEvp() As Single
  '  Dim lCmpTs As atcData.ATCclsTserData
  '  Dim tsfil(5) As Single

  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(InTs.Item(1), atcData.ATCTimeUnit.TUDay, 1, 1, lCmpTs)

  '  For i = 1 To InTs.Count()
  '    'get fill value for input dsn
  '    'UPGRADE_WARNING: Couldn't resolve default property of object InTs().AttribNumeric. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    tsfil(i) = InTs.Item(i).AttribNumeric("TSFILL", -999)
  '  Next i

  '  ReDim PanEvp(lCmpTs.dates.Summary.NVALS)
  '  For i = 1 To lCmpTs.dates.Summary.NVALS
  '    'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    If System.Math.Abs(InTs.Item(1).Value(i) - tsfil(1)) < 0.000001 Or System.Math.Abs(InTs.Item(2).Value(i) - tsfil(2)) < 0.000001 Or System.Math.Abs(InTs.Item(3).Value(i) - tsfil(3)) < 0.000001 Or System.Math.Abs(InTs.Item(4).Value(i) - tsfil(4)) < 0.000001 Or System.Math.Abs(InTs.Item(5).Value(i) - tsfil(5)) < 0.000001 Then
  '      'missing data
  '      PanEvp(i) = tsfil(1)
  '    Else 'compute pet
  '      'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      Call PNEVAP(InTs.Item(1).Value(i), InTs.Item(2).Value(i), InTs.Item(3).Value(i), InTs.Item(4).Value(i), InTs.Item(5).Value(i), PanEvp(i))
  '    End If
  '  Next i
  '  lCmpTs.Values = VB6.CopyArray(PanEvp)
  '  CmpPen = lCmpTs

  'End Function

  'Public Function CmpCld(ByRef PctSun As Collection) As atcData.ATCclsTserData
  '  'compute %cloud cover from %sunshine

  '  Dim i, j As Integer
  '  Dim SSSum, SSDiv As Single
  '  Dim CldCov() As Single
  '  Dim SunVals() As Single
  '  Dim lCmpTs As atcData.ATCclsTserData

  '  'UPGRADE_WARNING: Couldn't resolve default property of object PctSun(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(PctSun.Item(1), atcData.ATCTimeUnit.TUDay, 1, 1, lCmpTs)

  '  'UPGRADE_WARNING: Couldn't resolve default property of object PctSun().Values. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  SunVals = PctSun.Item(1).Values
  '  'see if sunshine values are percent or fraction
  '  i = 1
  '  j = 0
  '  'UPGRADE_WARNING: Couldn't resolve default property of object PctSun(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Do While j < 5 And i <= PctSun.Item(1).dates.Summary.NVALS
  '    If SunVals(i) > 0 Then
  '      SSSum = SSSum + SunVals(i)
  '      j = j + 1
  '    End If
  '    i = i + 1
  '  Loop
  '  'see what the sum of these values is
  '  If SSSum > j Then 'must be percentages
  '    SSDiv = 100
  '  Else 'must be fractions
  '    SSDiv = 1
  '  End If
  '  ReDim CldCov(lCmpTs.dates.Summary.NVALS)
  '  For i = 1 To lCmpTs.dates.Summary.NVALS
  '    If SunVals(i) < 0.0# Then SunVals(i) = 0.0#
  '    CldCov(i) = 10 * ((1 - SunVals(i) / SSDiv) ^ (3 / 5))
  '    If CldCov(i) < 0.0# Then CldCov(i) = 0.0#
  '  Next i
  '  lCmpTs.Values = VB6.CopyArray(CldCov)
  '  CmpCld = lCmpTs

  'End Function

  'Public Function CmpWnd(ByRef WndSpd As Collection) As atcData.ATCclsTserData
  '  'compute daily total wind travel (mi) from
  '  'average daily wind speed (mph)

  '  Dim i As Integer
  '  Dim dtold(5) As Integer
  '  Dim dtnew(5) As Integer
  '  Dim TotWnd() As Single
  '  Dim lCmpTs As atcData.ATCclsTserData

  '  'UPGRADE_WARNING: Couldn't resolve default property of object WndSpd(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(WndSpd.Item(1), atcData.ATCTimeUnit.TUDay, 1, 1, lCmpTs)

  '  ReDim TotWnd(lCmpTs.dates.Summary.NVALS)
  '  For i = 1 To lCmpTs.dates.Summary.NVALS
  '    'UPGRADE_WARNING: Couldn't resolve default property of object WndSpd().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    If WndSpd.Item(1).Value(i) <= 0.0# Then 'not valid wind speed value
  '      TotWnd(i) = 0
  '    Else
  '      'UPGRADE_WARNING: Couldn't resolve default property of object WndSpd().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      TotWnd(i) = 24 * WndSpd.Item(1).Value(i)
  '    End If
  '  Next i
  '  lCmpTs.Values = VB6.CopyArray(TotWnd)
  '  CmpWnd = lCmpTs

  'End Function

  'Public Function DisTemp(ByRef MnMxTmp As Collection, ByRef ObsTime As Integer, ByRef SJDt As Double, ByRef EJDt As Double) As atcData.ATCclsTserData
  '  'Disaggregate daily min/max temperature to hourly temperature
  '  'MnMxTmp - input daily min/max temp values, since disagg
  '  '          method uses either previous or ensuing days values,
  '  '          these arrays contain two more days of values
  '  '          than the period being disaggregated
  '  '  For Min Temp (index 1 of collection), the two extra
  '  '    values are at the end
  '  '  For Max Temp (index 2 of collection), there is one extra
  '  '    value at each end of the data set
  '  'SJDt - actual start date for output time series
  '  'EJDt - actual end date for output time series

  '  Dim HrPos, ioff, j, i, opt, joff, lnval As Integer
  '  Dim dtnew(5) As Integer
  '  'UPGRADE_WARNING: Lower bound of array HrVals was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
  '  Dim HrVals(24) As Single
  '  Dim HRTemp() As Single
  '  Dim tsfil(3) As Single
  '  Dim MinTmp() As Single
  '  Dim MaxTmp() As Single
  '  Dim lDisTs As atcData.ATCclsTserData
  '  Dim lDateSum As atcData.ATTimSerDateSummary

  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(MnMxTmp.Item(1), atcData.ATCTimeUnit.TUHour, 1, 24, lDisTs)
  '  'UPGRADE_WARNING: Couldn't resolve default property of object lDateSum. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  lDateSum = lDisTs.dates.Summary
  '  'since lDisTs was built based on min temp TSer (which contains
  '  '2 extra values), need to adjust number of values and end date
  '  lDateSum.NVALS = 24 * (EJDt - SJDt)
  '  lDateSum.EJDay = EJDt
  '  lDisTs.dates.Summary = lDateSum

  '  For i = 1 To MnMxTmp.Count() 'get fill value for input dsns
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().AttribNumeric. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    tsfil(i) = MnMxTmp.Item(i).AttribNumeric("TSFILL", -999)
  '  Next i

  '  If ObsTime > 0 And ObsTime <= 6 Then
  '    'option 1 is early morning observations,
  '    'use max and min temp from previous calendar day
  '    opt = 1
  '  ElseIf ObsTime > 6 And ObsTime <= 16 Then
  '    'option 2 is mid day observations,
  '    'use max temp from previous day and min temp of current day
  '    opt = 2
  '  ElseIf ObsTime > 16 And ObsTime <= 24 Then
  '    'option 3 is evening observations,
  '    'use max and min temp from current day
  '    opt = 3
  '  End If

  '  ReDim HRTemp(lDisTs.dates.Summary.NVALS)
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  ReDim MinTmp(MnMxTmp.Item(1).dates.Summary.NVALS + 2)
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  ReDim MaxTmp(MnMxTmp.Item(2).dates.Summary.NVALS + 1)

  '  'get max temp data
  '  joff = 0
  '  If opt = 3 Then 'back up one day (try to use 1st array element)
  '    ioff = 0
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    If MnMxTmp.Item(2).dates.Summary.SJDay >= SJDt Then
  '      'no data available prior to start date
  '      joff = 1
  '      'fill first max value with first available max value
  '      'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      MaxTmp(1) = MnMxTmp.Item(2).Value(1)
  '    End If
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  ElseIf MnMxTmp.Item(2).dates.Summary.SJDay < SJDt Then
  '    '1st element preceeds start date, don't need it
  '    ioff = 1
  '  Else '1st element is at start date, need it
  '    ioff = 0
  '  End If
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  For i = 1 To MnMxTmp.Item(2).dates.Summary.NVALS - ioff
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    MaxTmp(i + joff) = MnMxTmp.Item(2).Value(i + ioff)
  '  Next i
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  If opt <> 3 And MnMxTmp.Item(2).dates.Summary.EJDay <= EJDt Then
  '    'extra value needed, but not available, fill with previous
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(2).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    MaxTmp(MnMxTmp.Item(2).dates.Summary.NVALS + 1) = MaxTmp(MnMxTmp.Item(2).dates.Summary.NVALS)
  '  End If
  '  '  'check end points
  '  '  If opt = 3 And Abs(MaxTmp(1) - tsfil(2)) < 0.000001 Then
  '  '    'first value absent - fill with following day
  '  '    MaxTmp(1) = MaxTmp(2)
  '  '  End If
  '  '  If opt <> 3 And Abs(MaxTmp(MnMxTmp(2).dates.summary.NVals - 1) - tsfil(2)) < 0.000001 Then
  '  '    'last value was absent - fill with previous day
  '  '    MaxTmp(MnMxTmp(2).dates.summary.NVals - 1) = MaxTmp(MnMxTmp(2).dates.summary.NVals - 2)
  '  '  End If

  '  'get min temp data
  '  If opt = 1 Then 'move up one day for min temp values
  '    ioff = 1
  '  Else
  '    ioff = 0
  '  End If
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  For i = 1 To MnMxTmp.Item(1).dates.Summary.NVALS - ioff
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    MinTmp(i) = MnMxTmp.Item(1).Value(i + ioff)
  '  Next i
  '  'check end points
  '  'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  If MnMxTmp.Item(1).dates.Summary.EJDay <= EJDt Then
  '    If opt = 1 Then 'need 2 extra values at end, fill with last good one
  '      'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      MinTmp(MnMxTmp.Item(1).dates.Summary.NVALS + 1) = MinTmp(MnMxTmp.Item(1).dates.Summary.NVALS - 1)
  '    End If
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    'UPGRADE_WARNING: Couldn't resolve default property of object MnMxTmp().dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    MinTmp(MnMxTmp.Item(1).dates.Summary.NVALS + 1 - ioff) = MinTmp(MnMxTmp.Item(1).dates.Summary.NVALS - ioff)
  '  End If
  '  '  If opt = 1 And Abs(MinTmp(MnMxTmp(1).dates.summary.NVals - 2) - tsfil(0)) < 0.000001 Then
  '  '    'next to last value was absent - fill with previous day
  '  '    MinTmp(MnMxTmp(1).dates.summary.NVals - 2) = MinTmp(MnMxTmp(1).dates.summary.NVals - 3)
  '  '  End If
  '  '  If Abs(MinTmp(MnMxTmp(1).dates.summary.NVals - 1) - tsfil(0)) < 0.000001 Then
  '  '    'last value was absent - fill with previous day
  '  '    MinTmp(MnMxTmp(1).dates.summary.NVals - 1) = MinTmp(MnMxTmp(1).dates.summary.NVals - 2)
  '  '  End If

  '  'get TSFILL value from output DSN
  '  tsfil(3) = lDisTs.AttribNumeric("TSFILL", -999)

  '  HrPos = 0
  '  For i = 1 To (EJDt - SJDt)
  '    If (System.Math.Abs(MaxTmp(i) - tsfil(2)) > 0.000001) Or (System.Math.Abs(MinTmp(i) - tsfil(1)) > 0.000001) Then
  '      'value is not missing, so distribute
  '      Call DISTRB(MaxTmp(i), MinTmp(i), MaxTmp(i + 1), MinTmp(i + 1), HrVals)
  '      For j = 1 To 24
  '        HRTemp(HrPos + j) = HrVals(j)
  '      Next j
  '    Else 'value is missing, so leave hourlies missing
  '      For j = 1 To 24
  '        HRTemp(HrPos + j) = tsfil(2)
  '      Next j
  '    End If
  '    HrPos = HrPos + 24
  '  Next i
  '  lDisTs.Values = VB6.CopyArray(HRTemp)
  '  DisTemp = lDisTs

  'End Function

  'Public Function DisSolPet(ByRef InTs As Collection, ByRef DisOpt As Integer, ByRef LatDeg As Single) As atcData.ATCclsTserData
  '  'disaggregate daily SOLAR or PET to hourly
  '  'InTs - input timeseries to be disaggregated
  '  'DisOpt = 1 does Solar, DisOpt = 2 does PET
  '  'LatDeg - latitude, in degrees

  '  Dim HrPos, i, j, retcod As Integer
  '  Dim dtnew(5) As Integer
  '  Dim dtold(5) As Integer
  '  'UPGRADE_WARNING: Lower bound of array HrVals was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
  '  Dim lDisTs As atcData.ATCclsTserData
  '  Dim OutTs() As Single
  '  Dim HrVals(24) As Single

  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(InTs.Item(1), atcData.ATCTimeUnit.TUHour, 1, 24, lDisTs)

  '  ReDim OutTs(lDisTs.dates.Summary.NVALS)
  '  Call J2Date(lDisTs.dates.Summary.SJDay, dtold)
  '  HrPos = 0
  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  For i = 1 To InTs.Item(1).dates.Summary.NVALS
  '    If DisOpt = 1 Then 'solar
  '      'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      Call RADDST(LatDeg, dtold(1), dtold(2), InTs.Item(1).Value(i), HrVals, retcod)
  '    ElseIf DisOpt = 2 Then  'pet
  '      'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      Call PETDST(LatDeg, dtold(1), dtold(2), InTs.Item(1).Value(i), HrVals, retcod)
  '    End If
  '    For j = 1 To 24
  '      OutTs(HrPos + j) = HrVals(j)
  '    Next j
  '    'UPGRADE_WARNING: Couldn't resolve default property of object InTs(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    Call F90_TIMADD(dtold(0), InTs.Item(1).dates.Summary.Tu, InTs.Item(1).dates.Summary.ts, 1, dtnew(0))
  '    Call CopyI(6, dtnew, dtold)
  '    'increment to next 24 hour period
  '    HrPos = HrPos + 24
  '  Next i
  '  lDisTs.Values = VB6.CopyArray(OutTs)
  '  DisSolPet = lDisTs

  'End Function

  'Public Function DisWnd(ByRef InTs As Collection, ByRef DCurve() As Single) As atcData.ATCclsTserData
  '  'Disaggregate daily wind to hourly
  '  'InTs - input daily wind timeseries
  '  'DCurve - hourly diurnal curve for wind disaggregation

  '  Dim k, i, j, lnval As Integer
  '  'UPGRADE_WARNING: Lower bound of array HrVals was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
  '  Dim lDisTs As atcData.ATCclsTserData
  '  Dim OutTs() As Single
  '  Dim HrVals(24) As Single

  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(InTs.Item(1), atcData.ATCTimeUnit.TUHour, 1, 24, lDisTs)

  '  ReDim OutTs(lDisTs.dates.Summary.NVALS)
  '  k = 0
  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  For i = 1 To InTs.Item(1).dates.Summary.NVALS
  '    For j = 1 To 24
  '      'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      OutTs(k + j) = InTs.Item(1).Value(i) * DCurve(j)
  '    Next j
  '    'increment to next 24 hour period
  '    k = k + 24
  '  Next i
  '  lDisTs.Values = VB6.CopyArray(OutTs)
  '  DisWnd = lDisTs

  'End Function

  'Public Function DisDwpnt(ByRef InTs As Collection) As atcData.ATCclsTserData
  '  'Disaggregate dewpoint temperature from daily to hourly
  '  'assuming daily average is constant for 24 hours

  '  Dim k, i, j, lnval As Integer
  '  Dim lDisTs As atcData.ATCclsTserData
  '  Dim OutTs() As Single

  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  Call InitCmpTs(InTs.Item(1), atcData.ATCTimeUnit.TUHour, 1, 24, lDisTs)
  '  ReDim OutTs(lDisTs.dates.Summary.NVALS)

  '  k = 1
  '  'UPGRADE_WARNING: Couldn't resolve default property of object InTs(1).dates. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '  For i = 1 To InTs.Item(1).dates.Summary.NVALS
  '    For j = 0 To 23
  '      'UPGRADE_WARNING: Couldn't resolve default property of object InTs().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      OutTs(k + j) = InTs.Item(1).Value(i)
  '    Next j
  '    'increment to next 24 hour period
  '    k = k + 24
  '  Next i
  '  lDisTs.Values = VB6.CopyArray(OutTs)
  '  DisDwpnt = lDisTs

  'End Function
  'Public Sub InitCmpTs(ByRef InTs As atcData.ATCclsTserData, ByRef NTu As Integer, ByRef NTs As Integer, ByRef NewIntvls As Integer, ByRef NewTs As atcData.ATCclsTserData)
  '  'InTs - input TSer upon which new TSer is based
  '  'NTu/NTs - new TSer's time units and time step
  '  'NewIntvls - number of new time intervals between InTs and NewTs
  '  '           (e.g. 24 if going from daily to hourly,
  '  '                 15 if going from hourly to 15-minute)
  '  'NewTs - new TSer being built

  '  Dim lTserSum As atcData.ATTimSerDateSummary

  '  NewTs = New atcData.ATCclsTserData
  '  NewTs.dates = New atcData.ATCclsTserDate
  '  With lTserSum
  '    .CIntvl = True
  '    .Intvl = InTs.dates.Summary.Intvl / NewIntvls
  '    .NVALS = InTs.dates.Summary.NVALS * NewIntvls
  '    .SJDay = InTs.dates.Summary.SJDay
  '    .EJDay = InTs.dates.Summary.EJDay
  '    .ts = NTs
  '    .Tu = NTu
  '  End With
  '  NewTs.dates.Summary = lTserSum
  '  'Set NewTs.File = TserMemory
  '  'TserMemory.addtimser NewTs

  'End Sub
  'Public Sub DISTRB(ByRef PreMax As Single, ByRef CurMin As Single, ByRef CurMax As Single, ByRef NxtMin As Single, ByRef HRTemp() As Single)

  '  'Distribute daily max-min temperatures to hourly values

  '  'PREMAX - previous max temperature
  '  'CURMIN - current min temperature
  '  'CURMAX - current max temperature
  '  'NXTMIN - next min temperature
  '  'HRTEMP - array of hourly values

  '  Dim Dif2, Dif1, Dif3 As Single

  '  Dif1 = PreMax - CurMin
  '  Dif2 = CurMin - CurMax
  '  Dif3 = CurMax - NxtMin

  '  HRTemp(1) = CurMin + Dif1 * 0.15
  '  HRTemp(2) = CurMin + Dif1 * 0.1
  '  HRTemp(3) = CurMin + Dif1 * 0.06
  '  HRTemp(4) = CurMin + Dif1 * 0.03
  '  HRTemp(5) = CurMin + Dif1 * 0.01
  '  HRTemp(6) = CurMin
  '  HRTemp(7) = CurMin - Dif2 * 0.16
  '  HRTemp(8) = CurMin - Dif2 * 0.31
  '  HRTemp(9) = CurMin - Dif2 * 0.45
  '  HRTemp(10) = CurMin - Dif2 * 0.59
  '  HRTemp(11) = CurMin - Dif2 * 0.71
  '  HRTemp(12) = CurMin - Dif2 * 0.81
  '  HRTemp(13) = CurMin - Dif2 * 0.89
  '  HRTemp(14) = CurMin - Dif2 * 0.95
  '  HRTemp(15) = CurMin - Dif2 * 0.99
  '  HRTemp(16) = CurMax
  '  HRTemp(17) = NxtMin + Dif3 * 0.89
  '  HRTemp(18) = NxtMin + Dif3 * 0.78
  '  HRTemp(19) = NxtMin + Dif3 * 0.67
  '  HRTemp(20) = NxtMin + Dif3 * 0.57
  '  HRTemp(21) = NxtMin + Dif3 * 0.47
  '  HRTemp(22) = NxtMin + Dif3 * 0.38
  '  HRTemp(23) = NxtMin + Dif3 * 0.29
  '  HRTemp(24) = NxtMin + Dif3 * 0.22

  'End Sub

  ''UPGRADE_NOTE: Day was upgraded to Day_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
  ''UPGRADE_NOTE: Month was upgraded to Month_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
  'Private Sub RADDST(ByRef LatDeg As Single, ByRef Month_Renamed As Integer, ByRef Day_Renamed As Integer, ByRef DayRad As Single, ByRef HrRad() As Single, ByRef retcod As Integer)
  '  'Distributes daily solar radiation to hourly
  '  'values, based on a method used in HSP (Hydrocomp, 1976).
  '  'It uses the latitude, month, day, and daily radiation.

  '  'LatDeg - latitude(degrees)
  '  'MONTH  - month of the year (1-12)
  '  'DAY    - day of the month (1-31)
  '  'DAYRAD - input daily radiation (langleys)
  '  'HRRAD  - output array of hourly radiation (langleys)
  '  'RETCOD - return code (0 = ok, -1 = bad latitude)

  '  Dim IK As Integer
  '  Dim TR3, TRise, CRAD, DTR2, Delt, CS, AD, JulDay, RK, LatRdn, Phi, SS, X2, SunR, DTR4, SL, TR2, TR4 As Single

  '  'julian date
  '  JulDay = 30.5 * (Month_Renamed - 1) + Day_Renamed

  '  'check latitude
  '  If LatDeg < -66.5 Or LatDeg > 66.5 Then 'invalid latitude, return
  '    retcod = -1
  '  Else 'latitude ok
  '    'convert to radians
  '    LatRdn = LatDeg * 0.0174582

  '    Phi = LatRdn
  '    AD = 0.40928 * System.Math.Cos(0.0172141 * (172.0# - JulDay))
  '    SS = System.Math.Sin(Phi) * System.Math.Sin(AD)
  '    CS = System.Math.Cos(Phi) * System.Math.Cos(AD)
  '    X2 = -SS / CS
  '    Delt = 7.6394 * (1.5708 - System.Math.Atan(X2 / System.Math.Sqrt(1.0# - X2 ^ 2)))
  '    SunR = 12.0# - Delt / 2.0#

  '    'develop hourly distribution given sunrise,
  '    'sunset and length of day (DELT)
  '    DTR2 = Delt / 2.0#
  '    DTR4 = Delt / 4.0#
  '    CRAD = 0.66666667 / DTR2
  '    SL = CRAD / DTR4
  '    TRise = SunR
  '    TR2 = TRise + DTR4
  '    TR3 = TR2 + DTR2
  '    TR4 = TR3 + DTR4

  '    'hourly loop
  '    For IK = 1 To 24
  '      RK = IK
  '      If RK > TRise Then
  '        If RK > TR2 Then
  '          If RK > TR3 Then
  '            If RK > TR4 Then
  '              HrRad(IK) = 0.0#
  '            Else
  '              HrRad(IK) = (CRAD - (RK - TR3) * SL) * DayRad
  '            End If
  '          Else
  '            HrRad(IK) = CRAD * DayRad
  '          End If
  '        Else
  '          HrRad(IK) = (RK - TRise) * SL * DayRad
  '        End If
  '      Else
  '        HrRad(IK) = 0.0#
  '      End If
  '    Next IK
  '    retcod = 0
  '  End If

  'End Sub

  ''UPGRADE_NOTE: Day was upgraded to Day_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
  ''UPGRADE_NOTE: Month was upgraded to Month_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
  'Public Sub PETDST(ByRef LatDeg As Single, ByRef Month_Renamed As Integer, ByRef Day_Renamed As Integer, ByRef DayPet As Single, ByRef HrPet() As Single, ByRef retcod As Integer)

  '  'Distributes daily PET to hourly values,
  '  'based on a method used to disaggregate solar radiation
  '  'in HSP (Hydrocomp, 1976) using latitude, month, day,
  '  'and daily PET.

  '  'LatDeg - latitude(degrees)
  '  'MONTH  - month of the year (1-12)
  '  'DAY    - day of the month (1-31)
  '  'DAYPET - input daily PET (inches)
  '  'HRPET  - output array of hourly PET (inches)
  '  'RETCOD - return code (0 = ok, -1 = bad latitude)

  '  Dim IK As Integer
  '  Dim TR3, TRise, CRAD, DTR2, Delt, CS, AD, JulDay, RK, LatRdn, Phi, SS, X2, SunR, DTR4, SL, TR2, TR4 As Single
  '  Dim CURVE(24) As Single

  '  'julian date
  '  JulDay = 30.5 * (Month_Renamed - 1) + Day_Renamed

  '  'check latitude
  '  If LatDeg < -66.5 Or LatDeg > 66.5 Then 'invalid latitude, return
  '    retcod = -1
  '  Else 'latitude ok
  '    'convert to radians
  '    LatRdn = LatDeg * 0.0174582

  '    Phi = LatRdn
  '    AD = 0.40928 * System.Math.Cos(0.0172141 * (172.0# - JulDay))
  '    SS = System.Math.Sin(Phi) * System.Math.Sin(AD)
  '    CS = System.Math.Cos(Phi) * System.Math.Cos(AD)
  '    X2 = -SS / CS
  '    Delt = 7.6394 * (1.5708 - System.Math.Atan(X2 / System.Math.Sqrt(1.0# - X2 ^ 2)))
  '    SunR = 12.0# - Delt / 2.0#

  '    'develop hourly distribution given sunrise,
  '    'sunset and length of day (DELT)
  '    DTR2 = Delt / 2.0#
  '    DTR4 = Delt / 4.0#
  '    CRAD = 0.66666667 / DTR2
  '    SL = CRAD / DTR4
  '    TRise = SunR
  '    TR2 = TRise + DTR4
  '    TR3 = TR2 + DTR2
  '    TR4 = TR3 + DTR4

  '    'calculate hourly distribution curve
  '    For IK = 1 To 24
  '      RK = IK
  '      If RK > TRise Then
  '        If RK > TR2 Then
  '          If RK > TR3 Then
  '            If RK > TR4 Then
  '              CURVE(IK) = 0.0#
  '              HrPet(IK) = CURVE(IK)
  '            Else
  '              CURVE(IK) = (CRAD - (RK - TR3) * SL)
  '              HrPet(IK) = CURVE(IK) * DayPet
  '            End If
  '          Else
  '            CURVE(IK) = CRAD
  '            HrPet(IK) = CURVE(IK) * DayPet
  '          End If
  '        Else
  '          CURVE(IK) = (RK - TRise) * SL
  '          HrPet(IK) = CURVE(IK) * DayPet
  '        End If
  '      Else
  '        CURVE(IK) = 0.0#
  '        HrPet(IK) = CURVE(IK)
  '      End If
  '    Next IK
  '    retcod = 0
  '  End If

  'End Sub

  Public Sub RadClc(ByRef aDegLat As Double, ByRef aCloud As Double, ByRef aMon As Integer, ByRef aDay As Integer, ByRef aDayRad As Double)

    'This routine computes the total daily solar radiation based on
    'the HSPII (Hydrocomp, 1978) RADIATION procedure, which is based
    'on empirical curves of radiation as a function of latitude
    '(Hamon et al, 1954, Monthly Weather Review 82(6):141-146.

    Dim i, ILat, ii, j As Integer
    Dim inifg As Short
    Dim Lat3, Lat1, Lat2, Lat4 As Double
    Dim A1, b, Exp2, Exp1, a, A0, A2 As Double
    Dim b2, A3, b1, Frac As Double
    Dim lXLax(51, 6) As Double
    Dim lc(10, 12) As Double
    Dim SS, x As Double
    Dim lX1(12) As Double
    Dim Y100, YRD, y As Double

    If inifg = 0 Then 'init constant arrays
      Call InitRadclcConsts(lX1, lc, lXLax)
      inifg = 1
    End If

    'integer part of latitude
    ILat = Int(aDegLat)

    'fractional part of latitude
    Frac = aDegLat - CSng(ILat)
    If Frac <= 0.0001 Then Frac = 0.0#

    A0 = XLax(ILat, 1) + Frac * (XLax(ILat + 1, 1) - XLax(ILat, 1))
    A1 = XLax(ILat, 2) + Frac * (XLax(ILat + 1, 2) - XLax(ILat, 2))
    A2 = XLax(ILat, 3) + Frac * (XLax(ILat + 1, 3) - XLax(ILat, 3))
    A3 = XLax(ILat, 4) + Frac * (XLax(ILat + 1, 4) - XLax(ILat, 4))
    b1 = XLax(ILat, 5) + Frac * (XLax(ILat + 1, 5) - XLax(ILat, 5))
    b2 = XLax(ILat, 6) + Frac * (XLax(ILat + 1, 6) - XLax(ILat, 6))
    b = aDegLat - 44.0#
    a = aDegLat - 25.0#
    Exp1 = 0.7575 - 0.0018 * a
    Exp2 = 0.725 + 0.00288 * b
    Lat1 = 2.139 + 0.0423 * a
    Lat2 = 30.0# - 0.667 * a
    Lat3 = 2.9 - 0.0629 * b
    Lat4 = 18.0# + 0.833 * b

    'Percent sunshine
    SS = 100.0# * (1.0# - (aCloud / 10.0#) ^ (5.0# / 3.0#))
    If SS < 0.0# Then
      'can't have SS being negative
      SS = 0.0#
    End If

    x = X1(aMon) + aDay
    'convert to radians
    x = x * 2.0# * 3.14159 / 360.0#

    Y100 = A0 + A1 * System.Math.Cos(x) + A2 * System.Math.Cos(2 * x) + A3 * System.Math.Cos(3 * x) + b1 * System.Math.Sin(x) + b2 * System.Math.Sin(2 * x)

    ii = CEIL((SS + 10.0#) / 10.0#)

    If aDegLat > 43.0# Then
      YRD = Lat3 * SS ^ Exp2 + Lat4
    Else
      YRD = Lat1 * SS ^ Exp1 + Lat2
    End If

    If ii < 11 Then
      YRD = YRD + c(ii, aMon)
    End If

    If YRD >= 100.0# Then
      aDayRad = Y100
    Else
      aDayRad = Y100 * YRD / 100.0#
    End If

  End Sub

  Public Function CEIL(ByRef x As Double) As Integer

    'This routine returns the next higher integer
    'from the input double precision argument X.

    If (x - CDbl(Fix(x))) <= 0.00001 Then
      CEIL = Fix(x)
    Else
      CEIL = Fix(x) + 1
    End If

  End Function
  Public Sub Jensen(ByVal aMon As Integer, ByVal aCTS() As Double, ByVal aAirTmp As Double, ByVal aDegF As Boolean, ByVal aCTX As Double, ByVal aSolRad As Double, ByRef aPanEvp As Double, ByRef aRetCod As Integer)

    'Generates daily pan evaporation (inches)
    'using a coefficient for the month, the daily average air
    'temperature (F), a coefficient, and solar radiation
    '(langleys/day). The computations are based on the Jensen
    'and Haise (1963) formula.

    'aCTS    - array of monthly coefficients
    'aAirTmp - daily average air temperature (F)
    'aDegF   - temperature in Fahrenheit (True) or Celsius (False)
    'aCTX    - coefficient
    'aSolRad - solar radiation (langleys/day)
    'aPanEvp - daily pan evaporation (inches)
    'aRetCod - return code
    '          0 - operation successful
    '         -1 - operation failed

    Dim lTAVF As Double
    Dim lSRadIn As Double
    Dim lTAVC As Double

    aRetCod = 0

    If aDegF Then 'input is fahrenheit
      lTAVF = aAirTmp
      lTAVC = (aAirTmp - 32.0#) * 5.0# / 9.0#
    Else 'input is celsius
      lTAVC = aAirTmp
      lTAVF = (aAirTmp * (9.0# / 5.0#)) + 32.0#
    End If

    'convert solar radiation from langleys to equivalent inches of water evaporation
    lSRadIn = aSolRad / ((597.3 - 0.57 * lTAVC) * 2.54)

    'compute evaporation using Jensen-Haise (1963) formula
    aPanEvp = aCTS(aMon) * (lTAVF - aCTX) * lSRadIn

    'when the estimated pan evaporation
    'is negative the value is set to zero
    If aPanEvp < 0.0# Then
      aPanEvp = 0.0#
    End If

  End Sub

  Public Sub Hamon(ByVal aMonth As Integer, ByVal aDay As Integer, ByVal aCTS() As Double, ByVal aLatDeg As Double, ByVal aTAVC As Double, ByVal aDegF As Boolean, ByRef PanEvp As Single, ByVal aRetCod As Integer)

    'Generates daily pan evaporation (inches)
    'using a coefficient for the month, the possible hours of
    'sunshine (computed from latitude), and absolute humidity.
    'The computations are based on the Hamon (1961) formula.

    'CTS    - array of monthly coefficients
    'LatDeg - latitude
    'TAVC   - Average daily temperature (C)
    'aDegF  - temperature in Fahrenheit (True) or Celsius (False)
    'PanEvp - daily pan evaporation (inches)
    'RetCod - return code
    '          0 - operation successful
    '         -1 - operation failed

    Dim VDSAT, SUNS, Delt, CS, AD, JulDay, LatRdn, Phi, SS, X2, SunR, DYL, VPSAT As Double

    aRetCod = 0

    'julian date
    JulDay = 30.5 * (aMonth - 1) + aDay

    'check latitude
    If aLatDeg < -66.5 Or aLatDeg > 66.5 Then 'invalid latitude, return
      aRetCod = -1
    Else 'latitude ok,convert to radians
      LatRdn = aLatDeg * 0.0174582
      Phi = LatRdn
      AD = 0.40928 * System.Math.Cos(0.0172141 * (172.0# - JulDay))
      SS = System.Math.Sin(Phi) * System.Math.Sin(AD)
      CS = System.Math.Cos(Phi) * System.Math.Cos(AD)
      X2 = -SS / CS
      Delt = 7.6394 * (1.5708 - System.Math.Atan(X2 / System.Math.Sqrt(1.0# - X2 ^ 2)))
      SunR = 12.0# - Delt / 2.0#
      SUNS = 12.0# + Delt / 2.0#
      DYL = (SUNS - SunR) / 12

      'convert temperature to Centigrade if necessary
      If aDegF Then aTAVC = (aTAVC - 32.0#) * (5.0# / 9.0#)

      'Hamon equation
      VPSAT = 6.108 * System.Math.Exp(17.26939 * aTAVC / (aTAVC + 237.3))
      VDSAT = 216.7 * VPSAT / (aTAVC + 273.3)
      PanEvp = aCTS(aMonth) * DYL * DYL * VDSAT

      'when the estimated pan evaporation is negative
      'the value is set to zero
      If PanEvp < 0.0# Then
        PanEvp = 0.0#
      End If
    End If

  End Sub

  Public Sub PNEVAP(ByRef MinTmp As Single, ByRef MaxTmp As Single, ByRef DewTmp As Single, ByRef WindSp As Single, ByRef SolRad As Single, ByRef PanEvp As Single)

    'Generates daily pan evaporation (inches) using
    'daily minimum air temperature (F), daily maximum air
    'temperature, dewpoint (F), wind movement (miles/day), and solar
    'radiation (langleys/day). The computations are based on the Penman
    '(1948) formula and the method of Kohler, Nordensen, and Fox (1955).

    'MinTmp - daily minimum air temperature (F)
    'MaxTmp - daily maximum air temperature (F)
    'DewTmp - dewpoint(F)
    'WindSp - wind movement (miles/day)
    'SolRad - solar radiation (langleys/day)
    'PanEvp - daily pan evaporation (inches)

    Dim QNDelt, EsMiEa, Delta, EaGama, AirTmp As Double

    'compute average daily air temperature
    AirTmp = (MinTmp + MaxTmp) / 2.0#

    'net radiation exchange * delta
    If SolRad <= 0.0# Then SolRad = 0.00001
    QNDelt = System.Math.Exp((AirTmp - 212.0#) * (0.1024 - 0.01066 * System.Math.Log(SolRad))) - 0.0001

    'Vapor pressure deficit between surface and
    'dewpoint temps(Es-Ea) IN of Hg
    EsMiEa = (6413252.0# * System.Math.Exp(-7482.6 / (AirTmp + 398.36))) - (6413252.0# * System.Math.Exp(-7482.6 / (DewTmp + 398.36)))

    'pan evaporation assuming air temp equals water surface temp.

    'when vapor pressure deficit turns negative it is set equal to zero
    If EsMiEa < 0.0# Then
      EsMiEa = 0.0#
    End If

    'pan evap * GAMMA, GAMMA = 0.0105 inch Hg/F
    EaGama = 0.0105 * (EsMiEa ^ 0.88) * (0.37 + 0.0041 * WindSp)

    'Delta = slope of saturation vapor pressure curve at air temperature
    Delta = 47987800000.0# * System.Math.Exp(-7482.6 / (AirTmp + 398.36)) / ((AirTmp + 398.36) ^ 2)

    'pan evaporation rate in inches per day
    PanEvp = (QNDelt + EaGama) / (Delta + 0.0105)

    'when the estimated pan evaporation is negative
    'the value is set to zero
    If PanEvp < 0.0# Then
      PanEvp = 0.0#
    End If

  End Sub

  Public Sub InitRadclcConsts(ByRef X1() As Double, ByRef ac(,) As Double, ByRef aXLax(,) As Double)

    Dim i, j As Integer


    ac(1, 1) = 4.0#
    ac(2, 1) = 3.0#
    ac(3, 1) = 0.0#
    ac(4, 1) = -2.0#
    ac(5, 1) = -4.0#
    ac(6, 1) = -5.0#
    ac(7, 1) = -5.0#
    ac(8, 1) = -4.0#
    ac(9, 1) = -2.0#
    ac(10, 1) = 0.0#
    ac(1, 2) = 2.0#
    ac(2, 2) = 4.0#
    ac(3, 2) = 3.5
    ac(4, 2) = 2.5
    ac(5, 2) = 0.5
    ac(6, 2) = -1.5
    ac(7, 2) = -3.5
    ac(8, 2) = -4.5
    ac(9, 2) = -4.0#
    ac(10, 2) = -3.5
    ac(1, 3) = -1.5
    ac(2, 3) = 0.0#
    ac(3, 3) = 1.5
    ac(4, 3) = 3.5
    ac(5, 3) = 3.0#
    ac(6, 3) = 2.0#
    ac(7, 3) = 1.0#
    ac(8, 3) = -1.0#
    ac(9, 3) = -3.0#
    ac(10, 3) = -4.0#
    ac(1, 4) = -3.0#
    ac(2, 4) = -3.0#
    ac(3, 4) = -1.0#
    ac(4, 4) = 0.0#
    ac(5, 4) = 1.0#
    ac(6, 4) = 3.0#
    ac(7, 4) = 3.0#
    ac(8, 4) = 2.5
    ac(9, 4) = 1.0#
    ac(10, 4) = -0.5
    ac(1, 5) = -2.0#
    ac(2, 5) = -2.5
    ac(3, 5) = -2.0#
    ac(4, 5) = -2.0#
    ac(5, 5) = -0.5
    ac(6, 5) = 0.5
    ac(7, 5) = 1.5
    ac(8, 5) = 3.0#
    ac(9, 5) = 3.0#
    ac(10, 5) = 3.0#
    ac(1, 6) = 1.0#
    ac(2, 6) = 0.0#
    ac(3, 6) = -1.0#
    ac(4, 6) = -1.0#
    ac(5, 6) = -1.0#
    ac(6, 6) = -1.0#
    ac(7, 6) = 0.0#
    ac(8, 6) = 1.0#
    ac(9, 6) = 2.0#
    ac(10, 6) = 3.0#
    ac(1, 7) = 3.0#
    ac(2, 7) = 2.0#
    ac(3, 7) = 1.5
    ac(4, 7) = 0.5
    ac(5, 7) = 0.0#
    ac(6, 7) = -0.5
    ac(7, 7) = -0.5
    ac(8, 7) = 0.0#
    ac(9, 7) = 0.5
    ac(10, 7) = 1.5
    ac(1, 8) = 2.5
    ac(2, 8) = 3.0#
    ac(3, 8) = 3.0#
    ac(4, 8) = 3.0#
    ac(5, 8) = 2.0#
    ac(6, 8) = 1.0#
    ac(7, 8) = 1.0#
    ac(8, 8) = 0.0#
    ac(9, 8) = 0.0#
    ac(10, 8) = 1.0#
    ac(1, 9) = 1.0#
    ac(2, 9) = 2.0#
    ac(3, 9) = 3.0#
    ac(4, 9) = 3.0#
    ac(5, 9) = 2.5
    ac(6, 9) = 2.5
    ac(7, 9) = 2.0#
    ac(8, 9) = 1.5
    ac(9, 9) = 1.5
    ac(10, 9) = 1.0#
    ac(1, 10) = 1.0#
    ac(2, 10) = 1.5
    ac(3, 10) = 1.5
    ac(4, 10) = 2.0#
    ac(5, 10) = 2.5
    ac(6, 10) = 2.5
    ac(7, 10) = 2.0#
    ac(8, 10) = 2.0#
    ac(9, 10) = 2.0#
    ac(10, 10) = 2.0#
    ac(1, 11) = 2.0#
    ac(2, 11) = 2.0#
    ac(3, 11) = 2.0#
    ac(4, 11) = 2.0#
    ac(5, 11) = 2.0#
    ac(6, 11) = 2.0#
    ac(7, 11) = 2.0#
    ac(8, 11) = 2.0#
    ac(9, 11) = 1.0#
    ac(10, 11) = 1.0#
    ac(1, 12) = 1.0#
    ac(2, 12) = 1.0#
    ac(3, 12) = 1.0#
    ac(4, 12) = 1.0#
    ac(5, 12) = 1.0#
    ac(6, 12) = 1.0#
    ac(7, 12) = 1.0#
    ac(8, 12) = 1.0#
    ac(9, 12) = 1.0#
    ac(10, 12) = 1.0#

    For i = 1 To 24
      For j = 1 To 6
        aXLax(i, j) = -9999.0#
      Next j
    Next i

    aXLax(25, 1) = 616.17
    aXLax(25, 2) = -147.83
    aXLax(25, 3) = -27.17
    aXLax(25, 4) = -3.17
    aXLax(25, 5) = 11.84
    aXLax(25, 6) = 2.02
    aXLax(26, 1) = 609.97
    aXLax(26, 2) = -154.71
    aXLax(26, 3) = -27.49
    aXLax(26, 4) = -2.97
    aXLax(26, 5) = 12.04
    aXLax(26, 6) = 1.3
    aXLax(27, 1) = 603.69
    aXLax(27, 2) = -161.55
    aXLax(27, 3) = -27.69
    aXLax(27, 4) = -2.78
    aXLax(27, 5) = 12.22
    aXLax(27, 6) = 0.64
    aXLax(28, 1) = 597.29
    aXLax(28, 2) = -168.33
    aXLax(28, 3) = -27.78
    aXLax(28, 4) = -2.6
    aXLax(28, 5) = 12.38
    aXLax(28, 6) = 0.02
    aXLax(29, 1) = 590.81
    aXLax(29, 2) = -175.05
    aXLax(29, 3) = -27.74
    aXLax(29, 4) = -2.43
    aXLax(29, 5) = 12.53
    aXLax(29, 6) = -0.56
    aXLax(30, 1) = 584.21
    aXLax(30, 2) = -181.72
    aXLax(30, 3) = -27.57
    aXLax(30, 4) = -2.28
    aXLax(30, 5) = 12.67
    aXLax(30, 6) = -1.1
    aXLax(31, 1) = 577.53
    aXLax(31, 2) = -188.34
    aXLax(31, 3) = -27.29
    aXLax(31, 4) = -2.14
    aXLax(31, 5) = 12.8
    aXLax(31, 6) = -1.6
    aXLax(32, 1) = 570.73
    aXLax(32, 2) = -194.91
    aXLax(32, 3) = -26.89
    aXLax(32, 4) = -2.02
    aXLax(32, 5) = 12.92
    aXLax(32, 6) = -2.05
    aXLax(33, 1) = 563.85
    aXLax(33, 2) = -201.42
    aXLax(33, 3) = -26.37
    aXLax(33, 4) = -1.91
    aXLax(33, 5) = 13.03
    aXLax(33, 6) = -2.45
    aXLax(34, 1) = 556.85
    aXLax(34, 2) = -207.29
    aXLax(34, 3) = -25.72
    aXLax(34, 4) = -1.81
    aXLax(34, 5) = 13.13
    aXLax(34, 6) = -2.8
    aXLax(35, 1) = 549.77
    aXLax(35, 2) = -214.29
    aXLax(35, 3) = -24.96
    aXLax(35, 4) = -1.72
    aXLax(35, 5) = 13.22
    aXLax(35, 6) = -3.1
    aXLax(36, 1) = 542.57
    aXLax(36, 2) = -220.65
    aXLax(36, 3) = -24.07
    aXLax(36, 4) = -1.64
    aXLax(36, 5) = 13.3
    aXLax(36, 6) = -3.35
    aXLax(37, 1) = 535.3
    aXLax(37, 2) = -226.96
    aXLax(37, 3) = -23.07
    aXLax(37, 4) = -1.59
    aXLax(37, 5) = 13.36
    aXLax(37, 6) = -3.58
    aXLax(38, 1) = 527.9
    aXLax(38, 2) = -233.22
    aXLax(38, 3) = -21.95
    aXLax(38, 4) = -1.55
    aXLax(38, 5) = 13.4
    aXLax(38, 6) = -3.77
    aXLax(39, 1) = 520.44
    aXLax(39, 2) = -239.43
    aXLax(39, 3) = -20.7
    aXLax(39, 4) = -1.52
    aXLax(39, 5) = 13.42
    aXLax(39, 6) = -3.92
    aXLax(40, 1) = 512.84
    aXLax(40, 2) = -245.59
    aXLax(40, 3) = -19.33
    aXLax(40, 4) = -1.51
    aXLax(40, 5) = 13.42
    aXLax(40, 6) = -4.03
    aXLax(41, 1) = 505.19
    aXLax(41, 2) = -251.69
    aXLax(41, 3) = -17.83
    aXLax(41, 4) = -1.51
    aXLax(41, 5) = 13.41
    aXLax(41, 6) = -4.1
    aXLax(42, 1) = 497.4
    aXLax(42, 2) = -257.74
    aXLax(42, 3) = -16.22
    aXLax(42, 4) = -1.52
    aXLax(42, 5) = 13.39
    aXLax(42, 6) = -4.13
    aXLax(43, 1) = 489.52
    aXLax(43, 2) = -263.74
    aXLax(43, 3) = -14.49
    aXLax(43, 4) = -1.54
    aXLax(43, 5) = 13.36
    aXLax(43, 6) = -4.12
    aXLax(44, 1) = 481.53
    aXLax(44, 2) = -269.7
    aXLax(44, 3) = -12.63
    aXLax(44, 4) = -1.57
    aXLax(44, 5) = 13.32
    aXLax(44, 6) = -4.07
    aXLax(45, 1) = 473.45
    aXLax(45, 2) = -275.6
    aXLax(45, 3) = -10.65
    aXLax(45, 4) = -1.63
    aXLax(45, 5) = 13.27
    aXLax(45, 6) = -3.98
    aXLax(46, 1) = 465.27
    aXLax(46, 2) = -281.45
    aXLax(46, 3) = -8.55
    aXLax(46, 4) = -1.71
    aXLax(46, 5) = 13.21
    aXLax(46, 6) = -3.85
    aXLax(47, 1) = 456.99
    aXLax(47, 2) = -287.25
    aXLax(47, 3) = -6.33
    aXLax(47, 4) = -1.8
    aXLax(47, 5) = 13.14
    aXLax(47, 6) = -3.68
    aXLax(48, 1) = 448.61
    aXLax(48, 2) = -292.99
    aXLax(48, 3) = -3.98
    aXLax(48, 4) = -1.9
    aXLax(48, 5) = 13.07
    aXLax(48, 6) = -3.47
    aXLax(49, 1) = 440.14
    aXLax(49, 2) = -298.68
    aXLax(49, 3) = -1.51
    aXLax(49, 4) = -2.01
    aXLax(49, 5) = 13.0#
    aXLax(49, 6) = -3.3
    aXLax(50, 1) = 431.55
    aXLax(50, 2) = -304.32
    aXLax(50, 3) = 1.08
    aXLax(50, 4) = -2.13
    aXLax(50, 5) = 12.92
    aXLax(50, 6) = -3.17
    aXLax(51, 1) = 431.55
    aXLax(51, 2) = -304.32
    aXLax(51, 3) = 1.08
    aXLax(51, 4) = -2.13
    aXLax(51, 5) = 12.92
    aXLax(51, 6) = -3.17

  End Sub

  '  Public Function DisPrecip(ByRef DyTSer As atcData.ATCclsTserData, ByRef HrTSer As Collection, ByRef ObsTime As Integer, ByRef Tolerance As Single, Optional ByRef SumFile As String = "") As atcData.ATCclsTserData
  '    'DyTSer - daily time series being disaggregated
  '    'HrTser - collection of hourly timeseries used to disaggregate daily
  '    'ObsTime - observation time of daily precip (1 - 24)
  '    'Tolerance - tolerance for comparison of hourly daily sums to daily value (0.01 - 1.0)
  '    'SumFile - name of file for output summary info

  '    Dim HrPos, i, MaxHrInd As Integer
  '    Dim HrVals() As Single
  '    Dim RndOff, CARRY, MaxHrVal As Single
  '    Dim DyInd, HrInd As Integer
  '    Dim Ratio, DaySum, ClosestDaySum, ClosestRatio As Single
  '    Dim sdt, edt As Double
  '    Dim tmpdate(5) As Integer
  '    Dim OutSumm As Boolean
  '    Dim OutFil As Integer
  '    Dim s As String
  '    Dim lHrVals(24) As Single
  '    Dim rsp, retcod, UsedTriang As Integer
  '    Dim ClosestHrTser As atcData.ATCclsTserData
  '    Dim vHrTser As Object
  '    Dim lHrTser As atcData.ATCclsTserData
  '    Dim DaySumHrTser As atcData.ATCclsTserData
  '    Dim lDisTs As atcData.ATCclsTserData
  '    Dim lDateSum As atcData.ATTimSerDateSummary

  '    On Error GoTo DisPrecipErrHnd
  '    UsedTriang = 0
  '    RndOff = 0.001
  '    If Len(SumFile) > 0 Then
  '      OutSumm = True
  '      OutFil = FreeFile()
  '      FileOpen(OutFil, SumFile, OpenMode.Output)
  '    Else
  '      OutSumm = False
  '    End If
  '    Call InitCmpTs(DyTSer, atcData.ATCTimeUnit.TUHour, 1, 24, lDisTs)
  '    'adjust start/end date based on Obstime
  '    'UPGRADE_WARNING: Couldn't resolve default property of object lDateSum. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '    lDateSum = lDisTs.dates.Summary
  '    Call J2Date(lDateSum.SJDay, tmpdate)
  '    tmpdate(3) = ObsTime
  '    'back up exactly one day for start date
  '    'replace following code with sdt=edt-1
  '    '      For i = 1 To 23
  '    '        Call F90_TIMBAK(3, tmpdate(0))
  '    '      Next i
  '    '      lDisTs.dates.summary.SJDay = Date2J(tmpdate)
  '    lDateSum.SJDay = Date2J(tmpdate) - 1
  '    Call J2Date(lDateSum.EJDay, tmpdate)
  '    tmpdate(3) = ObsTime
  '    lDateSum.EJDay = Date2J(tmpdate) - 1
  '    lDisTs.dates.Summary = lDateSum
  '    ReDim HrVals(lDisTs.dates.Summary.NVALS)
  '    HrPos = 0
  '    For DyInd = 1 To DyTSer.dates.Summary.NVALS
  '      If OutSumm Then 'output summary message to file
  '        Call J2Date(DyTSer.dates.Value(DyInd) - 1, tmpdate)
  '        WriteLine(OutFil, "Distributing Daily Data for " & tmpdate(0) & "/" & tmpdate(1) & "/" & tmpdate(2) & ":  Value is " & DyTSer.Value(DyInd))
  '      End If
  '      If DyTSer.Value(DyInd) > 0 Then 'something to disaggregate
  '        'back up a day, then add obs hour to get actual end of period
  '        edt = DyTSer.dates.Value(DyInd) - 1
  '        Call J2Date(edt, tmpdate)
  '        tmpdate(3) = ObsTime
  '        edt = Date2J(tmpdate)
  '        'replace following code with sdt=edt-1
  '        '      For i = 1 To 23
  '        '        Call F90_TIMBAK(3, tmpdate(0))
  '        '      Next i
  '        '      sdt = Date2J(tmpdate)
  '        sdt = edt - 1
  '        ClosestRatio = 0
  '        For Each vHrTser In HrTSer
  '          lHrTser = vHrTser
  '          DaySumHrTser = lHrTser.SubSetByDate(sdt, edt)
  '          DaySum = 0
  '          For HrInd = 1 To DaySumHrTser.dates.Summary.NVALS
  '            DaySum = DaySum + DaySumHrTser.Value(HrInd)
  '          Next HrInd
  '          If DaySum > 0 Then
  '            Ratio = DyTSer.Value(DyInd) / DaySum
  '            If Ratio > 1 Then Ratio = 1 / Ratio
  '            If Ratio > ClosestRatio Then
  '              ClosestRatio = Ratio
  '              ClosestHrTser = DaySumHrTser
  '              ClosestDaySum = DaySum
  '            End If
  '          End If
  '        Next vHrTser
  '        If ClosestRatio >= 1 - Tolerance Then 'hourly data found to do disaggregation
  '          Ratio = DyTSer.Value(DyInd) / ClosestDaySum
  '          MaxHrVal = 0
  '          DaySum = 0
  '          CARRY = 0
  '          For HrInd = 1 To ClosestHrTser.dates.Summary.NVALS
  '            i = HrPos + HrInd
  '            HrVals(i) = Ratio * ClosestHrTser.Value(HrInd) + CARRY
  '            If HrVals(i) > 0.00001 Then
  '              CARRY = HrVals(i) - (System.Math.Round(HrVals(i) / RndOff) * RndOff)
  '              HrVals(i) = HrVals(i) - CARRY
  '            Else
  '              HrVals(i) = 0.0#
  '            End If
  '            If HrVals(i) > MaxHrVal Then
  '              MaxHrVal = HrVals(i)
  '              MaxHrInd = i
  '            End If
  '            DaySum = DaySum + HrVals(i)
  '          Next HrInd
  '          If CARRY > 0 Then 'add remainder to max hourly value
  '            DaySum = DaySum - HrVals(MaxHrInd)
  '            HrVals(MaxHrInd) = HrVals(MaxHrInd) + CARRY
  '            DaySum = DaySum + HrVals(MaxHrInd)
  '          End If
  '          If OutSumm Then
  '            WriteLine(OutFil, "  Using Data-set Number:  " & ClosestHrTser.Header.id & ", daily sum = " & ClosestDaySum)
  '          End If
  '          If System.Math.Abs(DaySum - DyTSer.Value(DyInd)) > RndOff Then
  '            'values not distributed properly
  '            s = "Problem distributing " & DyTSer.Value(DyInd) & " on " & tmpdate(1) & "/" & tmpdate(2) & "/" & tmpdate(0)
  '            If OutSumm Then
  '              WriteLine(OutFil, "  *** " & s & "  ***")
  '            End If
  '            rsp = MsgBox(s, MsgBoxStyle.Exclamation + MsgBoxStyle.OKCancel, "Precipitation Disaggregation Problem")
  '            If rsp = MsgBoxResult.Cancel Then
  '              lDisTs.errordescription = s
  '              Err.Raise(vbObjectError + 513)
  '            End If
  '          End If
  '        Else 'no data available at hourly stations,
  '          'distribute using triangular distribution
  '          Call DistTriang(DyTSer.Value(DyInd), lHrVals, retcod)
  '          UsedTriang = UsedTriang + 1
  '          For HrInd = 1 To 24
  '            HrVals(HrPos + HrInd) = lHrVals(HrInd)
  '          Next HrInd
  '          If retcod = -1 Then
  '            s = "Unable to distribute this much rain (" & DaySum & ") using triangular distribution." & "Hourly values will be set to -9.98"
  '            rsp = MsgBox(s, MsgBoxStyle.Exclamation + MsgBoxStyle.OKCancel, "Precipitation Disaggregation Problem")
  '          ElseIf retcod = -2 Then
  '            s = "Problem distributing " & DyTSer.Value(DyInd) & " using triangular distribution on " & tmpdate(1) & "/" & tmpdate(2) & "/" & tmpdate(0)
  '            rsp = MsgBox(s, MsgBoxStyle.Exclamation + MsgBoxStyle.OKCancel, "Precipitation Disaggregation Problem")
  '          End If
  '          If OutSumm Then
  '            WriteLine(OutFil, "  *** No hourly total within tolerance - " & DyTSer.Value(DyInd) & "  distributed using triangular distribution ***")
  '            If retcod <> 0 Then
  '              WriteLine(OutFil, "  *** " & s & " ***")
  '            End If
  '          End If
  '          If rsp = MsgBoxResult.Cancel Then
  '            lDisTs.errordescription = s
  '            Err.Raise(vbObjectError + 513 + System.Math.Abs(retcod))
  '          End If
  '        End If
  '      Else 'no daily value to distribute, fill hourly
  '        For HrInd = HrPos + 1 To HrPos + 24
  '          HrVals(HrInd) = 0
  '        Next HrInd
  '      End If
  '      HrPos = HrPos + 24
  '    Next DyInd

  'DisPrecipErrHnd:
  '    On Error GoTo OuttaHere 'in case there's an error in these statements
  '    If OutSumm Then FileClose(OutFil)
  '    lDisTs.Values = VB6.CopyArray(HrVals)

  'OuttaHere:
  '    If UsedTriang > 0 Then
  '      'inform calling routine that automatic triangular distribution was used
  '      s = "WARNING:  Automatic Triangular Distribution was used " & UsedTriang & " times." & vbCrLf
  '      If OutSumm Then
  '        s = s & "Check summary output file (" & SumFile & ") for details of when Triangular Distribution was used"
  '      End If
  '      lDisTs.errordescription = s
  '    End If
  '    DisPrecip = lDisTs

  '  End Function

  '  Private Sub DistTriang(ByRef DaySum As Single, ByRef HrVals() As Single, ByRef retcod As Integer)
  '    'Distribute a daily value to 24 hourly values using a triangular distribution
  '    'DaySum - daily value
  '    'HrVals - array of hourly values
  '    'Retcod - 0 - OK, -1 - DaySum too big,
  '    '        -2 - sum of hourly values does not match daily value (likely a round off problem)

  '    Dim i, j As Integer
  '    Dim VTriang, VSum As Object
  '    Dim RndOff, Ratio, CARRY, lDaySum As Single
  '    Static initfg As Integer
  '    Static Sums(12) As Single
  '    Static Triang(24, 12) As Single

  '    If initfg = 0 Then
  '      'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
  '      'UPGRADE_WARNING: Couldn't resolve default property of object VTriang. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      VTriang = New Object() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 6, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 10, 10, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 15, 20, 15, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 21, 35, 35, 21, 7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8, 28, 56, 70, 56, 28, 8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 9, 36, 84, 126, 126, 84, 36, 9, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1, 0, 0, 0, 0, 0, 0}
  '      'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1041"'
  '      'UPGRADE_WARNING: Couldn't resolve default property of object VSum. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '      VSum = New Object() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048}

  '      For j = 1 To 12
  '        For i = 1 To 24
  '          'UPGRADE_WARNING: Couldn't resolve default property of object VTriang(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '          Triang(i, j) = CSng(VTriang((j - 1) * 24 + i) / 100)
  '        Next i
  '        'UPGRADE_WARNING: Couldn't resolve default property of object VSum(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
  '        Sums(j) = CSng(VSum(j) / 100)
  '      Next j
  '      initfg = 1
  '    End If

  '    retcod = 0
  '    i = 1
  '    Do While DaySum > Sums(i)
  '      i = i + 1
  '      If i > 12 Then
  '        retcod = -1
  '      End If
  '    Loop

  '    RndOff = 0.001
  '    CARRY = 0
  '    Ratio = DaySum / Sums(i)
  '    lDaySum = 0
  '    For j = 1 To 24
  '      HrVals(j) = Ratio * Triang(j, i) + CARRY
  '      If HrVals(j) > 0.00001 Then
  '        CARRY = HrVals(j) - (System.Math.Round(HrVals(j) / RndOff) * RndOff)
  '        HrVals(j) = HrVals(j) - CARRY
  '      Else
  '        HrVals(j) = 0.0#
  '      End If
  '      lDaySum = lDaySum + HrVals(j)
  '    Next j
  '    If CARRY > 0.00001 Then
  '      lDaySum = lDaySum - HrVals(12)
  '      HrVals(12) = HrVals(12) + CARRY
  '      lDaySum = lDaySum + HrVals(12)
  '    End If
  '    If System.Math.Abs(DaySum - lDaySum) > RndOff Then
  '      'values not distributed properly
  '      retcod = -2
  '    End If
  '    If retcod <> 0 Then 'set to accumulated, with daily value at end
  '      For i = 1 To 23
  '        HrVals(i) = -9.98
  '      Next i
  '      HrVals(24) = DaySum
  '    End If

  '  End Sub
End Module
