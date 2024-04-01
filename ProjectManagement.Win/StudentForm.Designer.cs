namespace ProjectManagement.Win
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.chbInternship = new System.Windows.Forms.CheckBox();
            this.cmbInternship = new System.Windows.Forms.ComboBox();
            this.chbProject = new System.Windows.Forms.CheckBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblField = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblNationalCode = new System.Windows.Forms.Label();
            this.lblStudentCode = new System.Windows.Forms.Label();
            this.lblFamily = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnClearControllers = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsStudent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsStudentEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStudentDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.cmsStudent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbInternship
            // 
            this.chbInternship.AutoSize = true;
            this.chbInternship.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbInternship.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbInternship.Location = new System.Drawing.Point(346, 171);
            this.chbInternship.Name = "chbInternship";
            this.chbInternship.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbInternship.Size = new System.Drawing.Size(110, 37);
            this.chbInternship.TabIndex = 10;
            this.chbInternship.Text = "کارآموزی:";
            this.chbInternship.UseVisualStyleBackColor = true;
            this.chbInternship.CheckedChanged += new System.EventHandler(this.chbInternship_CheckedChanged);
            // 
            // cmbInternship
            // 
            this.cmbInternship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInternship.Enabled = false;
            this.cmbInternship.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbInternship.FormattingEnabled = true;
            this.cmbInternship.Items.AddRange(new object[] {
            "تست"});
            this.cmbInternship.Location = new System.Drawing.Point(38, 171);
            this.cmbInternship.Name = "cmbInternship";
            this.cmbInternship.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbInternship.Size = new System.Drawing.Size(280, 41);
            this.cmbInternship.TabIndex = 11;
            // 
            // chbProject
            // 
            this.chbProject.AutoSize = true;
            this.chbProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbProject.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbProject.Location = new System.Drawing.Point(373, 124);
            this.chbProject.Name = "chbProject";
            this.chbProject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbProject.Size = new System.Drawing.Size(83, 37);
            this.chbProject.TabIndex = 8;
            this.chbProject.Text = "پروژه:";
            this.chbProject.UseVisualStyleBackColor = true;
            this.chbProject.CheckedChanged += new System.EventHandler(this.chbProject_CheckedChanged);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "روزانه",
            "شبانه"});
            this.cmbType.Location = new System.Drawing.Point(38, 77);
            this.cmbType.Name = "cmbType";
            this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbType.Size = new System.Drawing.Size(136, 41);
            this.cmbType.TabIndex = 7;
            // 
            // cmbSemester
            // 
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "مهر",
            "بهمن"});
            this.cmbSemester.Location = new System.Drawing.Point(182, 77);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSemester.Size = new System.Drawing.Size(136, 41);
            this.cmbSemester.TabIndex = 6;
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.Enabled = false;
            this.cmbProject.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Items.AddRange(new object[] {
            "تست"});
            this.cmbProject.Location = new System.Drawing.Point(38, 124);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbProject.Size = new System.Drawing.Size(280, 41);
            this.cmbProject.TabIndex = 9;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Location = new System.Drawing.Point(148, 218);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 55);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "ثبت دانشجو";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblField.Location = new System.Drawing.Point(326, 28);
            this.lblField.Name = "lblField";
            this.lblField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblField.Size = new System.Drawing.Size(130, 33);
            this.lblField.TabIndex = 19;
            this.lblField.Text = "رشته تحصیلی:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhoneNumber.Location = new System.Drawing.Point(797, 232);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhoneNumber.Size = new System.Drawing.Size(116, 33);
            this.lblPhoneNumber.TabIndex = 18;
            this.lblPhoneNumber.Text = "شماره تماس:";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSemester.Location = new System.Drawing.Point(324, 77);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSemester.Size = new System.Drawing.Size(132, 33);
            this.lblSemester.TabIndex = 20;
            this.lblSemester.Text = "نیمسال ورودی:";
            // 
            // lblNationalCode
            // 
            this.lblNationalCode.AutoSize = true;
            this.lblNationalCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNationalCode.Location = new System.Drawing.Point(836, 181);
            this.lblNationalCode.Name = "lblNationalCode";
            this.lblNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNationalCode.Size = new System.Drawing.Size(77, 33);
            this.lblNationalCode.TabIndex = 17;
            this.lblNationalCode.Text = "کد ملی:";
            // 
            // lblStudentCode
            // 
            this.lblStudentCode.AutoSize = true;
            this.lblStudentCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudentCode.Location = new System.Drawing.Point(759, 130);
            this.lblStudentCode.Name = "lblStudentCode";
            this.lblStudentCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStudentCode.Size = new System.Drawing.Size(154, 33);
            this.lblStudentCode.TabIndex = 16;
            this.lblStudentCode.Text = "شماره دانشجویی:";
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFamily.Location = new System.Drawing.Point(793, 82);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFamily.Size = new System.Drawing.Size(120, 33);
            this.lblFamily.TabIndex = 15;
            this.lblFamily.Text = "نام خانوادگی:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(871, 28);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(42, 33);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "نام:";
            // 
            // txtField
            // 
            this.txtField.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtField.Location = new System.Drawing.Point(38, 28);
            this.txtField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtField.MaxLength = 50;
            this.txtField.Name = "txtField";
            this.txtField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtField.Size = new System.Drawing.Size(280, 41);
            this.txtField.TabIndex = 5;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhoneNumber.Location = new System.Drawing.Point(472, 232);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhoneNumber.MaxLength = 20;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhoneNumber.Size = new System.Drawing.Size(280, 41);
            this.txtPhoneNumber.TabIndex = 4;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNationalCode.Location = new System.Drawing.Point(472, 181);
            this.txtNationalCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNationalCode.MaxLength = 10;
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNationalCode.Size = new System.Drawing.Size(280, 41);
            this.txtNationalCode.TabIndex = 3;
            this.txtNationalCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationalCode_KeyPress);
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStudentCode.Location = new System.Drawing.Point(472, 130);
            this.txtStudentCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStudentCode.MaxLength = 14;
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStudentCode.Size = new System.Drawing.Size(280, 41);
            this.txtStudentCode.TabIndex = 2;
            this.txtStudentCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentCode_KeyPress);
            // 
            // txtFamily
            // 
            this.txtFamily.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFamily.Location = new System.Drawing.Point(472, 79);
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
            this.txtName.Location = new System.Drawing.Point(472, 28);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(280, 41);
            this.txtName.TabIndex = 0;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
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
            // btnClearControllers
            // 
            this.btnClearControllers.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearControllers.FlatAppearance.BorderSize = 0;
            this.btnClearControllers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearControllers.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearControllers.ForeColor = System.Drawing.Color.Black;
            this.btnClearControllers.Location = new System.Drawing.Point(38, 218);
            this.btnClearControllers.Name = "btnClearControllers";
            this.btnClearControllers.Size = new System.Drawing.Size(104, 55);
            this.btnClearControllers.TabIndex = 13;
            this.btnClearControllers.Text = "بازنشانی";
            this.btnClearControllers.UseVisualStyleBackColor = false;
            this.btnClearControllers.Click += new System.EventHandler(this.btnClearControllers_Click);
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
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToResizeRows = false;
            this.dgvStudent.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudent.ColumnHeadersHeight = 50;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column10,
            this.Column6});
            this.dgvStudent.ContextMenuStrip = this.cmsStudent;
            this.dgvStudent.Location = new System.Drawing.Point(12, 441);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IRANSansWeb", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudent.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudent.RowHeadersWidth = 40;
            this.dgvStudent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvStudent.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStudent.RowTemplate.Height = 29;
            this.dgvStudent.Size = new System.Drawing.Size(958, 350);
            this.dgvStudent.TabIndex = 5;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
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
            // Column9
            // 
            this.Column9.DataPropertyName = "StudentCode";
            this.Column9.HeaderText = "شماره دانشجویی";
            this.Column9.MinimumWidth = 190;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 190;
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
            // Column5
            // 
            this.Column5.DataPropertyName = "Field";
            this.Column5.HeaderText = "رشته تحصیلی";
            this.Column5.MinimumWidth = 180;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 180;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Semester";
            this.Column8.HeaderText = "ورودی";
            this.Column8.MinimumWidth = 90;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Type";
            this.Column10.HeaderText = "وضعیت";
            this.Column10.MinimumWidth = 90;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CourseNames";
            this.Column6.HeaderText = "دروس";
            this.Column6.MinimumWidth = 150;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // cmsStudent
            // 
            this.cmsStudent.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmsStudent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsStudent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsStudentEdit,
            this.cmsStudentDelete});
            this.cmsStudent.Name = "contextMenuStrip1";
            this.cmsStudent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsStudent.Size = new System.Drawing.Size(202, 80);
            // 
            // cmsStudentEdit
            // 
            this.cmsStudentEdit.Image = global::ProjectManagement.Win.Properties.Resources.Edit;
            this.cmsStudentEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsStudentEdit.Name = "cmsStudentEdit";
            this.cmsStudentEdit.Size = new System.Drawing.Size(201, 38);
            this.cmsStudentEdit.Text = "ویرایش سطر";
            this.cmsStudentEdit.Click += new System.EventHandler(this.cmsStudentEdit_Click);
            // 
            // cmsStudentDelete
            // 
            this.cmsStudentDelete.Image = global::ProjectManagement.Win.Properties.Resources.Delete;
            this.cmsStudentDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsStudentDelete.Name = "cmsStudentDelete";
            this.cmsStudentDelete.Size = new System.Drawing.Size(201, 38);
            this.cmsStudentDelete.Text = "حذف سطر";
            this.cmsStudentDelete.Click += new System.EventHandler(this.cmsStudentDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtField);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtFamily);
            this.groupBox1.Controls.Add(this.txtStudentCode);
            this.groupBox1.Controls.Add(this.chbInternship);
            this.groupBox1.Controls.Add(this.txtNationalCode);
            this.groupBox1.Controls.Add(this.cmbInternship);
            this.groupBox1.Controls.Add(this.txtPhoneNumber);
            this.groupBox1.Controls.Add(this.chbProject);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.lblFamily);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.lblStudentCode);
            this.groupBox1.Controls.Add(this.cmbProject);
            this.groupBox1.Controls.Add(this.lblNationalCode);
            this.groupBox1.Controls.Add(this.btnClearControllers);
            this.groupBox1.Controls.Add(this.lblSemester);
            this.groupBox1.Controls.Add(this.lblPhoneNumber);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.lblField);
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
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "اعمال جستجو";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(225)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(982, 803);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvStudent);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت دانشجویان";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.cmsStudent.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbInternship;
        private System.Windows.Forms.ComboBox cmbInternship;
        private System.Windows.Forms.CheckBox chbProject;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.Label lblStudentCode;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnClearControllers;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.ContextMenuStrip cmsStudent;
        private System.Windows.Forms.ToolStripMenuItem cmsStudentEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsStudentDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnSearch;
    }
}