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
using Microsoft.VisualBasic.Logging;

namespace EsemkaVote
{
    public partial class ReportForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=EsemkaVote;Integrated Security=true;");
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadData("1");

            conn.Open();

            SqlCommand queryComboBox = new SqlCommand("SELECT Id,Name FROM [EsemkaVote].[dbo].[VotingHeader] ORDER BY StartDate ASC", conn);
            SqlDataReader readerComboBox = queryComboBox.ExecuteReader();
            DataTable dataTableCB = new DataTable();
            dataTableCB.Load(readerComboBox);
            comboBox1.DataSource = dataTableCB;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            

            conn.Close();

        }

        private void LoadData(string SelectedId)
        {
            flowLayoutPanel1.Controls.Clear();

            conn.Open();



            SqlCommand queryReason = new SqlCommand("SELECT Reason FROM [EsemkaVote].[dbo].[VotingDetail] WHERE VotedCandidateId = " + SelectedId, conn);
            SqlDataReader readerReason = queryReason.ExecuteReader();
            while (readerReason.Read())
            {
                string reason = readerReason["Reason"].ToString();

                AddRichTextBox(reason);
            }
            conn.Close();
            conn.Open();

            SqlCommand queryVotingHeader = new SqlCommand("SELECT Name, Description FROM [EsemkaVote].[dbo].[VotingHeader] WHERE Id = " + SelectedId + ";", conn);
            SqlDataReader readerVotingHeader = queryVotingHeader.ExecuteReader();
            while (readerVotingHeader.Read())
            {
                lblTitle.Text = readerVotingHeader["Name"].ToString(); 
                lblDecs.Text = readerVotingHeader["Description"].ToString();  
                
            }
            conn.Close();

            conn.Open();
            SqlCommand queryWinner = new SqlCommand("WITH VoteCounts AS ( SELECT vc.EmployeeId AS CandidateId, e.Name AS NameEmployee, e.Photo, COUNT(vd.Id) AS VoteCount, vh.Name AS VotingName, vh.StartDate, vh.EndDate, (SELECT COUNT(*) FROM VotingCandidate WHERE VotingHeaderId = vc.VotingHeaderId) AS TotalCandidates FROM VotingDetail vd "+
                                                "JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId "+
                                                "JOIN VotingHeader vh ON vh.Id = vc.VotingHeaderId "+
                                                "JOIN Employee e ON e.Id = vc.EmployeeId "+
                                                "WHERE vh.Id = '"+SelectedId+"' "+
                                                "GROUP BY vc.EmployeeId, vh.Name, e.Name, e.Photo, vh.StartDate, vh.EndDate, vc.VotingHeaderId "+
                                            "), Winner AS ( "+
                                                "SELECT TOP 1 *, SUM(VoteCount) OVER () AS TotalVotes "+
                                                "FROM VoteCounts "+
                                                "ORDER BY VoteCount DESC "+
                                            ") "+
                                            "SELECT "+
                                                "CandidateId, "+
                                                "NameEmployee, "+
                                                "Photo, "+
                                                "VoteCount, "+
                                                "VotingName, "+
                                                "StartDate, "+
                                                "EndDate, "+
                                                "(VoteCount * 100.0 / TotalVotes) AS VotePercentage, "+
                                                "CONCAT(VoteCount, '/', TotalVotes) AS VotingFraction "+
                                           " FROM Winner;", conn);
            SqlDataReader readerWinner = queryWinner.ExecuteReader();
            if (readerWinner.HasRows)
            {
                while (readerWinner.Read())
                {
                    lblName.Text = readerWinner["NameEmployee"].ToString();
                    lblPersentage.Text = Convert.ToDecimal(readerWinner["VotePercentage"]).ToString("F2") + "%";
                    lblPer.Text = "(" + readerWinner["VotingFraction"].ToString() + ")";

                    string photoPath = @"D:\Agung\ITSSB\04022025\assets\";
                    if (readerWinner["Photo"] != DBNull.Value)
                    {
                        string fullPath = Path.Combine(photoPath, readerWinner["Photo"].ToString());
                        if (File.Exists(fullPath))
                        {
                            pictureBox1.ImageLocation = fullPath;
                        }
                        else
                        {
                            pictureBox1.ImageLocation = Path.Combine(photoPath, "default.jpg");
                        }
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Path.Combine(photoPath, "default.jpg");
                    }
                
                }
            } else
            {
                lblName.Text = "[Name Winner]";
                lblPersentage.Text = "0%";
                lblPer.Text = "(0/0)";
                pictureBox1.ImageLocation = @"D:\Agung\ITSSB\04022025\assets\default.jpg";
            }
            conn.Close();

            conn.Open();
            SqlCommand queryDataGrid = new SqlCommand(@"WITH DivisionVotes AS ( SELECT d.Id AS DivisionId, d.Name AS DivisionName, COUNT(vd.Id) AS VoteCount FROM VotingDetail vd JOIN Employee e ON vd.EmployeeId = e.Id JOIN Division d ON e.DivisionId = d.Id JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId JOIN VotingHeader vh ON vh.Id = vc.VotingHeaderId WHERE vh.Id = '" + SelectedId + "' GROUP BY d.Id, d.Name), TotalVotes AS ( SELECT COUNT(vd.Id) AS TotalVoteCount FROM VotingDetail vd JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId JOIN VotingHeader vh ON vh.Id = vc.VotingHeaderId WHERE vh.Id = '"+SelectedId+"') SELECT dv.DivisionName,  dv.VoteCount, FORMAT(dv.VoteCount * 100.0 / tv.TotalVoteCount, 'N2') + ' %' AS Percentage FROM DivisionVotes dv CROSS JOIN TotalVotes tv ORDER BY dv.VoteCount DESC;", conn);
            //queryDataGrid.Parameters.AddWithValue("@id", SelectedId);
            SqlDataAdapter adapterDg = new SqlDataAdapter(queryDataGrid);

            DataTable dataTable = new DataTable();
            adapterDg.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            conn.Close();

        }
        private void AddRichTextBox(string text)
        {
            RichTextBox richTextBox = new RichTextBox
            {
                Text = text,
                Width = 250,  // Adjust width as needed
                Height = flowLayoutPanel1.Height - 10, // Fit the panel height
                ReadOnly = true,
                Multiline = true,
                ScrollBars = RichTextBoxScrollBars.Vertical, // Allow vertical scrolling inside the box
                BorderStyle = BorderStyle.FixedSingle
            };

            flowLayoutPanel1.Controls.Add(richTextBox);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is System.Data.DataRowView))
            {
                string SelectedId = comboBox1.SelectedValue.ToString();
                LoadData(SelectedId);
            }
        }
    }

}
