namespace Deksomboon_Inkjet.UserControls
{
    partial class ucOrder
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpload = new Guna.UI2.WinForms.Guna2Button();
            this.DataGridOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ordidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inkjetidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inkjetnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialdesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slifeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordbatchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordpositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordtempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orddateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordertempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2GroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordertempBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.tableLayoutPanel1);
            this.guna2GroupBox1.Controls.Add(this.DataGridOrder);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(978, 599);
            this.guna2GroupBox1.TabIndex = 5;
            this.guna2GroupBox1.Text = "จัดการออร์เดอร์";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpload, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 52);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Font = new System.Drawing.Font("Prompt", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "เพิ่มข้อมูลออร์เดอร์";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnEdit.Location = new System.Drawing.Point(189, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(180, 45);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "แก้ไขข้อมูลออร์เดอร์";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BorderRadius = 5;
            this.btnSubmit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSubmit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSubmit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSubmit.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(795, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(180, 45);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "ส่งออร์เดอร์";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(375, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 45);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "ลบข้อมูลออร์เดอร์";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BorderRadius = 5;
            this.btnUpload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.btnUpload.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.Location = new System.Drawing.Point(561, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(180, 45);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "อัพโหลดสินค้า";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // DataGridOrder
            // 
            this.DataGridOrder.AllowUserToAddRows = false;
            this.DataGridOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridOrder.AutoGenerateColumns = false;
            this.DataGridOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridOrder.ColumnHeadersHeight = 40;
            this.DataGridOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordidDataGridViewTextBoxColumn,
            this.materialidDataGridViewTextBoxColumn,
            this.locationidDataGridViewTextBoxColumn,
            this.perindDataGridViewTextBoxColumn,
            this.locationnameDataGridViewTextBoxColumn,
            this.inkjetidDataGridViewTextBoxColumn,
            this.inkjetnameDataGridViewTextBoxColumn,
            this.materialdesDataGridViewTextBoxColumn,
            this.formulaDataGridViewTextBoxColumn,
            this.slifeDataGridViewTextBoxColumn,
            this.ordbatchDataGridViewTextBoxColumn,
            this.ordtypeDataGridViewTextBoxColumn,
            this.ordstatusDataGridViewTextBoxColumn,
            this.ordpositionDataGridViewTextBoxColumn,
            this.ordtempDataGridViewTextBoxColumn,
            this.orddateDataGridViewTextBoxColumn});
            this.DataGridOrder.DataSource = this.ordertempBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridOrder.Location = new System.Drawing.Point(16, 119);
            this.DataGridOrder.Name = "DataGridOrder";
            this.DataGridOrder.ReadOnly = true;
            this.DataGridOrder.RowHeadersVisible = false;
            this.DataGridOrder.RowHeadersWidth = 51;
            this.DataGridOrder.RowTemplate.Height = 30;
            this.DataGridOrder.Size = new System.Drawing.Size(945, 450);
            this.DataGridOrder.TabIndex = 19;
            this.DataGridOrder.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridOrder.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridOrder.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridOrder.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridOrder.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DataGridOrder.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridOrder.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridOrder.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridOrder.ThemeStyle.ReadOnly = true;
            this.DataGridOrder.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridOrder.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridOrder.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridOrder.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.DataGridOrder.ThemeStyle.RowsStyle.Height = 30;
            this.DataGridOrder.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridOrder.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ordidDataGridViewTextBoxColumn
            // 
            this.ordidDataGridViewTextBoxColumn.DataPropertyName = "ord_id";
            this.ordidDataGridViewTextBoxColumn.HeaderText = "ord_id";
            this.ordidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordidDataGridViewTextBoxColumn.Name = "ordidDataGridViewTextBoxColumn";
            this.ordidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordidDataGridViewTextBoxColumn.Visible = false;
            // 
            // materialidDataGridViewTextBoxColumn
            // 
            this.materialidDataGridViewTextBoxColumn.DataPropertyName = "material_id";
            this.materialidDataGridViewTextBoxColumn.HeaderText = "material_id";
            this.materialidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.materialidDataGridViewTextBoxColumn.Name = "materialidDataGridViewTextBoxColumn";
            this.materialidDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialidDataGridViewTextBoxColumn.Visible = false;
            // 
            // locationidDataGridViewTextBoxColumn
            // 
            this.locationidDataGridViewTextBoxColumn.DataPropertyName = "location_id";
            this.locationidDataGridViewTextBoxColumn.HeaderText = "location_id";
            this.locationidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.locationidDataGridViewTextBoxColumn.Name = "locationidDataGridViewTextBoxColumn";
            this.locationidDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationidDataGridViewTextBoxColumn.Visible = false;
            // 
            // perindDataGridViewTextBoxColumn
            // 
            this.perindDataGridViewTextBoxColumn.DataPropertyName = "per_ind";
            this.perindDataGridViewTextBoxColumn.HeaderText = "per_ind";
            this.perindDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.perindDataGridViewTextBoxColumn.Name = "perindDataGridViewTextBoxColumn";
            this.perindDataGridViewTextBoxColumn.ReadOnly = true;
            this.perindDataGridViewTextBoxColumn.Visible = false;
            // 
            // locationnameDataGridViewTextBoxColumn
            // 
            this.locationnameDataGridViewTextBoxColumn.DataPropertyName = "location_name";
            this.locationnameDataGridViewTextBoxColumn.HeaderText = "ไลน์ผลิต";
            this.locationnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.locationnameDataGridViewTextBoxColumn.Name = "locationnameDataGridViewTextBoxColumn";
            this.locationnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inkjetidDataGridViewTextBoxColumn
            // 
            this.inkjetidDataGridViewTextBoxColumn.DataPropertyName = "inkjet_id";
            this.inkjetidDataGridViewTextBoxColumn.HeaderText = "inkjet_id";
            this.inkjetidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.inkjetidDataGridViewTextBoxColumn.Name = "inkjetidDataGridViewTextBoxColumn";
            this.inkjetidDataGridViewTextBoxColumn.ReadOnly = true;
            this.inkjetidDataGridViewTextBoxColumn.Visible = false;
            // 
            // inkjetnameDataGridViewTextBoxColumn
            // 
            this.inkjetnameDataGridViewTextBoxColumn.DataPropertyName = "inkjet_name";
            this.inkjetnameDataGridViewTextBoxColumn.HeaderText = "ชื่ออินเจ็ก";
            this.inkjetnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.inkjetnameDataGridViewTextBoxColumn.Name = "inkjetnameDataGridViewTextBoxColumn";
            this.inkjetnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // materialdesDataGridViewTextBoxColumn
            // 
            this.materialdesDataGridViewTextBoxColumn.DataPropertyName = "material_des";
            this.materialdesDataGridViewTextBoxColumn.HeaderText = "รายละเอียดวัสดุ";
            this.materialdesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.materialdesDataGridViewTextBoxColumn.Name = "materialdesDataGridViewTextBoxColumn";
            this.materialdesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formulaDataGridViewTextBoxColumn
            // 
            this.formulaDataGridViewTextBoxColumn.DataPropertyName = "formula";
            this.formulaDataGridViewTextBoxColumn.HeaderText = "Formula";
            this.formulaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.formulaDataGridViewTextBoxColumn.Name = "formulaDataGridViewTextBoxColumn";
            this.formulaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // slifeDataGridViewTextBoxColumn
            // 
            this.slifeDataGridViewTextBoxColumn.DataPropertyName = "slife";
            this.slifeDataGridViewTextBoxColumn.HeaderText = "SLife";
            this.slifeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.slifeDataGridViewTextBoxColumn.Name = "slifeDataGridViewTextBoxColumn";
            this.slifeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordbatchDataGridViewTextBoxColumn
            // 
            this.ordbatchDataGridViewTextBoxColumn.DataPropertyName = "ord_batch";
            this.ordbatchDataGridViewTextBoxColumn.HeaderText = "Batch";
            this.ordbatchDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordbatchDataGridViewTextBoxColumn.Name = "ordbatchDataGridViewTextBoxColumn";
            this.ordbatchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordtypeDataGridViewTextBoxColumn
            // 
            this.ordtypeDataGridViewTextBoxColumn.DataPropertyName = "ord_type";
            this.ordtypeDataGridViewTextBoxColumn.HeaderText = "ประเภทงาน";
            this.ordtypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordtypeDataGridViewTextBoxColumn.Name = "ordtypeDataGridViewTextBoxColumn";
            this.ordtypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordstatusDataGridViewTextBoxColumn
            // 
            this.ordstatusDataGridViewTextBoxColumn.DataPropertyName = "ord_status";
            this.ordstatusDataGridViewTextBoxColumn.HeaderText = "ord_status";
            this.ordstatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordstatusDataGridViewTextBoxColumn.Name = "ordstatusDataGridViewTextBoxColumn";
            this.ordstatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordstatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // ordpositionDataGridViewTextBoxColumn
            // 
            this.ordpositionDataGridViewTextBoxColumn.DataPropertyName = "ord_position";
            this.ordpositionDataGridViewTextBoxColumn.HeaderText = "ord_position";
            this.ordpositionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordpositionDataGridViewTextBoxColumn.Name = "ordpositionDataGridViewTextBoxColumn";
            this.ordpositionDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordpositionDataGridViewTextBoxColumn.Visible = false;
            // 
            // ordtempDataGridViewTextBoxColumn
            // 
            this.ordtempDataGridViewTextBoxColumn.DataPropertyName = "ord_temp";
            this.ordtempDataGridViewTextBoxColumn.HeaderText = "ord_temp";
            this.ordtempDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ordtempDataGridViewTextBoxColumn.Name = "ordtempDataGridViewTextBoxColumn";
            this.ordtempDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordtempDataGridViewTextBoxColumn.Visible = false;
            // 
            // orddateDataGridViewTextBoxColumn
            // 
            this.orddateDataGridViewTextBoxColumn.DataPropertyName = "ord_date";
            this.orddateDataGridViewTextBoxColumn.HeaderText = "ord_date";
            this.orddateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orddateDataGridViewTextBoxColumn.Name = "orddateDataGridViewTextBoxColumn";
            this.orddateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orddateDataGridViewTextBoxColumn.Visible = false;
            // 
            // ordertempBindingSource
            // 
            this.ordertempBindingSource.DataSource = typeof(Deksomboon_Inkjet.Class.Order_temp);
            // 
            // ucOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "ucOrder";
            this.Size = new System.Drawing.Size(978, 599);
            this.Load += new System.EventHandler(this.ucOrder_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordertempBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2Button btnUpload;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridOrder;
        private System.Windows.Forms.BindingSource ordertempBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inkjetidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inkjetnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialdesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slifeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordbatchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordstatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordpositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordtempDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orddateDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
