namespace EsemkaVote
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBox1 = new ComboBox();
            lblTitle = new Label();
            lblDecs = new Label();
            lblName = new Label();
            label2 = new Label();
            lblPersentage = new Label();
            lblPer = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 30);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 0;
            label1.Text = "Select Vote Event";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(21, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(215, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(177, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(324, 45);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Best Employee 2023";
            // 
            // lblDecs
            // 
            lblDecs.Anchor = AnchorStyles.None;
            lblDecs.AutoSize = true;
            lblDecs.Font = new Font("Calibri", 9F);
            lblDecs.Location = new Point(26, 82);
            lblDecs.MaximumSize = new Size(600, 48);
            lblDecs.MinimumSize = new Size(600, 48);
            lblDecs.Name = "lblDecs";
            lblDecs.Size = new Size(600, 48);
            lblDecs.TabIndex = 3;
            lblDecs.Text = "Welcome to the Employee of the Year 2023 voting! Celebrate outstanding dedication and achievement by casting your vote for the most deserving nominee.";
            lblDecs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.None;
            lblName.AutoSize = true;
            lblName.Font = new Font("Calibri", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(84, 13);
            lblName.MinimumSize = new Size(400, 45);
            lblName.Name = "lblName";
            lblName.Size = new Size(400, 45);
            lblName.TabIndex = 5;
            lblName.Text = "Emely Davis";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(258, 58);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 6;
            label2.Text = "With";
            // 
            // lblPersentage
            // 
            lblPersentage.Anchor = AnchorStyles.None;
            lblPersentage.AutoSize = true;
            lblPersentage.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersentage.Location = new Point(205, 76);
            lblPersentage.MinimumSize = new Size(150, 45);
            lblPersentage.Name = "lblPersentage";
            lblPersentage.Size = new Size(150, 45);
            lblPersentage.TabIndex = 7;
            lblPersentage.Text = "62.32%";
            lblPersentage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPer
            // 
            lblPer.Anchor = AnchorStyles.None;
            lblPer.AutoSize = true;
            lblPer.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPer.Location = new Point(204, 121);
            lblPer.MinimumSize = new Size(150, 45);
            lblPer.Name = "lblPer";
            lblPer.Size = new Size(150, 45);
            lblPer.TabIndex = 8;
            lblPer.Text = "(31/50)";
            lblPer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 552);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1261, 142);
            dataGridView1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(12, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(lblDecs);
            panel2.Controls.Add(lblTitle);
            panel2.Location = new Point(315, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 151);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(lblName);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(lblPersentage);
            panel3.Controls.Add(lblPer);
            panel3.Location = new Point(358, 359);
            panel3.Name = "panel3";
            panel3.Size = new Size(544, 176);
            panel3.TabIndex = 12;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 14F, FontStyle.Bold);
            label5.Location = new Point(6, 8);
            label5.Name = "label5";
            label5.Size = new Size(87, 29);
            label5.TabIndex = 13;
            label5.Text = "Reason";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(3, 40);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1255, 123);
            flowLayoutPanel1.TabIndex = 19;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Location = new Point(12, 717);
            panel4.Name = "panel4";
            panel4.Size = new Size(1261, 178);
            panel4.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(575, 168);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 898);
            Controls.Add(pictureBox1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(1303, 945);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportForm";
            WindowState = FormWindowState.Maximized;
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label lblTitle;
        private Label lblDecs;
        private Label lblName;
        private Label label2;
        private Label lblPersentage;
        private Label lblPer;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel4;
        private PictureBox pictureBox1;
    }
}