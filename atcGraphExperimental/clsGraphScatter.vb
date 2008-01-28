Imports System.Drawing

Imports atcData
Imports atcUtility
Imports ZedGraph

Public Class clsGraphScatter
    Inherits clsGraphBase

    <CLSCompliant(False)> _
    Public Sub New(ByVal aDataGroup As atcDataGroup, ByVal aZedGraphControl As ZedGraphControl)
        MyBase.New(aDataGroup, aZedGraphControl)
    End Sub

    Public Overrides Property Datasets() As atcDataGroup
        Get
            Return MyBase.Datasets
        End Get
        Set(ByVal newValue As atcDataGroup)
            MyBase.Datasets = newValue
            If newValue.Count > 1 Then
                Dim lTimeseriesX As atcTimeseries = newValue.ItemByIndex(0)
                Dim lTimeseriesY As atcTimeseries = newValue.ItemByIndex(1)
                Dim lPane As GraphPane = MyBase.pZgc.MasterPane.PaneList(0)
                lPane.Legend.IsVisible = False
                With lPane.XAxis
                    .Type = AxisType.Linear
                    .Scale.MaxAuto = False
                    .Title.Text = lTimeseriesX.ToString
                End With

                With lPane.YAxis
                    .Type = AxisType.Linear
                    .Scale.MaxAuto = False
                    .Title.Text = lTimeseriesY.ToString
                End With

                With lTimeseriesY.Attributes
                    Dim lScen As String = .GetValue("scenario")
                    Dim lLoc As String = .GetValue("location")
                    Dim lCons As String = .GetValue("constituent")
                    Dim lCurveColor As Color = GetMatchingColor(lScen & ":" & lLoc & ":" & lCons)
                    Dim lCurve As LineItem = Nothing
                    Dim lXValues() As Double = lTimeseriesX.Values
                    Dim lYValues() As Double = lTimeseriesY.Values
                    Dim lSymbol As SymbolType
                    Dim lNPts As Integer = lXValues.GetUpperBound(0)
                    If lNPts < 100 Then
                        lSymbol = SymbolType.Star
                    Else
                        lSymbol = SymbolType.Circle
                    End If
                    lCurve = lPane.AddCurve("", lXValues, lYValues, lCurveColor, lSymbol)
                    If lNPts >= 1000 Then
                        lCurve.Symbol.Size = 1
                    ElseIf lNPts >= 100 Then
                        lCurve.Symbol.Size = 2
                    End If
                    lCurve.Line.IsVisible = False
                End With
                ScaleAxis(newValue, lPane.YAxis)
                lPane.XAxis.Scale.Min = lPane.YAxis.Scale.Min
                lPane.XAxis.Scale.Max = lPane.YAxis.Scale.Max
            End If
            pZgc.Refresh()
        End Set
    End Property

End Class
