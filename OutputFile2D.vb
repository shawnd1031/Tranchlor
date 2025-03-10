﻿Imports System.Linq

Public Class OutputFile2D

    Dim NbFiles As Single
    Dim outfile() As String
    Dim nFic() As Short

    Public Sub New(ByRef directory As String, ByRef NbFiles As Single, ByRef nDof As Integer, ByRef Model As Integer)

        ReDim outfile(NbFiles - 1)
        ReDim nFic(NbFiles - 1)

        If Model = 0 Then
            ''Creating output .txt computation result file 2020-07-17 Xuande 
            outfile(0) = directory & "\" & "R_H_DiffusionModel" & ".txt"
            outfile(1) = directory & "\" & "R_W_DiffusionModel" & ".txt"
            outfile(2) = directory & "\" & "R_S_DiffusionModel" & ".txt"
            outfile(3) = directory & "\" & "R_T_DiffusionModel" & ".txt"
            outfile(4) = directory & "\" & "R_Cl_DiffusionModel" & ".txt"
        ElseIf Model = 1 Then
            ''Creating output .txt computation result file 2020-10-23 Xuande 
            outfile(0) = directory & "\" & "R_H_CapillaryModel" & ".txt"
            outfile(1) = directory & "\" & "R_W_CapillaryModel" & ".txt"
            outfile(2) = directory & "\" & "R_S_CapillaryModel" & ".txt"
            outfile(3) = directory & "\" & "R_T_CapillaryModel" & ".txt"
            outfile(4) = directory & "\" & "R_Cl_CapillaryModel" & ".txt"
        End If

        For i As Integer = 0 To NbFiles - 1
            nFic(i) = CShort(FreeFile())
            FileOpen(CInt(nFic(i)), outfile(i), OpenMode.Output)
        Next

        Print(nFic(0), "RH", ",", nDof, ",", "Average RH", ",", "dH", ",", TAB)
        Print(nFic(1), "W", ",", nDof, ",", "Average W", ",", "dW", ",", TAB)
        Print(nFic(2), "S", ",", nDof, ",", "Average S", ",", "dS", ",", TAB)
        Print(nFic(3), "T", ",", nDof, ",", "Average T", ",", "dT", ",", TAB)
        Print(nFic(4), "Cl", ",", nDof, ",", "Average Cl", ",", "dCl", ",", TAB)

        For i As Integer = 0 To NbFiles - 1
            For jj As Integer = 0 To nDof - 1
                Print(CInt(nFic(i)), jj + CShort(1), ",", TAB)
            Next jj
            PrintLine(CInt(nFic(i)), " ")
            Print(CInt(nFic(i)), "0", ",", "0", ",", TAB)
        Next

    End Sub

    Public Sub WriteLine(ByRef H As Double, ByRef w As Double, ByRef S As Double, ByRef T As Double, ByRef Cl As Double)

        Print(CInt(nFic(0)), H, ",", "0", ",", TAB)
        Print(CInt(nFic(1)), w, ",", "0", ",", TAB)
        Print(CInt(nFic(2)), S, ",", "0", ",", TAB)
        Print(CInt(nFic(3)), T, ",", "0", ",", TAB)
        Print(CInt(nFic(4)), Cl, ",", "0", ",", TAB)
    End Sub

    Public Sub WriteFirstLine(ByRef H As Double, ByRef w As Double, ByRef S As Double, ByRef T As Double, ByRef Cl As Double)

        Print(CInt(nFic(0)), H, ",", TAB)
        Print(CInt(nFic(1)), w, ",", TAB)
        Print(CInt(nFic(2)), S, ",", TAB)
        Print(CInt(nFic(3)), T, ",", TAB)
        Print(CInt(nFic(4)), Cl, ",", TAB)
    End Sub

    Public Sub WriteBlankLine()

        PrintLine(CInt(nFic(0)), " ", TAB)
        PrintLine(CInt(nFic(1)), " ", TAB)
        PrintLine(CInt(nFic(2)), " ", TAB)
        PrintLine(CInt(nFic(3)), " ", TAB)
        PrintLine(CInt(nFic(4)), " ", TAB)
    End Sub

    Public Sub WriteFirstHR(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 0

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetHRNew(), ",", TAB) '% humidité relative dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteHR(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 0

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetHRNew(), ",", TAB) '% humidité relative dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteW(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 1

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetWNew(), ",", TAB) '% teneur en eau dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteS(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 2

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetSNew(), ",", TAB) '% saturation de liquid dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteT(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 3

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetTNew(), ",", TAB) '% temperature dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteCl(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 4

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetClNew(), ",", TAB) '% concentration de chlore dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Protected Overrides Sub Finalize()

        For i As Integer = 0 To NbFiles - 1
            FileClose(CInt(nFic(i)))
        Next

        MyBase.Finalize()

    End Sub
End Class
