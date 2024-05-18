Public Function RegExpExtract(text As String, pattern As String, Optional instance_num As Integer = 0, Optional match_case As Boolean = True)
  Dim text_matches() As String
  Dim matches_index As Integer

  On Error GoTo ErrHandl
        
  RegExpExtract = ""
        
  Set regex = CreateObject("VBScript.RegExp")
  regex.pattern = pattern
  regex.Global = True
  regex.MultiLine = True
        
  If True = match_case Then
    regex.IgnoreCase = False
  Else
    regex.IgnoreCase = True
  End If
        
  Set matches = regex.Execute(text)
        
  If 0 < matches.Count Then
      If (0 = instance_num) Then
        ReDim text_matches(matches.Count - 1, 0)
        For matches_index = 0 To matches.Count - 1
          text_matches(matches_index, 0) = matches.Item(matches_index)
        Next matches_index
        RegExpExtract = text_matches
      Else
        RegExpExtract = matches.Item(instance_num - 1)
      End If
  End If
  Exit Function
        
ErrHandl:
    RegExpExtract = CVErr(xlErrValue)
End Function
