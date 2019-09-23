using Core.EncryptionTools;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAEncryption
{
    public partial class Frm_AddDateToDb : Form
    {
        BlockingCollection<string> LstTime1=new BlockingCollection<string>();
        BlockingCollection<string> LstTime2 = new BlockingCollection<string>();
        Boolean FlagList1Full = false;
        object _lock = new object();

        public Frm_AddDateToDb()
        {
            InitializeComponent();
        }

        private void Timer_CurrentTime_Tick(object sender, EventArgs e)
        {
            Random Rnd = new Random();
            var RndInt=Rnd.Next(10000, 150000000);
            var datestring = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString()+" "+RndInt.ToString()+" "+ DateTime.Now.Date.ToString();
            if (!FlagList1Full)
            {
                lock (_lock)
                {
                    LstTime1.Add(datestring);
                }
            }
            else
            {
                lock (_lock)
                {
                    LstTime2.Add(datestring);
                }
            }
        }

        private  void Timer_BulkAdd_Tick(object sender, EventArgs e)
        {
            timer_BulkAdd.Enabled = false;
            if (LstTime1.Count() > 0)
            {
                FlagList1Full = true;

                var result=AddDataToDbAsync(LstTime1.ToList());

                while (LstTime1.Count() > 0)
                    LstTime1.Take();
            }

            if (LstTime2.Count() > 0)
            {
                FlagList1Full = false;

                var result=AddDataToDbAsync(LstTime1.ToList());

                while (LstTime2.Count() > 0)
                    LstTime2.Take();
            }
            timer_BulkAdd.Enabled = true;
        }

        private bool AddDataToDbAsync(List<string> lst)
        {
            #region Fill DataTables

            DataTable DtKeyModel = new DataTable();
            DtKeyModel.Columns.Add("KeyValue", typeof(String));
            DtKeyModel.Columns.Add("HaskValue", typeof(String)); 

            #endregion

            foreach (var item in lst)
            {
                var hashvalue = StringHelper.GetBase64(item);
                if (hashvalue.Length > 32)
                    hashvalue = hashvalue.Substring(0, 32);
                DtKeyModel.Rows.Add(item,hashvalue);
            }

            SqlParameter ParameterObject = new SqlParameter();
            ParameterObject.SqlDbType = SqlDbType.Structured;
            ParameterObject.ParameterName = "@DtKeyModel";
            ParameterObject.Value = DtKeyModel;
            
            SqlConnection SqlCon = new SqlConnection("Data Source=.;Initial Catalog=DbKeys;Integrated Security=True");
            SqlCommand SqlCmd = new SqlCommand();

            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "[Sp_KeysDataBulkAdd]";
            SqlCmd.Parameters.Add(ParameterObject);

            try
            {
                SqlCmd.Connection.Open();
                SqlCmd.ExecuteNonQuery();
            }
            catch(Exception ex )
            {
                return false;
            }
            finally
            {
                SqlCmd.Connection.Close();
            }

            return true;
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            timer_CurrentTime.Enabled = false;
            timer_BulkAdd.Enabled = false;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            timer_CurrentTime.Enabled = true;
            timer_BulkAdd.Enabled = true;
        }

      
    }
}
