object frmReport: TfrmReport
  Left = 341
  Top = 255
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #25253#34920#25171#21360
  ClientHeight = 280
  ClientWidth = 336
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnCloseQuery = FormCloseQuery
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 14
  object Label1: TLabel
    Left = 9
    Top = 4
    Width = 52
    Height = 14
    Caption = #25253#34920#21517#31216':'
  end
  object Button1: TButton
    Left = 222
    Top = 21
    Width = 97
    Height = 20
    Caption = #26032#22686'(&N)'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 222
    Top = 66
    Width = 97
    Height = 20
    Caption = #21024#38500'(&D)'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 222
    Top = 44
    Width = 97
    Height = 20
    Caption = #32534#36753'(&E)'
    TabOrder = 3
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 222
    Top = 88
    Width = 97
    Height = 20
    Caption = #22797#21046'...(&O)'
    TabOrder = 4
    OnClick = Button4Click
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 21
    Width = 193
    Height = 249
    ImeName = #37329#23665#33521#25991#20889#20316#21161#25163
    Options = [dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
    TabOrder = 1
    TitleFont.Charset = ANSI_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -12
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    OnDblClick = Button5Click
    Columns = <
      item
        Expanded = False
        FieldName = 'FName'
        Title.Alignment = taCenter
        Title.Caption = #25253#34920#21517#31216
        Width = 171
        Visible = True
      end>
  end
  object Button5: TButton
    Left = 222
    Top = 144
    Width = 97
    Height = 20
    Caption = #25253#34920#35774#35745'(&S)'
    TabOrder = 5
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 222
    Top = 166
    Width = 97
    Height = 20
    Caption = #25171#21360#39044#35272'(&N)'
    TabOrder = 6
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 222
    Top = 188
    Width = 97
    Height = 20
    Caption = #25171#21360'...(&P)'
    TabOrder = 7
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 222
    Top = 240
    Width = 97
    Height = 20
    Caption = #20851#38381'(&C)'
    TabOrder = 8
    OnClick = Button8Click
  end
  object Button9: TButton
    Left = 222
    Top = 112
    Width = 97
    Height = 20
    Caption = #32534#36753'S&QL'#35821#21477
    TabOrder = 9
    Visible = False
    OnClick = Button9Click
  end
  object RMReport1: TRMReport
    ModifyPrepared = True
    InitialZoom = pzDefault
    PreviewButtons = [pbZoom, pbLoad, pbSave, pbPrint, pbFind, pbPageSetup, pbExit, pbSaveToXLS]
    DefaultCollate = False
    SaveReportOptions.RegistryPath = 'ReportMachine\ReportSettings\'
    PreviewOptions.RulerUnit = rmutScreenPixels
    PreviewOptions.RulerVisible = False
    PreviewOptions.DrawBorder = False
    PreviewOptions.BorderPen.Color = clBlue
    PreviewOptions.BorderPen.Style = psDash
    CompressLevel = rmzcFastest
    CompressThread = False
    Left = 112
    ReportData = {}
  end
  object RMBarCodeObject1: TRMBarCodeObject
    Left = 144
  end
  object RMDesigner1: TRMDesigner
    OnSaveReport = RMDesigner1SaveReport
    DesignerRestrictions = []
    Left = 240
  end
  object RMDADOComponents1: TRMDADOComponents
    Left = 88
  end
  object RMCheckBoxObject1: TRMCheckBoxObject
    Left = 63
    Top = 165
  end
  object RMDBChartObject1: TRMDBChartObject
    Left = 120
    Top = 168
  end
  object RMCSVExport1: TRMCSVExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Delimiter = ';'
    Left = 63
    Top = 125
  end
  object RMRichObject1: TRMRichObject
    Left = 32
    Top = 168
  end
  object RMCrossObject1: TRMCrossObject
    Left = 96
    Top = 128
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = 'rmf'
    Filter = 'Report Machine '#34920#21333'(*.rmf)|*.rmf'
    Options = [ofOverwritePrompt, ofHideReadOnly, ofEnableSizing]
    Left = 288
  end
  object FontDialog1: TFontDialog
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    Left = 208
    Top = 104
  end
  object RMChartObject1: TRMChartObject
    Left = 168
    Top = 176
  end
  object Conn: TADOConnection
    LoginPrompt = False
    Left = 104
    Top = 80
  end
  object RMXLSExport1: TRMXLSExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    ExportImageFormat = ifBMP
    ShowAfterExport = True
    ExportPrecision = 1
    PagesOfSheet = 10
    Left = 144
    Top = 128
  end
  object RMChineseMoneyObject1: TRMChineseMoneyObject
    Left = 24
    Top = 104
  end
  object RMAsBarCodeObject1: TRMAsBarCodeObject
    Left = 144
    Top = 56
  end
  object RMDialogControls1: TRMDialogControls
    Left = 152
    Top = 96
  end
  object RMGridReport1: TRMGridReport
    InitialZoom = pzDefault
    PreviewButtons = [pbZoom, pbLoad, pbSave, pbPrint, pbFind, pbPageSetup, pbExit, pbSaveToXLS]
    DefaultCollate = False
    SaveReportOptions.RegistryPath = 'ReportMachine\ReportSettings\'
    PreviewOptions.RulerUnit = rmutScreenPixels
    PreviewOptions.RulerVisible = False
    PreviewOptions.DrawBorder = False
    PreviewOptions.BorderPen.Color = clBlue
    PreviewOptions.BorderPen.Style = psDash
    CompressLevel = rmzcFastest
    CompressThread = False
    Left = 104
    Top = 48
    ReportData = {}
  end
  object RMAngledLabelObject1: TRMAngledLabelObject
    Left = 32
    Top = 32
  end
  object RMOLEObject1: TRMOLEObject
    Left = 24
    Top = 64
  end
  object RMCompositeReport1: TRMCompositeReport
    InitialZoom = pzDefault
    PreviewButtons = [pbZoom, pbLoad, pbSave, pbPrint, pbFind, pbPageSetup, pbExit, pbSaveToXLS]
    DefaultCollate = False
    SaveReportOptions.RegistryPath = 'ReportMachine\ReportSettings\'
    PreviewOptions.RulerUnit = rmutScreenPixels
    PreviewOptions.RulerVisible = False
    PreviewOptions.DrawBorder = False
    PreviewOptions.BorderPen.Color = clBlue
    PreviewOptions.BorderPen.Style = psDash
    CompressLevel = rmzcFastest
    CompressThread = False
    Left = 176
    Top = 32
    ReportData = {}
  end
  object RMTextExport1: TRMTextExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 96
    Top = 160
  end
  object RMHTMExport1: TRMHTMExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    ExportImageFormat = ifJPG
    LinkTextFirst = #31532#19968#39029
    LinkTextNext = #19979#19968#39029
    LinkTextPrev = #19978#19968#39029
    LinkTextLast = #26368#21518#19968#39029
    LinkFont.Charset = DEFAULT_CHARSET
    LinkFont.Color = clBlue
    LinkFont.Height = -24
    LinkFont.Name = 'MS Sans Serif'
    LinkFont.Style = []
    CreateMHTFile = False
    Left = 24
    Top = 136
  end
  object RMEMFExport1: TRMEMFExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 32
    Top = 216
  end
  object RMBMPExport1: TRMBMPExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 144
    Top = 208
  end
  object RMJPEGExport1: TRMJPEGExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 136
    Top = 240
  end
  object RMWMFExport1: TRMWMFExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 80
    Top = 240
  end
  object RMTiffExport1: TRMTiffExport
    ScaleX = 1.000000000000000000
    ScaleY = 1.000000000000000000
    Left = 176
    Top = 224
  end
  object Report: TADOQuery
    Connection = Conn
    Parameters = <>
    Left = 104
    Top = 208
  end
end
