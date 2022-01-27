unit u_report;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Buttons, StdCtrls, Grids, DBGrids, RMD_ADO, RM_dset,
  RM_dbset, RM_class, DB, ADODB, RM_e_main,
  RM_Cross, RM_e_txt, RM_e_csv, RM_DBChart,
  RM_chart, RM_RichEdit, RM_Common, RM_CheckBox, RM_Designer, RM_Dataset,
  RM_BarCode, RM_GridReport, RM_DialogCtls, RM_AsBarView,
  RM_ChineseMoneyMemo, RM_e_Xls, RM_Ole, RM_AngLbl, RM_e_bmp, RM_e_Graphic,
  RM_e_emf, RM_e_htm, RM_e_Jpeg, RM_e_Tiff, RM_E_WMF;

type
  TfrmReport = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Label1: TLabel;
    DBGrid1: TDBGrid;
    RMReport1: TRMReport;
    RMBarCodeObject1: TRMBarCodeObject;
    RMDesigner1: TRMDesigner;
    RMDADOComponents1: TRMDADOComponents;
    RMCheckBoxObject1: TRMCheckBoxObject;
    RMDBChartObject1: TRMDBChartObject;
    RMCSVExport1: TRMCSVExport;
    RMRichObject1: TRMRichObject;
    RMCrossObject1: TRMCrossObject;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    SaveDialog1: TSaveDialog;
    FontDialog1: TFontDialog;
    RMChartObject1: TRMChartObject;
    Conn: TADOConnection;
    RMXLSExport1: TRMXLSExport;
    RMChineseMoneyObject1: TRMChineseMoneyObject;
    RMAsBarCodeObject1: TRMAsBarCodeObject;
    RMDialogControls1: TRMDialogControls;
    RMGridReport1: TRMGridReport;
    RMAngledLabelObject1: TRMAngledLabelObject;
    RMOLEObject1: TRMOLEObject;
    RMCompositeReport1: TRMCompositeReport;
    RMTextExport1: TRMTextExport;
    RMHTMExport1: TRMHTMExport;
    RMEMFExport1: TRMEMFExport;
    RMBMPExport1: TRMBMPExport;
    RMJPEGExport1: TRMJPEGExport;
    RMWMFExport1: TRMWMFExport;
    RMTiffExport1: TRMTiffExport;
    Report: TADOQuery;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure RMDesigner1SaveReport(Report: TRMReport;
      var ReportName: String; SaveAs: Boolean; var Saved: Boolean);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
  private
    Q_Report :TADOQuery;
    function setParm():boolean;
   function AddVar(): boolean;
  public
    { Public declarations }
    //Conn :TADOConnection;
    gs_Type :string;
    gs_SQL,gs_Parm,gs_ParmValue :string;
    procedure init(strCon :widestring);
  end;

var
  frmReport: TfrmReport;

implementation
uses u_Edit,u_Copy,u_sql;
{$R *.dfm}



function TfrmReport.setParm():boolean;
var SQLSyntax,Arg,s :string;
    i,len :integer;
begin

if Q_Report.FieldByName('FSQL').IsNull then
begin
  showmessage('选定报表没有初始化SQL语句,请设置!!');
  result := false;
  exit;
end;

SQLSyntax := Q_Report.FieldByName('FSQL').AsString;

with self.Report do
  begin
  if Length(SQLSyntax) <= 0 then
  begin
    showmessage('选定报表没有初始化SQL语句,请设置!!');
    result := false ;
    exit;
  end;
  SQL.Clear;
  SQL.Add(SQLSyntax);
  Arg:=gs_Parm;

  for i:=0 to Parameters.Count-1 do
    begin
    Len:=Pos(';',Arg);
    if Len <= 0 then
      s:=Arg
      else
      begin
      S:=StrPas(PChar(Copy(Arg,1,Len-1)));
      end;
    Parameters[i].Value := S;
    Arg:=PChar(Copy(Arg,Len+1,Length(Arg)-Len));
    end;
  Prepared;
  Open;
  {
  if FilterString <> '' then
    begin
    Filter:=FilterString;
    Filtered:=True;
    end;
  }
  if Active=False then Result := false;
  //DS.DataSet := Report;
  Result := true;
  end;

end;


procedure TfrmReport.FormClose(Sender: TObject; var Action: TCloseAction);
begin
Action := cafree;
end;

procedure TfrmReport.FormShow(Sender: TObject);
var ds1 :TDataSource;
begin
  ds1 := TDataSource.Create(nil);
  Q_Report := TADOQuery.Create(nil);
  Q_Report.Connection := self.Conn;
  Q_Report.SQL.Add('select * from t_report where FType = '''+gs_Type+'''');
  Q_Report.Open;
  ds1.DataSet := Q_Report;
  DBGrid1.DataSource := ds1;
  Q_Report.Locate('FDefault',1,[loPartialKey]);
  if self.Visible = true then
     DBGrid1.SetFocus;
end;
procedure TfrmReport.Button1Click(Sender: TObject);
begin
  Application.CreateForm(TfrmEdit,frmEdit);
  FrmEdit.strSQL := gs_SQL;
  frmEdit.Q_Edit := Q_Report;
  frmEdit.ib_Append := true;     //增加标志
  frmEdit.gs_Type := gs_Type;    //报表类别
  frmEdit.ShowModal;
end;

procedure TfrmReport.Button3Click(Sender: TObject);
begin
  if Q_Report.RecordCount = 0 then exit;
  Application.CreateForm(TfrmEdit,frmEdit);
  frmEdit.Q_Edit := Q_Report;
  frmEdit.ib_Append := false;
  frmEdit.gs_Type := gs_Type;
  frmEdit.ShowModal;
end;

procedure TfrmReport.Button2Click(Sender: TObject);
begin
if Q_Report.RecordCount = 0 then exit;
if Q_Report['FShop'] = '' then
begin
   showmessage('不能删除默认格式!!');
   exit;
end;
if MessageBox(self.Handle,'真的要删除选定报表吗？','删除确认',MB_YESNO+MB_ICONQUESTION+MB_DEFBUTTON2) = IDNO then exit;
   Q_Report.Delete;
end;

procedure TfrmReport.Button4Click(Sender: TObject);
begin
  if Q_Report.RecordCount = 0 then exit;
  Application.CreateForm(TfrmCopy,frmCopy);
  frmCopy.Conn := self.Conn;
  frmCopy.gs_Type := gs_Type;
  frmCopy.Q_Edit := Q_Report;
  frmCopy.gs_Name := Q_Report.fieldbyname('FName').AsString;
  frmCopy.ShowModal;
end;

procedure TfrmReport.RMDesigner1SaveReport(Report: TRMReport;
  var ReportName: String; SaveAs: Boolean; var Saved: Boolean);
var m :TADOQuery;
    t :TBlobField;
    Stream :TMemoryStream;
    strName :string;
begin

  if Saved = true then
  begin
  strName := Q_Report.fieldbyname('FName').AsString;
  m := TADOQuery.Create(nil);
  m.Connection := self.Conn;
  Stream := TMemoryStream.Create;
  t := TBlobField.Create(nil);
  Report.SaveToStream(Stream);
  m.SQL.Add('select * from t_report where FType = '''+gs_Type+''' and FName = '''+strName+'''');
  t.FieldName := 'FReport';
  t.DataSet := m;
  m.Open;
  m.Edit;
  t.LoadFromStream(Stream);
  m.Post;
  Stream.Free;
  t.Free;
  m.Free;
  Report.Modified := false;
  Report.ComponentModified := false;
  Report.ModalPreview := false;
  end;

  if SaveAs = true then
     begin
     if SaveDialog1.Execute then
        Report.SaveToFile(SaveDialog1.FileName);
     end;
end;

procedure TfrmReport.FormCloseQuery(Sender: TObject;
  var CanClose: Boolean);
var QM :TADOQuery;
    strName :string;
begin
  if self.Conn = nil then exit;
  strName := Q_Report.fieldbyname('FName').AsString;
  QM := TADOQuery.Create(nil);
  QM.Connection := self.Conn;
  QM.SQL.Clear;
  QM.SQL.Add('update t_report set fdefault = 0 where fType = '''+gs_Type+'''');
  QM.ExecSQL;
  QM.SQL.Clear;
  QM.SQL.Add('update t_report set fdefault = 1 where fType = '''+gs_Type+''' and FName = '''+strName+'''');
  QM.ExecSQL;
  QM.Free;
end;

procedure TfrmReport.Button5Click(Sender: TObject);
var m :TADOQuery;
    t :TBlobField;
    Stream :TMemoryStream;
    strName :string;
begin
  if Q_Report.RecordCount = 0 then exit;
  //if setParm() = false then exit;
  strName := Q_Report.fieldbyname('FName').AsString;
  Stream := TMemoryStream.Create;
  t := TBlobField.Create(nil);
  m := TADOQuery.Create(nil);
  m.Connection := self.Conn;
  m.SQL.Add('select * from t_report where FType = '''+gs_Type+''' and FName = '''+strName+'''');
  t.FieldName := 'FReport';
  t.DataSet := m;
  m.Open;
  t.SaveToStream(Stream);
  Stream.Position := 0;
  RMReport1.LoadFromStream(Stream);
  RMReport1.ReportInfo.Title := strName;
  RMReport1.FileName := strName;
  if Stream.Size = 0 then
     RMReport1.Clear;
  AddVar;
  RMReport1.DesignReport;
  Stream.Free;
  t.Free;
  m.Free;
end;

procedure TfrmReport.Button6Click(Sender: TObject);
var m :TADOQuery;
    t :TBlobField;
    Stream :TMemoryStream;
    strName :string;
begin
  if Q_Report.RecordCount = 0 then exit;
  //if setParm() = false then exit;
  strName := Q_Report.fieldbyname('FName').AsString;
  Stream := TMemoryStream.Create;
  t := TBlobField.Create(nil);
  m := TADOQuery.Create(nil);
  m.Connection := self.Conn;
  m.SQL.Add('select * from t_report where FType = '''+gs_Type+''' and FName = '''+strName+'''');
  t.FieldName := 'FReport';
  t.DataSet := m;
  m.Open;
  t.SaveToStream(Stream);
  Stream.Position := 0;
  RMReport1.LoadFromStream(Stream);
  RMReport1.ReportInfo.Title := strName;
  RMReport1.FileName := strName;
  if Stream.Size = 0 then
     begin
     Stream.Free;
     t.Free;
     m.Free;
     exit;
     end;
  AddVar;    
  RMReport1.ShowReport;
  Stream.Free;
  t.Free;
  m.Free;
end;

procedure TfrmReport.Button7Click(Sender: TObject);
var m :TADOQuery;
    t :TBlobField;
    Stream :TMemoryStream;
    strName :string;
begin
  if Q_Report.RecordCount = 0 then exit;
 // if setParm() = false then exit;
  strName := Q_Report.fieldbyname('FName').AsString;
  Stream := TMemoryStream.Create;
  t := TBlobField.Create(nil);
  m := TADOQuery.Create(nil);
  m.Connection := self.Conn;
  m.SQL.Add('select * from t_report where FType = '''+gs_Type+''' and FName = '''+strName+'''');
  t.FieldName := 'FReport';
  t.DataSet := m;
  m.Open;
  t.SaveToStream(Stream);
  Stream.Position := 0;
  RMReport1.LoadFromStream(Stream);
  RMReport1.ReportInfo.Title := strName;
  RMReport1.FileName := strName;
  if Stream.Size = 0 then
     begin
     Stream.Free;
     t.Free;
     m.Free;
     exit;
     end;
  AddVar;   
  RMReport1.PrintReport;
  Stream.Free;
  t.Free;
  m.Free;
end;

procedure TfrmReport.Button8Click(Sender: TObject);
begin
self.Close;
end;

procedure TfrmReport.Button9Click(Sender: TObject);
begin
if Q_Report.RecordCount = 0 then exit;
  Application.CreateForm(TfrmSQL,frmSQL);
  frmSQL.Conn := self.Conn;
  frmSQL.Q_Edit := Q_Report;
  frmSQL.gs_SQL := gs_SQL;
  frmSQL.gs_Parm := self.gs_Parm;
  frmSQL.ShowModal;
end;

procedure TfrmReport.init(strCon :widestring);
var QM :TADOQuery;
begin
  self.Conn.ConnectionString := strCon;
  self.Conn.Connected := true;
  //self.Conn.Assign(con);
  //self.conn := con;
  Report.Connection := self.Conn;
end;

function TfrmReport.AddVar(): boolean;
var  NamePos,ValuePos:Integer;
     NameTemp,ValueTemp:String;
     Parm,parmValue :string;
begin
   if Length(gs_Parm)=0 then
   begin
      result := false;
      exit;
   end;
   Parm := gs_Parm;
   parmvalue := gs_ParmValue;

   RMReport1.dictionary.Variables.Clear;
   RMReport1.dictionary.Variables[' MyVar'] := '';
   NamePos := 1;
   while NamePos > 0 do
   begin
     NamePos:=Pos(';',Parm);
     ValuePos:=Pos(';',parmvalue);

     if NamePos=0 then
     begin
       NameTemp := Parm;
       ValueTemp := parmvalue;
     end
     else
     begin
       NameTemp:=Copy(Parm,1,NamePos-1);
       ValueTemp:=Copy(parmvalue,1,ValuePos-1);
       Parm := Copy(Parm,NamePos + 1,length(Parm));
       parmvalue := Copy(parmvalue,ValuePos + 1,length(parmvalue));
     end;
     RMReport1.dictionary.Variables[NameTemp] := ValueTemp;
   end;
end;

end.
