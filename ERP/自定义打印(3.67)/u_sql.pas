unit u_sql;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, DB, ADODB, DBCtrls, ExtCtrls;

type
  TfrmSQL = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    DBRichEdit1: TDBRichEdit;
    Panel3: TPanel;
    Panel4: TPanel;
    Button3: TButton;
    Button1: TButton;
    Button2: TButton;
    procedure Button2Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormResize(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    Q_Edit :TADOQuery;
    Conn :TADOConnection;
    gs_Parm,gs_SQL :string;
  end;

var
  frmSQL: TfrmSQL;

implementation

{$R *.dfm}

procedure TfrmSQL.Button2Click(Sender: TObject);
begin
Self.Close;
end;

procedure TfrmSQL.FormClose(Sender: TObject; var Action: TCloseAction);
begin
Action := cafree;
end;

procedure TfrmSQL.FormShow(Sender: TObject);
var ds :TDataSource;
begin
  ds := TDataSource.Create(nil);
  ds.DataSet := Q_Edit;
  DBRichEdit1.DataSource := ds;
  DBRichEdit1.DataField := 'FSQL';
  DBRichEdit1.SetFocus;
end;

procedure TfrmSQL.Button1Click(Sender: TObject);
var QM :TADOQuery;
    arg,s :string;
    i,len :integer;
begin
QM := TADOQuery.Create(nil);
QM.Connection := Conn;
QM.SQL.Add(DBRichEdit1.Text);


Arg:=gs_Parm;

for i:=0 to QM.Parameters.Count-1 do
begin
  Len:=Pos(';',Arg);
  if Len <= 0 then
    s:=Arg
  else
  begin
    S:=StrPas(PChar(Copy(Arg,1,Len-1)));
  end;
QM.Parameters[i].Value := S;
Arg:=PChar(Copy(Arg,Len+1,Length(Arg)-Len));
end;


try
QM.Open;
except
  on e:exception do
  begin
  showmessage('SQL语法有误，请检查!!'+#13#10+'详细信息:'+e.Message);
  QM.Free;
  exit;
  end
end;
QM.Free;

Q_Edit.Edit;
Q_Edit.Post;
self.Close;
end;

procedure TfrmSQL.Button3Click(Sender: TObject);
begin
if Application.MessageBox('真的要取默认SQL语句吗？这将清除当前的结果!!','确认',MB_YESNO	+ MB_ICONQUESTION + MB_DEFBUTTON2) = IDYES	then
begin
  Q_Edit.Edit;
  Q_Edit.FieldByName('FSQL').AsString := gs_SQL;
end;

end;

procedure TfrmSQL.FormResize(Sender: TObject);
begin
  DBRichEdit1.Refresh;
end;

end.
