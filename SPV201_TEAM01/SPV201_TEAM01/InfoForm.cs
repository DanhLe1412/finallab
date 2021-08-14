using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPV201_TEAM01
{
    public partial class InfoForm : Form
    {
        private string sConnection;
        private SqlConnection cnn;

        public InfoForm()
        {
            InitializeComponent();
            sConnection = System.Configuration.ConfigurationSettings.AppSettings["DB"].ToString();
            cnn = new SqlConnection(sConnection);
        }

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem.ToString() == "Contestants")
            {
                LoadAllContestants();
            }
            else if (comboBoxOptions.SelectedItem.ToString() == "Examiners")
            {
                LoadAllExaminers();
            }
            else if (comboBoxOptions.SelectedItem.ToString() == "Official members")
            {
                LoadAllOfficialMembers();
            }
            else if (comboBoxOptions.SelectedItem.ToString() == "Backup members")
            {
                LoadAllBackupMembers();
            }
        }

        private void LoadAllContestants()
        {
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllContestants";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables.Count > 0)
            {
                dataGridViewInfo.DataSource = dataset.Tables[0];
            }

            cnn.Close();
        }

        private void LoadAllExaminers()
        {
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllExaminers";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables.Count > 0)
            {
                dataGridViewInfo.DataSource = dataset.Tables[0];
            }

            cnn.Close();
        }

        private void LoadAllOfficialMembers()
        {
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllOfficalMembers";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables.Count > 0)
            {
                dataGridViewInfo.DataSource = dataset.Tables[0];
            }

            cnn.Close();
        }

        private void LoadAllBackupMembers()
        {
            cnn = new SqlConnection(sConnection);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllBackupMembers";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            if (dataset.Tables.Count > 0)
            {
                dataGridViewInfo.DataSource = dataset.Tables[0];
            }

            cnn.Close();
        }

        private void Close_InfoForm(object sender, FormClosedEventArgs e)
        {

        }
    }
}
