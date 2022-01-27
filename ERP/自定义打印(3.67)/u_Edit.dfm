object frmEdit: TfrmEdit
  Left = 328
  Top = 347
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = #32534#36753#25253#34920
  ClientHeight = 95
  ClientWidth = 291
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
    Top = 6
    Width = 52
    Height = 14
    Caption = #25253#34920#21517#31216':'
  end
  object Edit1: TEdit
    Left = 24
    Top = 28
    Width = 241
    Height = 22
    ImeName = #37329#23665#33521#25991#20889#20316#21161#25163
    TabOrder = 0
  end
  object Button1: TButton
    Left = 127
    Top = 62
    Width = 65
    Height = 22
    Caption = #30830#23450'(&Y)'
    Default = True
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 199
    Top = 62
    Width = 65
    Height = 22
    Caption = #21462#28040'(&N)'
    TabOrder = 2
    OnClick = Button2Click
  end
end
