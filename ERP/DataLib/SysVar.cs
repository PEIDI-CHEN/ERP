using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Runtime.InteropServices; // �� DllImport ���ô� �����ռ� 
using System.Reflection; // ʹ�� Assembly �����ô� �����ռ� 
using System.Reflection.Emit;
using System.Windows.Forms; // ʹ�� ILGenerator ���ô� �����ռ� 
using System.Management;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace DataLib
{
    /// <summary> 
    /// �������ݷ�ʽö�� ,ByValue ��ʾֵ���� ,ByRef ��ʾַ���� 
    /// </summary> 

    public enum ModePass
    {

        ByValue = 0x0001,

        ByRef = 0x0002

    } 

    public class SysVar
    {
        public static string strUrl = "http://localhost/jxcService/Service.asmx";//web
        public static string strUID = "";   //�û�����
        public static string strUName = "";  //�û�����
        public static string strUGroup = "";  //�û���
        public static string strCon;  //��ӡ�����ַ���
        public static string strDB; //��ǰ���ݿ�
        public static string strServer = "localhost\\sqlserver2008";
        public static string strLogID = "sa";
        public static string strLogPsw = "sasql";
        public static string strSysCon = "Data Source=localhost\\sqlserver2008;Initial Catalog=tsJXC;Persist Security Info=True;User ID=sa"; //ϵͳ�����ַ���
        public static bool blnInit = false; //ϵͳ��ʼ����־ 
        public static bool blnSaleMan = false; //ҵ��Ա��־ 
        public static int intConnect = 1;   //���ӱ�ʶ(0:webservice;1:remoting)
        public static int intIndex = 0; //��ѯ����ʱ��
        public static string strCompany = "";   //��˾(��ӡʱ��)
        public static string strFactory = "";   //��¼����
        public static bool blnView = false;   //�Ƿ���Բ鿴��������
        public static bool blnStorageFlag = false;   //�Ƿ�ͨ���ֿ�ҵ���������
        public static bool blnDesignForm = false;  //�Ƿ������ģʽ
        public static string strAccount = ""; //��������
        public static bool bReg = false; //��������
        public static int iReportType = 0; //��ӡ��������
        public static string iniFile = "C:\\Set.INI";

        /// </summary> 
        /// <param name="lpFileName">DLL �ļ��� </param> 
        /// <returns> ������ģ��ľ�� </returns> 
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        /// </summary> 
        /// <param name="hModule"> ��������ú����ĺ�����ģ��ľ�� </param> 
        /// <param name="lpProcName"> ���ú��������� </param> 
        /// <returns> ����ָ�� </returns> 
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);


        /// </summary> 
        /// <param name="hModule"> ���ͷŵĺ�����ģ��ľ�� </param> 
        /// <returns> �Ƿ����ͷ�ָ���� Dll</returns> 
        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);


        //������дINI�ļ���API����
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

         //��ӡ���
        [DllImport("RMReport")]
        public static extern int RMDesigner(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue);

        //��ӡ
        [DllImport("RMReport")]
        public static extern int RMPrint(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue, Int32 intCopy);

        //��ӡԤ��
        [DllImport("RMReport")]
        public static extern int RMPreview(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue);

        //�Զ�����񱨱�
        [DllImport("cwReport")]
        public static extern int ShowUserReport(System.IntPtr handle, string strCon);

        public SysVar()
        { 
            //string strServer = IniReadValue("Database", "Server", "C:\\Set.Ini");
        }


        /// <summary>
        /// ��ȡIni�ļ�������ֵ
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="filepath"></param>
        public static void IniWriteValue(string Section, string Key, string Value, string filepath)//��ini�ļ�����д�����ĺ���
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }

        /// <summary>
        /// дINI�ļ�������ֵ
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string filepath)//��ini�ļ����ж������ĺ���
        {
            StringBuilder temp = new StringBuilder();
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filepath);
            return temp.ToString();
        }

        /// <summary>
        /// ȡ��ϵͳ����
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static object GetObjParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return ds.Tables[0].Rows[0][0];
        }

        /// <summary>
        /// ȡ��ϵͳ����
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static bool GetParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select "+strField+" from t_parm");
            return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// ȡ��ϵͳ����
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static decimal GetDecParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }
        /// <summary>
        /// ȡ��ϵͳ����
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static int GetIntParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// ȡ�÷�����ʱ��
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static bool TestCastValid(string sItemID,ref int iDay)
        {
            string sSQL = @"select top 1 DATEDIFF(day,getdate(),a.F_End) as F_Day 
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and b.F_ItemID = '"+sItemID+@"'
                            and DATEDIFF(day,getdate(),a.F_End) <= 30";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            if (ds.Tables[0].Rows.Count == 0) return false;
            iDay = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Day"]);
            return true;
        }

        /// <summary>
        /// ϵͳ��־
        /// </summary>
        /// <param name="strModal"></param>
        /// <param name="strLog"></param>
        public static void SetLog(string strModal, string strLog, string strDescribe)
        {
            if (strModal == "���÷�����") return;
            if (strModal == "�û���¼") return;
            sysClass myClass = new sysClass();
            string[] strIP = myClass.GetIP();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            myHelper.ExecuteSQL("insert into t_UserLog(F_Time,F_User,F_Modal,F_Oper,F_Describe,F_Computer,F_IP) values('" + DateTime.Now.ToString() + "','" + DataLib.SysVar.strUName +"','" + strModal +"','" + strLog +"','" + strDescribe + "','"  + strIP[0] + "','" + strIP[1] + "')");
        }

        /// <summary>
        /// ���ñ�����Ȩ��
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="strModule">ģ������</param>
        public static void TestColumnRight(DevExpress.XtraGrid.Views.Grid.GridView gv,string strModule)
        {
            string strSQL = "select * from t_DetailRight where F_UID = '"+strUID+"' and F_Module = '"+strModule+"'";
            int intCnt,i;
            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            intCnt = gv.Columns.Count;
            for (i = 0; i < intCnt ; i++)
            {
                DataRow[] drField = ds.Tables[0].Select("F_Field = '" + gv.Columns[i].FieldName + "'");
                if (drField.Length > 0)
                {
                    if (Convert.ToBoolean(drField[0]["F_Visible"]) == false)
                    {
                        gv.Columns[i].Tag = "0";
                        gv.Columns[i].Visible = false;
                    }
                    else
                    {
                        gv.Columns[i].Visible = true;
                    }
                }
                
            }
        }

        public static string[] GetMoc()
        {
            try
            {
                string[] str = new string[2];
                ManagementClass mcCpu = new ManagementClass("win32_Processor");
                if (mcCpu != null)
                {
                    ManagementObjectCollection mocCpu = mcCpu.GetInstances();
                    foreach (ManagementObject m in mocCpu)
                    {
                        str[0] = m["ProcessorId"].ToString();
                    }
                }

                ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                if (mcHD != null)
                {
                    ManagementObjectCollection mocHD = mcHD.GetInstances();
                    foreach (ManagementObject m in mocHD)
                    {
                        if (m["DeviceID"].ToString() == "C:")
                        {
                            str[1] = m["VolumeSerialNumber"].ToString();
                            break;
                        }
                    }
                }
                return str;
            }
            catch(Exception E)
            {
                //throw new Exception();
                MessageBox.Show(E.Message, "����77");
                return null;
            }
        }

        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s);
        }

        /// <summary>
        /// ��ע���ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetRegistData(string name)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("tsERP", true);
            registData = aimdir.GetValue(name).ToString();
            return registData;
        }

        public static bool IsRegeditExit(string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("tsERP", true);
            if (aimdir == null)
            {
                aimdir = software.CreateSubKey("tsERP");
            }
            subkeyNames = aimdir.GetValueNames();
            foreach (string keyName in subkeyNames)
            {
               
                if (keyName == name)
                {
                    _exit = true;
                    return _exit;
                }
            }
            return _exit;
        } 

        /// <summary>
        /// дע���ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tovalue"></param>
        public static void WTRegedit(string name, string tovalue)
        {
            if (IsRegeditExit(name) == false) 
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey("tsERP");
                aimdir.SetValue(name, tovalue);
            }
            else
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("tsERP", true);
                aimdir.SetValue(name, tovalue);
            }
        }





        ///// <summary>
        ///// ���ݴ��������ش���
        ///// </summary>
        ///// <param name="sClass"></param>
        ///// <param name="sFormName"></param>
        //public static BaseClass.BaseForm LoadForm(string sClass, string sFormName, Form fParent, bool bMdi, object[] parm)
        //{
        //    Assembly _Assembly = Assembly.LoadFile(strPath + sClass);
        //    Type _FormType = _Assembly.GetType(sFormName, true, true);
        //    object _LoadForm = Activator.CreateInstance(_FormType, null);

        //    BaseClass.BaseForm frm = _LoadForm as BaseClass.BaseForm;
        //    frm.SysParm = parm;

        //    if (frm != null)
        //    {
        //        if (bMdi == false)
        //        {
        //            frm.ShowDialog(fParent);
        //            //frm.Dispose();
        //        }
        //        else
        //        {
        //            if (fParent != null)
        //                frm.MdiParent = fParent;
        //            frm.WindowState = FormWindowState.Maximized;
        //            frm.Show();
        //        }

        //    }
        //    return frm;
        //}
    }
}
