using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaVote
{
    public partial class ReportForm : Form
    {
       
       

        LoadData loadData = new LoadData();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            loadData.LoadComboBox(comboBox1);
            LoadData("1");
        }

        public void LoadData(string selectedId)
        {
            try
            {
                loadData.LoadReason(selectedId, flowLayoutPanel1);
                loadData.LoadHeader(selectedId, lblTitle, lblDecs);

                string[] winner = loadData.LoadWinner(selectedId, pictureBox1);
                lblName.Text = winner[0];
                lblPersentage.Text = winner[1];
                lblPer.Text = winner[2];

                loadData.LoadDivisionVotes(selectedId, dataGridView1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                loadData.conn.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is DataRowView))
            {
                LoadData(comboBox1.SelectedValue.ToString());
            }
        }
    }
}
