unit u_Copy;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, ADODB;

type
  TfrmCopy = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
    Button2: TButton;
    Label2: TLabel;
    Edit2: TEdit;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
    Conn :TADOConnection;
    gs_Type,gs_Name :string;
    Q_Edit :TADOQuery;
  end;

var
  frmCopy: TfrmCopy;

implementation

{$R *.dfm}

procedure TfrmCopy.Button2Click(Sender: TObject);
begin
Self.Close;
end;

procedure TfrmCopy.Button1Click(Sender: TObject);
var QM :TADOQuery;
begin
  if length(Edit1.Text) = 0 then
  begin
     showmessage('请输入目标报表名称');
     Edit1.SetFocus;
     exit;
  end;

  QM := TADOQuery.Create(nil);
  QM.Connection := self.Conn;
  QM.SQL.Clear;
  QM.SQL.Add('insert into t_report(FType,FName,FReport,FSQL,FDefault) select FType,'''+Edit2.Text+''',FReport,FSQL,0 from t_report where FType = '''+gs_Type+''' and FName = '''+gs_Name+'''');
  //ShowMessage('insert into t_report(FShop,FType,FName,FReport,FSQL,FDefault) select '''+gs_Shop+''',FType,'''+Edit2.Text+''',FReport,FSQL,0 from t_report where FType = '''+gs_Type+''' and FName = '''+gs_Name+''' and FShop = '''+gs_Shop+'''');
  try
    begin
    QM.ExecSQL;
    Q_Edit.Close;
    Q_Edit.Open;
    self.Close;
    end
  except
    on e:exception do showmessage(e.Message);
  end;
end;

procedure TfrmCopy.FormShow(Sender: TObject);
begin
  Edit1.Text := gs_Name;
  Edit2.SetFocus;
end;

procedure TfrmCopy.FormClose(Sender: TObject; var Action: TCloseAction);
begin
Action := cafree;
end;

end.
