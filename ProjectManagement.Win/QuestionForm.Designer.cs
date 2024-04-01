namespace ProjectManagement.Win
{
    partial class QuestionForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionForm));
            this.txtAnswer = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClearControllers = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsQuestion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsQuestionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsQuestionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.cmsQuestion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAnswer.Location = new System.Drawing.Point(95, 92);
            this.txtAnswer.MaxLength = 1000;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAnswer.Size = new System.Drawing.Size(668, 105);
            this.txtAnswer.TabIndex = 2;
            this.txtAnswer.Text = "";
            // 
            // lblMessage
            // 
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMessage.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(131, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(720, 40);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "متن پیغام";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // btnClearControllers
            // 
            this.btnClearControllers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearControllers.FlatAppearance.BorderSize = 0;
            this.btnClearControllers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearControllers.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearControllers.ForeColor = System.Drawing.Color.Black;
            this.btnClearControllers.Location = new System.Drawing.Point(335, 203);
            this.btnClearControllers.Name = "btnClearControllers";
            this.btnClearControllers.Size = new System.Drawing.Size(104, 55);
            this.btnClearControllers.TabIndex = 4;
            this.btnClearControllers.Text = "بازنشانی";
            this.btnClearControllers.UseVisualStyleBackColor = false;
            this.btnClearControllers.Click += new System.EventHandler(this.btnClearControllers_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(445, 203);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 55);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "ثبت سوال";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "پروژه",
            "کارآموزی",
            "عمومی"});
            this.cmbType.Location = new System.Drawing.Point(95, 43);
            this.cmbType.Name = "cmbType";
            this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbType.Size = new System.Drawing.Size(140, 41);
            this.cmbType.TabIndex = 1;
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.AllowUserToResizeRows = false;
            this.dgvQuestion.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuestion.ColumnHeadersHeight = 50;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQuestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column3,
            this.Column2});
            this.dgvQuestion.ContextMenuStrip = this.cmsQuestion;
            this.dgvQuestion.Location = new System.Drawing.Point(12, 441);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.ReadOnly = true;
            this.dgvQuestion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvQuestion.RowHeadersWidth = 40;
            this.dgvQuestion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvQuestion.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuestion.RowTemplate.Height = 29;
            this.dgvQuestion.Size = new System.Drawing.Size(958, 350);
            this.dgvQuestion.TabIndex = 5;
            this.dgvQuestion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestion_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Question";
            this.Column1.HeaderText = "عنوان سوال";
            this.Column1.MinimumWidth = 266;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 266;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TypeName";
            this.Column3.HeaderText = "نوع سوال";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Answer";
            this.Column2.HeaderText = "پاسخ سوال";
            this.Column2.MinimumWidth = 550;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 550;
            // 
            // cmsQuestion
            // 
            this.cmsQuestion.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmsQuestion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsQuestion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsQuestionEdit,
            this.cmsQuestionDelete});
            this.cmsQuestion.Name = "contextMenuStrip1";
            this.cmsQuestion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsQuestion.Size = new System.Drawing.Size(202, 80);
            // 
            // cmsQuestionEdit
            // 
            this.cmsQuestionEdit.Image = global::ProjectManagement.Win.Properties.Resources.Edit;
            this.cmsQuestionEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsQuestionEdit.Name = "cmsQuestionEdit";
            this.cmsQuestionEdit.Size = new System.Drawing.Size(201, 38);
            this.cmsQuestionEdit.Text = "ویرایش سطر";
            this.cmsQuestionEdit.Click += new System.EventHandler(this.cmsQuestionEdit_Click);
            // 
            // cmsQuestionDelete
            // 
            this.cmsQuestionDelete.Image = global::ProjectManagement.Win.Properties.Resources.Delete;
            this.cmsQuestionDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsQuestionDelete.Name = "cmsQuestionDelete";
            this.cmsQuestionDelete.Size = new System.Drawing.Size(201, 38);
            this.cmsQuestionDelete.Text = "حذف سطر";
            this.cmsQuestionDelete.Click += new System.EventHandler(this.cmsQuestionDelete_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowAll.ForeColor = System.Drawing.Color.Black;
            this.btnShowAll.Location = new System.Drawing.Point(310, 392);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(140, 41);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "مشاهده همه";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblRows
            // 
            this.lblRows.Font = new System.Drawing.Font("IRANSansWeb", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRows.Location = new System.Drawing.Point(12, 405);
            this.lblRows.Name = "lblRows";
            this.lblRows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRows.Size = new System.Drawing.Size(203, 28);
            this.lblRows.TabIndex = 4;
            this.lblRows.Text = "تعداد سطرها";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSearch.Location = new System.Drawing.Point(890, 392);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSearch.Size = new System.Drawing.Size(80, 33);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "جستجو:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(603, 392);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(280, 41);
            this.txtSearch.TabIndex = 1;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAnswer.Location = new System.Drawing.Point(772, 92);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAnswer.Size = new System.Drawing.Size(109, 33);
            this.lblAnswer.TabIndex = 7;
            this.lblAnswer.Text = "پاسخ سوال:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblType.Location = new System.Drawing.Point(241, 43);
            this.lblType.Name = "lblType";
            this.lblType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblType.Size = new System.Drawing.Size(95, 33);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "نوع سوال:";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.Location = new System.Drawing.Point(770, 43);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblQuestion.Size = new System.Drawing.Size(111, 33);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "عنوان سوال:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtQuestion.Location = new System.Drawing.Point(343, 43);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuestion.MaxLength = 50;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuestion.Size = new System.Drawing.Size(420, 41);
            this.txtQuestion.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.txtQuestion);
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.btnClearControllers);
            this.groupBox1.Controls.Add(this.lblAnswer);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansWeb", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(16, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(950, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(456, 392);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 41);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "اعمال جستجو";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(225)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(982, 803);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvQuestion);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("IRANSansWeb", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت سوالات متداول";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionForm_FormClosing);
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.cmsQuestion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAnswer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClearControllers;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.ContextMenuStrip cmsQuestion;
        private System.Windows.Forms.ToolStripMenuItem cmsQuestionEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsQuestionDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnSearch;
    }
}