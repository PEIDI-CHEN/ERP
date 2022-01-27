unit u_Edit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, DB, ADODB;

type
  TfrmEdit = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
    Button2: TButton;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
    Q_Edit :TADOQuery;
    ib_Append :Boolean;
    gs_Type :string;
    strSQL :string;
  end;

var
  frmEdit: TfrmEdit;

implementation

{$R *.dfm}

procedure TfrmEdit.Button2Click(Sender: TObject);
begin
Self.Close;
end;

procedure TfrmEdit.Button1Click(Sender: TObject);
begin
  if length(Edit1.Text) = 0 then
  begin
     showmessage('请输入报表名称');
     Edit1.SetFocus;
     exit;
  end;
  if ib_Append = true then
     begin
     Q_Edit.Append;
     Q_Edit.FieldByName('FSQL').AsString := strSQL;
     end;
  Q_Edit.Edit;   
  Q_Edit.FieldByName('FType').AsString := gs_Type;
  Q_Edit.FieldByName('FName').AsString := Edit1.Text;

  try
    begin
    Q_Edit.Post;
    self.Close;
    end
  except
    on e:exception do
      begin
      showmessage(e.Message);
      Q_Edit.Cancel;
      end;
  end;
end;

procedure TfrmEdit.FormShow(Sender: TObject);
begin
  if ib_Append = true then
    self.Caption := '新增报表'
  else
  begin
    self.Caption := '编辑报表';
    Edit1.Text := Q_Edit.FieldByName('FName').AsString;
  end
end;

procedure TfrmEdit.FormClose(Sender: TObject; var Action: TCloseAction);
begin
Action := cafree;
end;

end.
