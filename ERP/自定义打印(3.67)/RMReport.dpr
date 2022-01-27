library RMReport;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

uses
  SysUtils,
  Classes,
  Forms,
  DB,
  ADODB,
  ActiveX,
  Dialogs,
  u_Copy in 'u_Copy.pas' {frmCopy},
  u_Edit in 'u_Edit.pas' {frmEdit},
  u_report in 'u_report.pas' {frmReport},
  u_sql in 'u_sql.pas' {frmSQL};

{$R *.res}

{
//释放对象
procedure CloseFree;
begin
with frmReport do
  begin
  if Report.Active then
    Report.Close;
  Report.Free;
  if Conn.Connected then
    Conn.Connected := False;
  Conn.Free;
  end;
end;
}

//初使化adoconn,adoquery并连接
function RMDesigner(handle: THandle;strCon,strType,Parm,ParmValue:PChar):Integer;stdcall;
var
I ,Cnt: Integer;
    Arg:PChar;
    Len:Integer;
    S:String;
    frmReport :TFrmreport;
begin
  //CoInitialize(nil);
  Application.Handle := handle;
  frmReport := TFrmreport.Create(Application);
 // frmReport.gs_SQL := SQLSyntax;
  frmReport.gs_Parm := Parm;
  frmReport.gs_ParmValue := ParmValue;
  frmReport.gs_Type := strType;
  frmReport.Init(strCon);
  frmReport.ShowModal;
  //CoUnInitialize;

  result := 1;
end;

//直接打印
function RMPrint(handle: THandle;strCon,strType,Parm,ParmValue:PChar;intCopy:integer):Integer;stdcall;
begin
  //CoInitialize(nil);
  Application.Handle := handle;
  frmReport := TFrmreport.Create(Application);
 // frmReport.gs_SQL := SQLSyntax;
  frmReport.gs_Parm := Parm;
  frmReport.gs_ParmValue := ParmValue;
  frmReport.gs_Type := strType;
  frmReport.Init(strCon);
  frmReport.FormShow(nil);
  frmReport.RMReport1.ShowPrintDialog := false;
  frmReport.RMReport1.DefaultCopies := intCopy;
  frmReport.Button7.Click;
  frmReport.Free;
  //CoUnInitialize;
 result := 1;
end;

//打印预览
function RMPreview(handle: THandle;strCon,strType,Parm,ParmValue:PChar):Integer;stdcall;
begin
  //CoInitialize(nil);
  Application.Handle := handle;
  frmReport := TFrmreport.Create(Application);
 // frmReport.gs_SQL := SQLSyntax;
  frmReport.gs_Parm := Parm;
  frmReport.gs_ParmValue := ParmValue;
  frmReport.gs_Type := strType;
  frmReport.Init(strCon);
  frmReport.FormShow(nil);
  frmReport.Button6.Click;
  frmReport.Free;
  //CoUnInitialize;
  result := 1;
end;

//dll函数接口
Exports
  RMDesigner,
  RMPrint,
  RMPreview;
begin


end.
