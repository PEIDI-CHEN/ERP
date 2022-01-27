object frmCopy: TfrmCopy
  Left = 328
  Top = 347
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = #32534#36753#25253#34920
  ClientHeight = 150
  ClientWidth = 287
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 14
  object Label1: TLabel
    Left = 24
    Top = 8
    Width = 64
    Height = 14
    Caption = #28304#25253#34920#21517#31216':'
  end
  object Label2: TLabel
    Left = 24
    Top = 61
    Width = 76
    Height = 14
    Caption = #30446#26631#25253#34920#21517#31216':'
  end
  object Edit1: TEdit
    Left = 24
    Top = 28
    Width = 241
    Height = 22
    Color = cl3DLight
    ImeName = #37329#23665#33521#25991#20889#20316#21161#25163
    ReadOnly = True
    TabOrder = 0
  end
  object Button1: TButton
    Left = 127
    Top = 113
    Width = 65
    Height = 22
    Caption = #30830#23450'(&Y)'
    Default = True
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 199
    Top = 113
    Width = 65
    Height = 22
    Caption = #21462#28040'(&N)'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Edit2: TEdit
    Left = 24
    Top = 79
    Width = 241
    Height = 22
    ImeName = #37329#23665#33521#25991#20889#20316#21161#25163
    TabOrder = 3
  end
end
