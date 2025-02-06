using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsemkaVote
{
    internal class LoadData
    {
        public readonly SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=EsemkaVote;Integrated Security=true;");
        public string photoPath = @"D:\\Agung\\ITSSB\\04022025\\assets\\";
        public void LoadComboBox(ComboBox comboBox)
        {
            try
            {
                DataTable dataTableCB = ExecuteQuery("SELECT Id, Name FROM VotingHeader ORDER BY StartDate ASC");
                comboBox.DataSource = dataTableCB;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                return dt;
            }
        }

     

        public void LoadHeader(string selectedId, Label lblTitle, Label lblDecs)
        {
            DataTable headerData = ExecuteQuery($"SELECT Name, Description FROM VotingHeader WHERE Id = {selectedId}");
            if (headerData.Rows.Count > 0)
            {
                lblTitle.Text = headerData.Rows[0]["Name"].ToString();
                lblDecs.Text = headerData.Rows[0]["Description"].ToString();
            }
        }

        public void LoadReason(string selectedId, FlowLayoutPanel flowLayoutPanel)
        {
            try
            { 
                flowLayoutPanel.Controls.Clear();
                DataTable reasonData = ExecuteQuery($"SELECT Reason FROM VotingDetail WHERE VotedCandidateId = {selectedId}");
                foreach (DataRow row in reasonData.Rows)
                {
                    AddRichTextBox(row["Reason"].ToString(), flowLayoutPanel);
                }
            } catch (Exception ex )
            {
                MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        public string[] LoadWinner(string selectedId, PictureBox pictureBox)
        {
            try
            {

                DataTable candidates = ExecuteQuery(@"SELECT vc.EmployeeId AS CandidateId, e.Name AS NameEmployee, e.Photo, 
                                                          COUNT(vd.Id) AS VoteCount 
                                                   FROM VotingDetail vd
                                                   JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId
                                                   JOIN Employee e ON e.Id = vc.EmployeeId
                                                   WHERE vc.VotingHeaderId = @id
                                                   GROUP BY vc.EmployeeId, e.Name, e.Photo",
                                                   new SqlParameter("@id", selectedId));

                int totalVotes = SumRowDT(candidates, "VoteCount");

                if (candidates.Rows.Count > 0)
                {
                    var winner = candidates.AsEnumerable().OrderByDescending(row => row.Field<int>("VoteCount")).First();
                    string name = winner["NameEmployee"].ToString();

                    int voteCount = winner.Field<int>("VoteCount");

                    string percentage = totalVotes > 0 ? ((double)voteCount / totalVotes * 100).ToString("F2") + "%" : "0%";
                    string per = $"({voteCount}/{totalVotes})";
                    SetImage(pictureBox, winner["Photo"].ToString());
                    return [name, percentage, per];
                }
                else
                {
                    
                    pictureBox.ImageLocation = Path.Combine(photoPath, "default.jpg");
                    return new string[] { "[Name Winner]", "0%", "(0/0)" };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK);
                return new string[] { "[Error]", "0%", "(0/0)" };
            }
            finally
            {
                conn.Close();
            }

        }

        private void SetImage(PictureBox pictureBox, string fileName)
        {
            string fullPath = Path.Combine(photoPath, fileName ?? "default.jpg");
            pictureBox.ImageLocation = File.Exists(fullPath) ? fullPath : Path.Combine(photoPath, "default.jpg");
        }

        public void LoadDivisionVotes(string selectedId, DataGridView dataGridView)
        {
            try
            {
                DataTable votes = ExecuteQuery(@"SELECT d.Name AS DivisionName, COUNT(vd.Id) AS VoteCount 
                                                 FROM VotingDetail vd
                                                 JOIN Employee e ON vd.EmployeeId = e.Id
                                                 JOIN Division d ON e.DivisionId = d.Id
                                                 JOIN VotingCandidate vc ON vc.Id = vd.VotedCandidateId
                                                 WHERE vc.VotingHeaderId = @id
                                                 GROUP BY d.Name ORDER BY VoteCount DESC",
                                                 new SqlParameter("@id", selectedId));

                int totalVotes = SumRowDT(votes, "VoteCount");
                votes.Columns.Add("Percentage", typeof(string)); // Tambahkan kolom baru untuk persentase

                foreach (DataRow row in votes.Rows)
                {
                    row["Percentage"] = $"{(double)row.Field<int>("VoteCount") / totalVotes * 100:F2}%"; 
                }

                dataGridView.DataSource = votes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }


        private int SumRowDT(DataTable dataTable, string field)
        {
            return dataTable.AsEnumerable().Sum(row => row.Field<int>(field));
        }


        private void AddRichTextBox(string text, FlowLayoutPanel flowLayoutPanel)
        {
            RichTextBox richTextBox = new RichTextBox
            {
                Text = text,
                Width = 250,
                Height = flowLayoutPanel.Height - 10,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };
            flowLayoutPanel.Controls.Add(richTextBox);
        }
    }
}
