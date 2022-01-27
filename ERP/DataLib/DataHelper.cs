using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Runtime.Remoting;
//using System.Runtime.Remoting.Channels;
//using System.Runtime.Remoting.Channels.Tcp;
namespace DataLib
{
    public class DataHelper
    {
        /// <summary>
        /// Remoting�����м��
        /// </summary>
        /// <returns></returns>
        //private CenterLib.Service GetObj()
        //{
        //    try
        //    {
        //        ChannelServices.RegisterChannel(new TcpClientChannel(),false);
        //        CenterLib.Service obj = (CenterLib.Service)Activator.GetObject(typeof(CenterLib.Service), "tcp://" + SysVar.strServer + ":8082/tskj");
        //        if (obj == null)
        //        {
        //            MessageBox.Show("�м�����ʧ�ܣ���");
        //            return null;
        //        }
        //        return obj;
        //    }
        //    finally
        //    {
        //        IChannel chanel = ChannelServices.GetChannel("tcp");
        //        ChannelServices.UnregisterChannel(chanel);
        //    }
        //}



        private CenterLib.Service GetObj()
        {
            try
            {

                CenterLib.Service obj = new CenterLib.Service();//(CenterLib.Service)Activator.GetObject(typeof(CenterLib.Service), "tcp://" + SysVar.strServer + ":8082/tskj");
                //if (obj == null)
                //{
                //    MessageBox.Show("�м�����ʧ�ܣ���");
                //    return null;
                //}
                return obj;
            }
            finally
            {
                //IChannel chanel = ChannelServices.GetChannel("tcp");
                //ChannelServices.UnregisterChannel(chanel);
            }
        }


        /// <summary>
        /// ���ô�ӡ���Ӳ���
        /// </summary>
        public void SetPrintInfo()
        {
            CenterLib.Service obj = GetObj();
            Hashtable ht = obj.GetIniInfo();

            int intCnt = ht.Count;

            foreach (DictionaryEntry de in ht)
            {
                //if (de.Key.ToString() == "Server")
                //    DataLib.SysVar.strServer = de.Value.ToString();

                if (de.Key.ToString() == "LogID")
                    DataLib.SysVar.strLogID = de.Value.ToString();

                if (de.Key.ToString() == "Pass")
                    DataLib.SysVar.strLogPsw = de.Value.ToString();
            }

        }

        /// <summary>
        /// WebServiceȡ����Ӧ����
        /// </summary>
        /// <returns></returns>
        private JxcService.Service GetService()
        {
            JxcService.Service myService = new JxcService.Service();
            myService.Url = SysVar.strUrl;
            return myService;
        }

        /// <summary>
        /// ȡ�ú�̨���õ�����
        /// </summary>
        /// <returns></returns>
        public DataSet GetAccount(string sFlag)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                return myService.GetAccount();
            }
            else
            {
                CenterLib.Service obj = GetObj();
                DataSet ds1=obj.GetAccount(sFlag);
                return ds1;

            }
        }

        /// <summary>
        /// ���м��(webservice)ȡ�������ݿ��ַ���
        /// </summary>
        /// <returns></returns>
        public string GetCon()
        {
            JxcService.Service myService = GetService();
            return myService.GetConStr(DataLib.SysVar.strDB);
        }

        /// <summary>
        /// �����Ƿ��¼�ɹ�
        /// </summary>
        /// <param name="strServer"></param>
        /// <returns></returns>
        public bool TestLogin(string strServer)
        {
            SysVar.strServer = strServer;
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                if (myService.Login("LGA", "Kinger") == "success")
                    return true;
                else
                    return false;
            }
            else
            {
                CenterLib.Service obj = GetObj();

                if (obj.Login("LGA", "Kinger") == "success")
                    return true;
                else
                    return false;
                /*

                try
                {
                    if (obj.Login("LGA", "Kinger") == "success")
                        return true;
                    else
                        return false;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "����");
                    return false;
                }
                 */ 
            }
        }

        /// <summary>
        /// ���ݴ���ȥ��SQL���õ���Ӧ���ݼ�
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataSet GetDs(string strSQL)
        {
            string err = "";
            DataSet ds = null;
            byte[] bUserData = null;
            if (DataLib.SysVar.intConnect == 0)////���ӱ�ʶ(0:webservice;1:remoting)
            {
                JxcService.Service myService = GetService();
                bUserData = myService.GetCompressDataSet(ref err, SysVar.strDB, strSQL);
                if (err != "")
                {
                    MessageBox.Show(err, "����55");
                    err = "";
                    return null;
                }
                ds = DataSetCompression.DecompressionDataSet(bUserData);//���л�
                return ds;
            }
            else
            {
                CenterLib.Service obj = GetObj();//���ӱ�ʶ(0:webservice;1:remoting)

                bUserData = obj.GetCompressDataSet(ref err, SysVar.strDB, strSQL);
                if (err != "")
                {
                    MessageBox.Show(err, "����21");
                    err = "";
                    return null;
                }
                ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
        }

        /// <summary>
        /// �������ݼ���SQL��䱣������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public int SaveData(DataSet ds, string strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();

                string strErr = myService.SaveData(SysVar.strDB, ds, strSQL);

                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����22");
                    return -1;
                }
                return 0;
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����23");
                    return -1;
                }
                return 0;
            }
        }

        /// <summary>
        /// ������SQL,�����ؽ�����ݼ�
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public DataSet GetOtherDs(string strSQL, Hashtable parm)
        {
            string err = "";
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();

                byte[] bytes = DataSetCompression.SerializeData(parm);

                byte[] bUserData = myService.GetOtherByte(ref err, SysVar.strDB, strSQL, bytes);
                if (err != "")
                {
                    MessageBox.Show(err, "����24");
                    err = "";
                    return null;
                }
                DataSet ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
            else
            {
                CenterLib.Service obj = GetObj();
                byte[] bUserData = obj.GetOtherByte(ref err, SysVar.strDB, strSQL, parm);
                if (err != "")
                {
                    MessageBox.Show(err, "����25");
                    err = "";
                    return null;
                }
                DataSet ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
        }

        /// <summary>
        /// �����ݼ�����,�������ݼ����鼰SQL�������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public string SaveMuteData(DataSet[] ds, string[] strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                string strErr = myService.SaveMuteData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����26");
                    return strErr;
                }
                return "";
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveMuteData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����27");
                    return strErr;
                }
                return "";
            }
        }

        /// <summary>
        /// �����ݼ�����(������)
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public string SaveMuteData1(DataSet[] ds, string[] strSQL, Hashtable parm)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                byte[] bytes = DataSetCompression.SerializeData(parm);
                string strErr = myService.SaveMuteData1(SysVar.strDB, ds, strSQL, bytes);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����28");
                    return strErr;
                }
                return "";
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveMuteData1(SysVar.strDB, ds, strSQL, parm);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����29");
                    return strErr;
                }
                return ""; 
            }

        }

        /// <summary>
        /// ִ���޷���ֵ�ӣѣ����
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public int ExecuteSQL(string strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                string strErr = myService.ExecuteSQL(SysVar.strDB, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����30");
                    return -1;
                }
                return 0;
            }
            else
            {
                CenterLib.Service obj = GetObj();
                string strErr = obj.ExecuteSQL(SysVar.strDB, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "����31");
                    return -1;
                }
                return 0;
            }
        }
    }
}
