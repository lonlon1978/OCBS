Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text
Imports System.Net.Dns
Imports System.Net

Public Class common
    Public DataComp As String, Provider As String, DataSource As String, InitialCatalog As String, UserID As String, Password As String,
        strFullname As String, strUsertype As String
    Dim conn As New SqlConnection()
    Public Function connect() As SqlConnection
        Try
            Dim ini As New INIFile(Application.StartupPath + "\ConnectionDll.ini")

            DataSource = ini.Read("ProductionSettings", "Data Source")
            InitialCatalog = ini.Read("ProductionSettings", "Initial Catalog")
            UserID = ini.Read("ProductionSettings", "User Id")
            Password = ini.Read("ProductionSettings", "Password")

            conn.ConnectionString = (Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString("Data Source=") & DataSource) + ";" + "Initial Catalog=") & InitialCatalog) + ";" + "User Id=") & UserID) + ";" + "Password=") & Password) + ";"
            conn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return conn
    End Function

    Public Sub closeConnection(ByVal con As SqlConnection)

        con.Close()

    End Sub

    Public Function base64Encode(ByVal sData As String) As String

        Try
            Dim encData_Byte As Byte() = New Byte(sData.Length - 1) {}
            encData_Byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_Byte)
            Return (encodedData)

        Catch ex As Exception

            Throw (New Exception("Error is base64Encode" & ex.Message))

        End Try


    End Function

    Public Function base64Decode(ByVal sData As String) As String

        Dim encoder As New System.Text.UTF8Encoding()
        Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(sData)
        Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        Dim result As String = New [String](decoded_char)
        Return result

    End Function

    Public Function Insert(ByVal strQuery As String)

        Try
            Dim conn = connect()
            Dim cmd As New SqlCommand(strQuery, conn)
            cmd.ExecuteNonQuery()

            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Nothing
    End Function

    Public Function generateInstallment(ByVal firstDue As Date, ByVal lumpDisc As Boolean, ByVal lumpAddon As Boolean, ByVal fixedPI As Boolean, ByVal balloonPrin As Boolean, ByVal strLoanAmount As String, ByVal strNoOfInstallments As String, ByVal strInterestRate As String, ByVal freq As Integer, ByVal lnAmount As String, ByVal numOfDays As Integer, ByVal valDivisor As Integer, ByVal declining As Boolean, ByVal annuity As Boolean, ByVal dtOpenDate As Date, ByVal valFrequency As String, ByVal scOpt As Boolean, ByVal scRate As String, ByVal grtOpt As Boolean, ByVal grtRate As String) As ArrayList
        Dim result As New ArrayList
        Dim dtpDueDate As String
        ' lumpDisc, lumpAddon, fixedPI, balloonPrin
        Dim valLnAmount = Double.Parse(strLoanAmount)
        Dim sc As Double = 0, grt As Double = 0
        Dim scAmount As Double = 0, grtAmount As Double = 0

        If scOpt Then
            scAmount = valLnAmount * (Convert.ToInt32(scRate * 100) / 10000) * numOfDays / valDivisor
            sc = scAmount / Convert.ToInt32(strNoOfInstallments)
        End If

        If lumpDisc Then
            Dim interestInst As Double = 0.0

            result.Add(Convert.ToString(strNoOfInstallments))
            dtpDueDate = firstDue.ToString("MM/dd/yyyy")
            result.Add(dtpDueDate)
            result.Add(Convert.ToDouble(strLoanAmount).ToString("N", CultureInfo.InvariantCulture))
            result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
            result.Add(sc.ToString("N", CultureInfo.InvariantCulture))
            result.Add(grt.ToString("N", CultureInfo.InvariantCulture))
            result.Add(Convert.ToDouble(strLoanAmount).ToString("N", CultureInfo.InvariantCulture))
            result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
        End If

        If lumpAddon Then
            Dim interestInst As Double
            Dim totalDue As Double
            Dim outStanding As Double = 0.0

            interestInst = valLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * numOfDays / valDivisor
            totalDue = valLnAmount + interestInst

            result.Add(Convert.ToString(strNoOfInstallments))
            dtpDueDate = firstDue.ToString("MM/dd/yyyy")
            result.Add(dtpDueDate)
            result.Add(Convert.ToDouble(strLoanAmount).ToString("N", CultureInfo.InvariantCulture))
            result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
            result.Add(sc.ToString("N", CultureInfo.InvariantCulture))
            result.Add(grt.ToString("N", CultureInfo.InvariantCulture))
            result.Add(totalDue.ToString("N", CultureInfo.InvariantCulture))
            result.Add(outStanding.ToString("N", CultureInfo.InvariantCulture))
        End If

        If fixedPI Then
            Dim prinInst = valLnAmount / Convert.ToInt32(strNoOfInstallments)
            Dim interestInst = valLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * numOfDays / valDivisor
            Dim computedLnAmount = valLnAmount
            Dim totalDue As Double = 0

            If grtOpt Then
                Dim grtRatio = (Convert.ToInt32(strInterestRate * 100) / 10000) * (Convert.ToInt32(grtRate * 100) / 10000)
                grtAmount = valLnAmount * (grtRatio) * numOfDays / valDivisor
                grt = grtAmount / Convert.ToInt32(strNoOfInstallments)
            End If

            interestInst = interestInst / Convert.ToInt32(strNoOfInstallments)
            prinInst = Math.Round(prinInst, 2)

            For i = 1 To Convert.ToInt32(strNoOfInstallments)

                result.Add(Convert.ToString(i))
                dtpDueDate = generateDueDate(firstDue, IIf(i = 1, 0, freq))
                result.Add(dtpDueDate)

                computedLnAmount = computedLnAmount - prinInst

                If i = Convert.ToInt32(strNoOfInstallments) Then

                    If computedLnAmount > 0 Then
                        prinInst = prinInst + computedLnAmount
                        computedLnAmount = 0
                    Else
                        If computedLnAmount < 0 Then
                            prinInst = prinInst + computedLnAmount
                            computedLnAmount = 0
                        End If
                    End If

                End If
                totalDue = prinInst + interestInst + sc + grt
                result.Add(prinInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(sc.ToString("N", CultureInfo.InvariantCulture))
                result.Add(grt.ToString("N", CultureInfo.InvariantCulture))
                result.Add(totalDue.ToString("N", CultureInfo.InvariantCulture))
                result.Add(computedLnAmount.ToString("N", CultureInfo.InvariantCulture))

                firstDue = Convert.ToDateTime(dtpDueDate)

            Next

        End If

        If declining Then

            Dim prinInst = valLnAmount / Convert.ToInt32(strNoOfInstallments)
            'Dim interestInst = valLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * numOfDays / valDivisor
            Dim computedLnAmount = valLnAmount
            Dim totalDue As Double = 0
            Dim startDate As Date = dtOpenDate
            Dim endDate As Date
            Dim interestInst As Double
            Dim grtRatio As Double

            If grtOpt Then
                grtRatio = (Convert.ToInt32(strInterestRate * 100) / 10000) * (Convert.ToInt32(grtRate * 100) / 10000)
            End If

            'interestInst = interestInst / Convert.ToInt32(strNoOfInstallments)
            prinInst = Math.Round(prinInst, 2)

            For i = 1 To Convert.ToInt32(strNoOfInstallments)

                result.Add(Convert.ToString(i))
                dtpDueDate = generateDueDate(firstDue, IIf(i = 1, 0, freq))
                result.Add(dtpDueDate)
                endDate = dtpDueDate

                interestInst = computedLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * (DateDiff(DateInterval.Day, startDate, endDate)) / valDivisor
                If grtOpt Then
                    grt = computedLnAmount * grtRatio * (DateDiff(DateInterval.Day, startDate, endDate)) / valDivisor
                End If
                startDate = endDate

                computedLnAmount = computedLnAmount - prinInst

                If i = Convert.ToInt32(strNoOfInstallments) Then

                    If computedLnAmount > 0 Then
                        prinInst = prinInst + computedLnAmount
                        computedLnAmount = 0
                    Else
                        If computedLnAmount < 0 Then
                            prinInst = prinInst + computedLnAmount
                            computedLnAmount = 0
                        End If
                    End If

                End If
                totalDue = prinInst + interestInst + sc + grt
                result.Add(prinInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(sc.ToString("N", CultureInfo.InvariantCulture))
                result.Add(grt.ToString("N", CultureInfo.InvariantCulture))
                result.Add(totalDue.ToString("N", CultureInfo.InvariantCulture))
                result.Add(computedLnAmount.ToString("N", CultureInfo.InvariantCulture))

                firstDue = Convert.ToDateTime(dtpDueDate)

            Next

        End If

        If annuity Then

            Dim prinInst = valLnAmount / Convert.ToInt32(strNoOfInstallments)
            'Dim interestInst = valLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * numOfDays / valDivisor
            Dim computedLnAmount = valLnAmount
            Dim totalDue As Double = 0
            Dim startDate As Date = dtOpenDate
            Dim endDate As Date
            Dim interestInst As Double

            Dim factor = (Convert.ToInt32(strInterestRate * 100) / 10000) / Convert.ToInt32(valFrequency)
            totalDue = valLnAmount * (factor / (1 - ((1 / (1 + factor)) ^ Convert.ToInt32(strNoOfInstallments))))

            'interestInst = interestInst / Convert.ToInt32(strNoOfInstallments)
            'prinInst = Math.Round(prinInst, 2)

            For i = 1 To Convert.ToInt32(strNoOfInstallments)

                result.Add(Convert.ToString(i))
                dtpDueDate = generateDueDate(firstDue, IIf(i = 1, 0, freq))
                result.Add(dtpDueDate)
                endDate = dtpDueDate

                interestInst = computedLnAmount * (Convert.ToInt32(strInterestRate * 100) / 10000) * (DateDiff(DateInterval.Day, startDate, endDate)) / valDivisor
                startDate = endDate

                prinInst = totalDue - interestInst
                computedLnAmount = computedLnAmount - prinInst

                If i = Convert.ToInt32(strNoOfInstallments) Then

                    If computedLnAmount > 0 Then
                        prinInst = prinInst + computedLnAmount
                        computedLnAmount = 0
                    Else
                        If computedLnAmount < 0 Then
                            prinInst = prinInst + computedLnAmount
                            computedLnAmount = 0
                        End If
                    End If

                End If
                totalDue = prinInst + interestInst
                result.Add(prinInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(interestInst.ToString("N", CultureInfo.InvariantCulture))
                result.Add(sc.ToString("N", CultureInfo.InvariantCulture))
                result.Add(grt.ToString("N", CultureInfo.InvariantCulture))
                result.Add(totalDue.ToString("N", CultureInfo.InvariantCulture))
                result.Add(computedLnAmount.ToString("N", CultureInfo.InvariantCulture))

                firstDue = Convert.ToDateTime(dtpDueDate)

            Next

        End If

        If balloonPrin = True Then

        End If

        Return result
    End Function

    Private Function generateDueDate(ByVal first As Date, ByVal Days As Integer) As String
        Dim result As String = ""

        first = first.AddDays(Days)
        result = first.ToString("MM/dd/yyyy")

        Return result
    End Function

    Public Function generateEIR(ByVal netAmount As Double, ByVal totAmort As Double, ByVal nTerm As Integer) As Double
        Dim result As Double

        Dim nIRR As Double = 0
        Dim aMA As New ArrayList
        Dim nIncVal As Double = 0.000001
        Dim nSum As Integer = 1
        Dim x As Integer = 0
        Dim nPayTotal As Double = 0

        netAmount = netAmount / 100
        totAmort = totAmort / 100

        netAmount = netAmount * -1

        'For x = 1 To nTerm

        '    If x = nTerm Then
        '        aMA.Add()
        '        AAdd(aMA, lastamort / 100)
        '    Else
        '        AAdd(aMA, nMA)
        '    End If

        'Next x


        Return result
    End Function

    Public Function generateAccountNumber(ByVal strBranchID As String, ByVal prodType As String, ByVal serialNum As Integer) As String
        Dim result = ""

        'Dim strMask = frmMainMenu.acntNoMask

        serialNum = serialNum + 1
        result = strBranchID + "-" + prodType + "-" + serialNum.ToString.PadLeft(7, "0") + "-" + checkDigit(strBranchID + prodType + serialNum.ToString.PadLeft(7, "0"))

        Return result
    End Function

    Private Function checkDigit(ByVal acntNumber As String) As String
        Dim digit = 0
        Dim checkDgt = "2121212121212"
        Dim cardLength = acntNumber.Length
        Dim total = 0

        For i = 0 To cardLength - 1

            Dim subTotal = Convert.ToInt32(acntNumber.Substring(i, 1)) * Convert.ToInt32(checkDgt.Substring(i, 1))
            If subTotal > 10 Then
                subTotal = Convert.ToString(subTotal)
                subTotal = Convert.ToInt32(subTotal.ToString.Substring(0, 1)) + Convert.ToInt32(subTotal.ToString.Substring(1, 1))
            End If
            total = total + subTotal

        Next

        digit = (10 - (total Mod 10)) Mod 10

        Return Convert.ToString(digit)
    End Function

    Public Function getHolidays() As String
        Dim result As String = ""
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     holidays ")
            xSQL.AppendLine("from branch ")
            xSQL.AppendLine("where code='" + frmLogin.txtBranchID.Text.Trim() + "'")
            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet

                da.Fill(ds)
                If ds.Tables(0).Rows.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows
                        'nCount = ds.Tables(0)
                        result = dr("holidays")
                    Next
                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try

        Return result
    End Function

End Class
