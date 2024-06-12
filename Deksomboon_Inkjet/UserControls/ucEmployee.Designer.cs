namespace Deksomboon_Inkjet.UserControls
{
    partial class ucEmployee
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

        #region Component Designer generated code

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
            this.btnEditEmployee = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnDeleteEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.DataGridEmployee = new Guna.UI2.WinForms.Guna2DataGridView();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emppasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emproleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Controls.Add(this.btnDeleteEmployee);
            this.btnEditEmployee.Controls.Add(this.btnEdit);
            this.btnEditEmployee.Controls.Add(this.btnAddEmployee);
            this.btnEditEmployee.Controls.Add(this.DataGridEmployee);
            this.btnEditEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditEmployee.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnEditEmployee.Location = new System.Drawing.Point(0, 0);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(1548, 621);
            this.btnEditEmployee.TabIndex = 7;
            this.btnEditEmployee.Text = "จัดการพนักงาน";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BorderRadius = 5;
            this.btnDeleteEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteEmployee.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(427, 63);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(180, 45);
            this.btnDeleteEmployee.TabIndex = 13;
            this.btnDeleteEmployee.Text = "ลบข้อมูลพนักงาน";
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEdit.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(216, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(180, 45);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "แก้ไขข้อมูลพนักงาน";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BorderRadius = 5;
            this.btnAddEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddEmployee.Font = new System.Drawing.Font("Prompt", 9F);
            this.btnAddEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.Location = new System.Drawing.Point(13, 63);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(180, 45);
            this.btnAddEmployee.TabIndex = 11;
            this.btnAddEmployee.Text = "เพิ่มข้อมูลพนักงาน";
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // DataGridEmployee
            // 
            this.DataGridEmployee.AllowUserToAddRows = false;
            this.DataGridEmployee.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridEmployee.AutoGenerateColumns = false;
            this.DataGridEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridEmployee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridEmployee.ColumnHeadersHeight = 40;
            this.DataGridEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empidDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn,
            this.empcodeDataGridViewTextBoxColumn,
            this.emppasswordDataGridViewTextBoxColumn,
            this.emproleDataGridViewTextBoxColumn,
            this.empemailDataGridViewTextBoxColumn});
            this.DataGridEmployee.DataSource = this.employeeBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridEmployee.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridEmployee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridEmployee.Location = new System.Drawing.Point(13, 134);
            this.DataGridEmployee.Name = "DataGridEmployee";
            this.DataGridEmployee.ReadOnly = true;
            this.DataGridEmployee.RowHeadersVisible = false;
            this.DataGridEmployee.RowHeadersWidth = 51;
            this.DataGridEmployee.RowTemplate.Height = 30;
            this.DataGridEmployee.Size = new System.Drawing.Size(1515, 469);
            this.DataGridEmployee.TabIndex = 0;
            this.DataGridEmployee.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridEmployee.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridEmployee.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridEmployee.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridEmployee.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridEmployee.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridEmployee.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridEmployee.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridEmployee.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DataGridEmployee.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridEmployee.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridEmployee.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridEmployee.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridEmployee.ThemeStyle.ReadOnly = true;
            this.DataGridEmployee.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridEmployee.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridEmployee.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridEmployee.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DataGridEmployee.ThemeStyle.RowsStyle.Height = 30;
            this.DataGridEmployee.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridEmployee.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridEmployee_CellContentClick);
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(Deksomboon_Inkjet.Class.Employee);
            // 
            // empidDataGridViewTextBoxColumn
            // 
            this.empidDataGridViewTextBoxColumn.DataPropertyName = "emp_id";
            this.empidDataGridViewTextBoxColumn.HeaderText = "emp_id";
            this.empidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.empidDataGridViewTextBoxColumn.Name = "empidDataGridViewTextBoxColumn";
            this.empidDataGridViewTextBoxColumn.ReadOnly = true;
            this.empidDataGridViewTextBoxColumn.Visible = false;
            // 
            // empnameDataGridViewTextBoxColumn
            // 
            this.empnameDataGridViewTextBoxColumn.DataPropertyName = "emp_name";
            this.empnameDataGridViewTextBoxColumn.HeaderText = "ชื่อพนักงาน";
            this.empnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
            this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empcodeDataGridViewTextBoxColumn
            // 
            this.empcodeDataGridViewTextBoxColumn.DataPropertyName = "emp_code";
            this.empcodeDataGridViewTextBoxColumn.HeaderText = "รหัสพนักงาน";
            this.empcodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.empcodeDataGridViewTextBoxColumn.Name = "empcodeDataGridViewTextBoxColumn";
            this.empcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emppasswordDataGridViewTextBoxColumn
            // 
            this.emppasswordDataGridViewTextBoxColumn.DataPropertyName = "emp_password";
            this.emppasswordDataGridViewTextBoxColumn.HeaderText = "emp_password";
            this.emppasswordDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emppasswordDataGridViewTextBoxColumn.Name = "emppasswordDataGridViewTextBoxColumn";
            this.emppasswordDataGridViewTextBoxColumn.ReadOnly = true;
            this.emppasswordDataGridViewTextBoxColumn.Visible = false;
            // 
            // emproleDataGridViewTextBoxColumn
            // 
            this.emproleDataGridViewTextBoxColumn.DataPropertyName = "emp_role";
            this.emproleDataGridViewTextBoxColumn.HeaderText = "ตําแหน่ง";
            this.emproleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emproleDataGridViewTextBoxColumn.Name = "emproleDataGridViewTextBoxColumn";
            this.emproleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empemailDataGridViewTextBoxColumn
            // 
            this.empemailDataGridViewTextBoxColumn.DataPropertyName = "emp_email";
            this.empemailDataGridViewTextBoxColumn.HeaderText = "อีเมล";
            this.empemailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.empemailDataGridViewTextBoxColumn.Name = "empemailDataGridViewTextBoxColumn";
            this.empemailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ucEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditEmployee);
            this.Name = "ucEmployee";
            this.Size = new System.Drawing.Size(1548, 621);
            this.Load += new System.EventHandler(this.ucEmployee_Load_1);
            this.btnEditEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox btnEditEmployee;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridEmployee;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private Guna.UI2.WinForms.Guna2Button btnDeleteEmployee;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAddEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn empidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emppasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emproleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empemailDataGridViewTextBoxColumn;
    }
}
