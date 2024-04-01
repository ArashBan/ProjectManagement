namespace ProjectManagement.Win
{
    partial class TeacherForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLatinName = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.lblFamily = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtLatinName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTeacher = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTeacherEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTeacherDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLatinFamily = new System.Windows.Forms.TextBox();
            this.lblLatinFamily = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblParent = new System.Windows.Forms.Label();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.btnClearControllers = new System.Windows.Forms.Button();
            this.lblRows = new System.Windows.Forms.Label();
            this.chbProject = new System.Windows.Forms.CheckBox();
            this.chbInternship = new System.Windows.Forms.CheckBox();
            this.lblCourses = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            this.cmsTeacher.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.Location = new System.Drawing.Point(380, 126);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPosition.Size = new System.Drawing.Size(64, 33);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "سمت:";
            // 
            // lblLatinName
            // 
            this.lblLatinName.AutoSize = true;
            this.lblLatinName.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLatinName.Location = new System.Drawing.Point(821, 128);
            this.lblLatinName.Name = "lblLatinName";
            this.lblLatinName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLatinName.Size = new System.Drawing.Size(88, 33);
            this.lblLatinName.TabIndex = 14;
            this.lblLatinName.Text = "نام لاتین:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhoneNumber.Location = new System.Drawing.Point(328, 77);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhoneNumber.Size = new System.Drawing.Size(116, 33);
            this.lblPhoneNumber.TabIndex = 18;
            this.lblPhoneNumber.Text = "شماره تماس:";
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNationalCode.Location = new System.Drawing.Point(367, 26);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNationalCode.Size = new System.Drawing.Size(77, 33);
            this.lblNationalCode.TabIndex = 17;
            this.lblNationalCode.Text = "کد ملی:";
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFamily.Location = new System.Drawing.Point(789, 77);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFamily.Size = new System.Drawing.Size(120, 33);
            this.lblFamily.TabIndex = 13;
            this.lblFamily.Text = "نام خانوادگی:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(867, 26);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(42, 33);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "نام:";
            // 
            // txtLatinName
            // 
            this.txtLatinName.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLatinName.Location = new System.Drawing.Point(456, 128);
            this.txtLatinName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLatinName.MaxLength = 50;
            this.txtLatinName.Name = "txtLatinName";
            this.txtLatinName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLatinName.Size = new System.Drawing.Size(280, 41);
            this.txtLatinName.TabIndex = 2;
            this.txtLatinName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLatinName_KeyPress);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhoneNumber.Location = new System.Drawing.Point(41, 77);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhoneNumber.MaxLength = 20;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhoneNumber.Size = new System.Drawing.Size(280, 41);
            this.txtPhoneNumber.TabIndex = 7;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNationalCode.Location = new System.Drawing.Point(41, 26);
            this.txtNationalCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNationalCode.MaxLength = 10;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNationalCode.Size = new System.Drawing.Size(280, 41);
            this.txtNationalCode.TabIndex = 6;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            // 
            // txtFamily
            // 
            this.txtFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFamily.Location = new System.Drawing.Point(456, 77);
            this.txtFamily.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFamily.MaxLength = 50;
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFamily.Size = new System.Drawing.Size(280, 41);
            this.txtFamily.TabIndex = 1;
            this.txtFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamily_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(456, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(280, 41);
            this.txtName.TabIndex = 0;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(151, 220);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 55);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "ثبت استاد";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnStudentRegister_Click);
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.AllowUserToDeleteRows = false;
            this.dgvTeacher.AllowUserToResizeRows = false;
            this.dgvTeacher.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeacher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeacher.ColumnHeadersHeight = 50;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeacher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dgvTeacher.ContextMenuStrip = this.cmsTeacher;
            this.dgvTeacher.Location = new System.Drawing.Point(12, 441);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.ReadOnly = true;
            this.dgvTeacher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IRANSansWeb", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeacher.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeacher.RowHeadersWidth = 40;
            this.dgvTeacher.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvTeacher.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeacher.RowTemplate.Height = 29;
            this.dgvTeacher.Size = new System.Drawing.Size(958, 350);
            this.dgvTeacher.TabIndex = 5;
            this.dgvTeacher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacher_CellClick);
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
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "نام";
            this.Column1.MinimumWidth = 160;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Family";
            this.Column2.HeaderText = "نام خانوادگی";
            this.Column2.MinimumWidth = 160;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CourseNames";
            this.Column5.HeaderText = "دروس";
            this.Column5.MinimumWidth = 150;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NationalCode";
            this.Column3.HeaderText = "کد ملی";
            this.Column3.MinimumWidth = 150;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PhoneNumber";
            this.Column4.HeaderText = "شماره تماس";
            this.Column4.MinimumWidth = 160;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 160;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Parent";
            this.Column8.HeaderText = "نام کامل مدیر گروه";
            this.Column8.MinimumWidth = 220;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 220;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Username";
            this.Column6.HeaderText = "نام کاربری";
            this.Column6.MinimumWidth = 160;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 160;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Password";
            this.Column7.HeaderText = "رمز عبور";
            this.Column7.MinimumWidth = 180;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 180;
            // 
            // cmsTeacher
            // 
            this.cmsTeacher.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmsTeacher.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTeacher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTeacherEdit,
            this.cmsTeacherDelete});
            this.cmsTeacher.Name = "contextMenuStrip1";
            this.cmsTeacher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsTeacher.Size = new System.Drawing.Size(202, 80);
            // 
            // cmsTeacherEdit
            // 
            this.cmsTeacherEdit.Image = global::ProjectManagement.Win.Properties.Resources.Edit;
            this.cmsTeacherEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsTeacherEdit.Name = "cmsTeacherEdit";
            this.cmsTeacherEdit.Size = new System.Drawing.Size(201, 38);
            this.cmsTeacherEdit.Text = "ویرایش سطر";
            this.cmsTeacherEdit.Click += new System.EventHandler(this.cmsTeacherEdit_Click);
            // 
            // cmsTeacherDelete
            // 
            this.cmsTeacherDelete.Image = global::ProjectManagement.Win.Properties.Resources.Delete;
            this.cmsTeacherDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsTeacherDelete.Name = "cmsTeacherDelete";
            this.cmsTeacherDelete.Size = new System.Drawing.Size(201, 38);
            this.cmsTeacherDelete.Text = "حذف سطر";
            this.cmsTeacherDelete.Click += new System.EventHandler(this.cmsTeacherDelete_Click);
            // 
            // txtLatinFamily
            // 
            this.txtLatinFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLatinFamily.Location = new System.Drawing.Point(456, 179);
            this.txtLatinFamily.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLatinFamily.MaxLength = 50;
            this.txtLatinFamily.Name = "txtLatinFamily";
            this.txtLatinFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLatinFamily.Size = new System.Drawing.Size(280, 41);
            this.txtLatinFamily.TabIndex = 3;
            this.txtLatinFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLatinFamily_KeyPress);
            // 
            // lblLatinFamily
            // 
            this.lblLatinFamily.AutoSize = true;
            this.lblLatinFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLatinFamily.Location = new System.Drawing.Point(743, 179);
            this.lblLatinFamily.Name = "lblLatinFamily";
            this.lblLatinFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLatinFamily.Size = new System.Drawing.Size(166, 33);
            this.lblLatinFamily.TabIndex = 15;
            this.lblLatinFamily.Text = "نام خانوادگی لاتین:";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "استاد راهنما",
            "مدیر گروه"});
            this.cmbPosition.Location = new System.Drawing.Point(41, 126);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPosition.Size = new System.Drawing.Size(280, 41);
            this.cmbPosition.TabIndex = 8;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
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
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Enabled = false;
            this.lblParent.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblParent.Location = new System.Drawing.Point(348, 173);
            this.lblParent.Name = "lblParent";
            this.lblParent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblParent.Size = new System.Drawing.Size(96, 33);
            this.lblParent.TabIndex = 20;
            this.lblParent.Text = "مدیر گروه:";
            // 
            // cmbParent
            // 
            this.cmbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParent.Enabled = false;
            this.cmbParent.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(41, 173);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbParent.Size = new System.Drawing.Size(280, 41);
            this.cmbParent.TabIndex = 9;
            this.cmbParent.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            // 
            // btnClearControllers
            // 
            this.btnClearControllers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearControllers.FlatAppearance.BorderSize = 0;
            this.btnClearControllers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearControllers.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearControllers.ForeColor = System.Drawing.Color.Black;
            this.btnClearControllers.Location = new System.Drawing.Point(41, 220);
            this.btnClearControllers.Name = "btnClearControllers";
            this.btnClearControllers.Size = new System.Drawing.Size(104, 55);
            this.btnClearControllers.TabIndex = 11;
            this.btnClearControllers.Text = "بازنشانی";
            this.btnClearControllers.UseVisualStyleBackColor = false;
            this.btnClearControllers.Click += new System.EventHandler(this.btnClearControllers_Click);
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
            // chbProject
            // 
            this.chbProject.AutoSize = true;
            this.chbProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbProject.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbProject.Location = new System.Drawing.Point(617, 228);
            this.chbProject.Name = "chbProject";
            this.chbProject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbProject.Size = new System.Drawing.Size(78, 37);
            this.chbProject.TabIndex = 4;
            this.chbProject.Text = "پروژه";
            this.chbProject.UseVisualStyleBackColor = true;
            // 
            // chbInternship
            // 
            this.chbInternship.AutoSize = true;
            this.chbInternship.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbInternship.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbInternship.Location = new System.Drawing.Point(506, 228);
            this.chbInternship.Name = "chbInternship";
            this.chbInternship.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbInternship.Size = new System.Drawing.Size(105, 37);
            this.chbInternship.TabIndex = 5;
            this.chbInternship.Text = "کارآموزی";
            this.chbInternship.UseVisualStyleBackColor = true;
            // 
            // lblCourses
            // 
            this.lblCourses.AutoSize = true;
            this.lblCourses.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCourses.Location = new System.Drawing.Point(841, 224);
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCourses.Size = new System.Drawing.Size(68, 33);
            this.lblCourses.TabIndex = 16;
            this.lblCourses.Text = "دروس:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNationalCode);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.chbInternship);
            this.groupBox1.Controls.Add(this.txtFamily);
            this.groupBox1.Controls.Add(this.chbProject);
            this.groupBox1.Controls.Add(this.txtPhoneNumber);
            this.groupBox1.Controls.Add(this.txtLatinName);
            this.groupBox1.Controls.Add(this.btnClearControllers);
            this.groupBox1.Controls.Add(this.txtLatinFamily);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblFamily);
            this.groupBox1.Controls.Add(this.lblNationalCode);
            this.groupBox1.Controls.Add(this.lblPhoneNumber);
            this.groupBox1.Controls.Add(this.cmbParent);
            this.groupBox1.Controls.Add(this.lblLatinName);
            this.groupBox1.Controls.Add(this.cmbPosition);
            this.groupBox1.Controls.Add(this.lblLatinFamily);
            this.groupBox1.Controls.Add(this.lblCourses);
            this.groupBox1.Controls.Add(this.lblParent);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.btnRegister);
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
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "اعمال جستجو";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(225)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(982, 803);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvTeacher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت اساتید";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherForm_FormClosing);
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            this.cmsTeacher.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLatinName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtLatinName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.TextBox txtLatinFamily;
        private System.Windows.Forms.Label lblLatinFamily;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.Button btnClearControllers;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.CheckBox chbProject;
        private System.Windows.Forms.CheckBox chbInternship;
        private System.Windows.Forms.Label lblCourses;
        private System.Windows.Forms.ContextMenuStrip cmsTeacher;
        private System.Windows.Forms.ToolStripMenuItem cmsTeacherEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsTeacherDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnSearch;
    }
}