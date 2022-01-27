object frmSQL: TfrmSQL
  Left = 351
  Top = 278
  Width = 491
  Height = 307
  Caption = #32534#36753'SQL'#35821#21477
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnResize = FormResize
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 14
  object Panel1: TPanel
    Left = 0
    Top = 249
    Width = 483
    Height = 31
    Align = alBottom
    BevelOuter = bvNone
    TabOrder = 0
    object Panel4: TPanel
      Left = 217
      Top = 0
      Width = 266
      Height = 31
      Align = alRight
      BevelOuter = bvNone
      TabOrder = 0
      object Button3: TButton
        Left = 10
        Top = 5
        Width = 81
        Height = 20
        Caption = #21462#40664#35748'SQL'
        TabOrder = 0
        OnClick = Button3Click
      end
      object Button1: TButton
        Left = 108
        Top = 5
        Width = 73
        Height = 20
        Caption = #30830#23450'(&Y)'
        TabOrder = 1
        OnClick = Button1Click
      end
      object Button2: TButton
        Left = 188
        Top = 5
        Width = 73
        Height = 20
        Caption = #21462#28040'(&N)'
        TabOrder = 2
        OnClick = Button2Click
      end
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 0
    Width = 483
    Height = 249
    Align = alClient
    BevelOuter = bvNone
    TabOrder = 1
    object DBRichEdit1: TDBRichEdit
      Left = 0
      Top = 17
      Width = 483
      Height = 232
      Align = alClient
      DataField = 'FSQL'
      Font.Charset = GB2312_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = #23435#20307
      Font.Style = []
      ImeName = #39118#28165#25196#20116#31508#36755#20837#27861' FOR WIN2000'
      ParentFont = False
      TabOrder = 0
    end
    object Panel3: TPanel
      Left = 0
      Top = 0
      Width = 483
      Height = 17
      Align = alTop
      Alignment = taLeftJustify
      BevelOuter = bvNone
      Caption = #25253#34920'SQL'#35821#21477':'
      TabOrder = 1
    end
  end
end
