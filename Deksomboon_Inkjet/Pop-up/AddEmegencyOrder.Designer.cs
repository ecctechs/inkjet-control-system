namespace Deksomboon_Inkjet.Pop_up
{
    partial class AddEmegencyOrder
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboPosition = new Guna.UI2.WinForms.Guna2ComboBox();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtBatch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboMaterial = new Guna.UI2.WinForms.Guna2ComboBox();
            this.materialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtFormula = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSLife = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtLine = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInkjet = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtBBF = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenDigit = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLineFull = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLineID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInkjetID = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCheckForm = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOrdID = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboOrdType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtEmpcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmppass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenDigitOld = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSumCount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmpID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOrderDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Prompt", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(172, 23);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(289, 31);
            this.guna2HtmlLabel1.TabIndex = 54;
            this.guna2HtmlLabel1.Text = "เพิ่มงานด่วน";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.AutoSize = false;
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(33, 540);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel8.TabIndex = 70;
            this.guna2HtmlLabel8.Text = "แทรกตําแหน่ง";
            // 
            // cboPosition
            // 
            this.cboPosition.BackColor = System.Drawing.Color.Transparent;
            this.cboPosition.DataSource = this.orderBindingSource;
            this.cboPosition.DisplayMember = "ord_position";
            this.cboPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPosition.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPosition.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.cboPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPosition.ItemHeight = 30;
            this.cboPosition.Location = new System.Drawing.Point(182, 535);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(281, 36);
            this.cboPosition.TabIndex = 69;
            this.cboPosition.ValueMember = "ord_position";
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(Deksomboon_Inkjet.Class.Order);
            // 
            // txtBatch
            // 
            this.txtBatch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBatch.DefaultText = "";
            this.txtBatch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBatch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBatch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatch.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtBatch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatch.Location = new System.Drawing.Point(180, 413);
            this.txtBatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBatch.MaxLength = 1;
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.PasswordChar = '\0';
            this.txtBatch.PlaceholderText = "";
            this.txtBatch.SelectedText = "";
            this.txtBatch.Size = new System.Drawing.Size(45, 36);
            this.txtBatch.TabIndex = 68;
            this.txtBatch.TextChanged += new System.EventHandler(this.batchnumberbox_TextChanged);
            this.txtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatch_KeyPress);
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.AutoSize = false;
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(33, 418);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel7.TabIndex = 67;
            this.guna2HtmlLabel7.Text = "Batch";
            // 
            // cboMaterial
            // 
            this.cboMaterial.BackColor = System.Drawing.Color.Transparent;
            this.cboMaterial.DataSource = this.materialBindingSource;
            this.cboMaterial.DisplayMember = "material_des";
            this.cboMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaterial.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMaterial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMaterial.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.cboMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMaterial.ItemHeight = 30;
            this.cboMaterial.Location = new System.Drawing.Point(180, 220);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(281, 36);
            this.cboMaterial.TabIndex = 66;
            this.cboMaterial.ValueMember = "material_id";
            this.cboMaterial.SelectedIndexChanged += new System.EventHandler(this.cboMaterial_SelectedIndexChanged);
            this.cboMaterial.SelectionChangeCommitted += new System.EventHandler(this.cboMaterial_SelectionChangeCommitted);
            // 
            // materialBindingSource
            // 
            this.materialBindingSource.DataSource = typeof(Deksomboon_Inkjet.Class.Material);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.Font = new System.Drawing.Font("Prompt", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(343, 817);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 45);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "ปิด";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSave.Font = new System.Drawing.Font("Prompt", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(226, 817);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 45);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFormula
            // 
            this.txtFormula.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFormula.DefaultText = "";
            this.txtFormula.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFormula.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFormula.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFormula.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFormula.Enabled = false;
            this.txtFormula.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFormula.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtFormula.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFormula.Location = new System.Drawing.Point(180, 284);
            this.txtFormula.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFormula.MaxLength = 3;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.PasswordChar = '\0';
            this.txtFormula.PlaceholderText = "";
            this.txtFormula.ReadOnly = true;
            this.txtFormula.SelectedText = "";
            this.txtFormula.Size = new System.Drawing.Size(281, 36);
            this.txtFormula.TabIndex = 61;
            // 
            // txtSLife
            // 
            this.txtSLife.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSLife.DefaultText = "";
            this.txtSLife.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSLife.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSLife.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSLife.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSLife.Enabled = false;
            this.txtSLife.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSLife.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtSLife.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSLife.Location = new System.Drawing.Point(180, 348);
            this.txtSLife.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSLife.Name = "txtSLife";
            this.txtSLife.PasswordChar = '\0';
            this.txtSLife.PlaceholderText = "";
            this.txtSLife.ReadOnly = true;
            this.txtSLife.SelectedText = "";
            this.txtSLife.Size = new System.Drawing.Size(281, 36);
            this.txtSLife.TabIndex = 60;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(33, 289);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel6.TabIndex = 59;
            this.guna2HtmlLabel6.Text = "Formula";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(33, 353);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel5.TabIndex = 58;
            this.guna2HtmlLabel5.Text = "SLife";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(33, 156);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel4.TabIndex = 57;
            this.guna2HtmlLabel4.Text = "อินเจ็ก";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(33, 225);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel3.TabIndex = 56;
            this.guna2HtmlLabel3.Text = "รายละเอียดวัสดุ";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(33, 89);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel2.TabIndex = 55;
            this.guna2HtmlLabel2.Text = "ไลน์ผลิต";
            // 
            // txtLine
            // 
            this.txtLine.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLine.DefaultText = "";
            this.txtLine.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLine.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLine.Enabled = false;
            this.txtLine.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLine.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtLine.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLine.Location = new System.Drawing.Point(180, 89);
            this.txtLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLine.MaxLength = 3;
            this.txtLine.Name = "txtLine";
            this.txtLine.PasswordChar = '\0';
            this.txtLine.PlaceholderText = "";
            this.txtLine.ReadOnly = true;
            this.txtLine.SelectedText = "";
            this.txtLine.Size = new System.Drawing.Size(281, 36);
            this.txtLine.TabIndex = 72;
            // 
            // txtInkjet
            // 
            this.txtInkjet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInkjet.DefaultText = "";
            this.txtInkjet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInkjet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInkjet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInkjet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInkjet.Enabled = false;
            this.txtInkjet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInkjet.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtInkjet.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInkjet.Location = new System.Drawing.Point(180, 151);
            this.txtInkjet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInkjet.MaxLength = 3;
            this.txtInkjet.Name = "txtInkjet";
            this.txtInkjet.PasswordChar = '\0';
            this.txtInkjet.PlaceholderText = "";
            this.txtInkjet.ReadOnly = true;
            this.txtInkjet.SelectedText = "";
            this.txtInkjet.Size = new System.Drawing.Size(281, 36);
            this.txtInkjet.TabIndex = 73;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.txtBBF);
            this.guna2GroupBox1.Controls.Add(this.txtTenDigit);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(35, 653);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.guna2GroupBox1.Size = new System.Drawing.Size(428, 128);
            this.guna2GroupBox1.TabIndex = 76;
            this.guna2GroupBox1.Text = "พรีวิว";
            // 
            // txtBBF
            // 
            this.txtBBF.BackColor = System.Drawing.Color.White;
            this.txtBBF.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBBF.DefaultText = "";
            this.txtBBF.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBBF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBBF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBBF.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBBF.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBBF.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBBF.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtBBF.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBBF.Location = new System.Drawing.Point(5, 81);
            this.txtBBF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBBF.Name = "txtBBF";
            this.txtBBF.PasswordChar = '\0';
            this.txtBBF.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtBBF.PlaceholderText = "";
            this.txtBBF.ReadOnly = true;
            this.txtBBF.SelectedText = "";
            this.txtBBF.Size = new System.Drawing.Size(418, 36);
            this.txtBBF.TabIndex = 62;
            // 
            // txtTenDigit
            // 
            this.txtTenDigit.BackColor = System.Drawing.Color.White;
            this.txtTenDigit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDigit.DefaultText = "";
            this.txtTenDigit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenDigit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenDigit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDigit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDigit.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTenDigit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDigit.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtTenDigit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDigit.Location = new System.Drawing.Point(5, 45);
            this.txtTenDigit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDigit.Name = "txtTenDigit";
            this.txtTenDigit.PasswordChar = '\0';
            this.txtTenDigit.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtTenDigit.PlaceholderText = "";
            this.txtTenDigit.ReadOnly = true;
            this.txtTenDigit.SelectedText = "";
            this.txtTenDigit.Size = new System.Drawing.Size(418, 36);
            this.txtTenDigit.TabIndex = 61;
            // 
            // txtLineFull
            // 
            this.txtLineFull.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLineFull.DefaultText = "";
            this.txtLineFull.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLineFull.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLineFull.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLineFull.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLineFull.Enabled = false;
            this.txtLineFull.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLineFull.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtLineFull.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLineFull.Location = new System.Drawing.Point(2, 1);
            this.txtLineFull.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLineFull.MaxLength = 3;
            this.txtLineFull.Name = "txtLineFull";
            this.txtLineFull.PasswordChar = '\0';
            this.txtLineFull.PlaceholderText = "";
            this.txtLineFull.ReadOnly = true;
            this.txtLineFull.SelectedText = "";
            this.txtLineFull.Size = new System.Drawing.Size(79, 26);
            this.txtLineFull.TabIndex = 77;
            this.txtLineFull.Visible = false;
            // 
            // txtLineID
            // 
            this.txtLineID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLineID.DefaultText = "";
            this.txtLineID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLineID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLineID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLineID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLineID.Enabled = false;
            this.txtLineID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLineID.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtLineID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLineID.Location = new System.Drawing.Point(202, 1);
            this.txtLineID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLineID.MaxLength = 3;
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.PasswordChar = '\0';
            this.txtLineID.PlaceholderText = "";
            this.txtLineID.ReadOnly = true;
            this.txtLineID.SelectedText = "";
            this.txtLineID.Size = new System.Drawing.Size(79, 26);
            this.txtLineID.TabIndex = 78;
            this.txtLineID.Visible = false;
            // 
            // txtInkjetID
            // 
            this.txtInkjetID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInkjetID.DefaultText = "";
            this.txtInkjetID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInkjetID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInkjetID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInkjetID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInkjetID.Enabled = false;
            this.txtInkjetID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInkjetID.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtInkjetID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInkjetID.Location = new System.Drawing.Point(383, 1);
            this.txtInkjetID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInkjetID.MaxLength = 3;
            this.txtInkjetID.Name = "txtInkjetID";
            this.txtInkjetID.PasswordChar = '\0';
            this.txtInkjetID.PlaceholderText = "";
            this.txtInkjetID.ReadOnly = true;
            this.txtInkjetID.SelectedText = "";
            this.txtInkjetID.Size = new System.Drawing.Size(79, 26);
            this.txtInkjetID.TabIndex = 79;
            this.txtInkjetID.Visible = false;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.AutoSize = false;
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(33, 481);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel9.TabIndex = 103;
            this.guna2HtmlLabel9.Text = "วันที่";
            // 
            // txtCheckForm
            // 
            this.txtCheckForm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckForm.DefaultText = "";
            this.txtCheckForm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCheckForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCheckForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCheckForm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCheckForm.Enabled = false;
            this.txtCheckForm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCheckForm.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtCheckForm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCheckForm.Location = new System.Drawing.Point(2, 56);
            this.txtCheckForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCheckForm.MaxLength = 3;
            this.txtCheckForm.Name = "txtCheckForm";
            this.txtCheckForm.PasswordChar = '\0';
            this.txtCheckForm.PlaceholderText = "";
            this.txtCheckForm.ReadOnly = true;
            this.txtCheckForm.SelectedText = "";
            this.txtCheckForm.Size = new System.Drawing.Size(79, 26);
            this.txtCheckForm.TabIndex = 104;
            this.txtCheckForm.Visible = false;
            // 
            // txtOrdID
            // 
            this.txtOrdID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOrdID.DefaultText = "";
            this.txtOrdID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOrdID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOrdID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrdID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrdID.Enabled = false;
            this.txtOrdID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrdID.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtOrdID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrdID.Location = new System.Drawing.Point(111, 55);
            this.txtOrdID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrdID.MaxLength = 3;
            this.txtOrdID.Name = "txtOrdID";
            this.txtOrdID.PasswordChar = '\0';
            this.txtOrdID.PlaceholderText = "";
            this.txtOrdID.ReadOnly = true;
            this.txtOrdID.SelectedText = "";
            this.txtOrdID.Size = new System.Drawing.Size(79, 26);
            this.txtOrdID.TabIndex = 105;
            this.txtOrdID.Visible = false;
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(33, 604);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(141, 31);
            this.guna2HtmlLabel10.TabIndex = 106;
            this.guna2HtmlLabel10.Text = "ประเภทงาน";
            // 
            // cboOrdType
            // 
            this.cboOrdType.BackColor = System.Drawing.Color.Transparent;
            this.cboOrdType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOrdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdType.Enabled = false;
            this.cboOrdType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboOrdType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboOrdType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboOrdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboOrdType.ItemHeight = 30;
            this.cboOrdType.Items.AddRange(new object[] {
            "งานทั่วไป",
            "งานเร่งด่วน"});
            this.cboOrdType.Location = new System.Drawing.Point(183, 599);
            this.cboOrdType.Name = "cboOrdType";
            this.cboOrdType.Size = new System.Drawing.Size(280, 36);
            this.cboOrdType.TabIndex = 107;
            // 
            // txtEmpcode
            // 
            this.txtEmpcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpcode.DefaultText = "";
            this.txtEmpcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmpcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmpcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpcode.Enabled = false;
            this.txtEmpcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpcode.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtEmpcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpcode.Location = new System.Drawing.Point(12, 835);
            this.txtEmpcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmpcode.MaxLength = 3;
            this.txtEmpcode.Name = "txtEmpcode";
            this.txtEmpcode.PasswordChar = '\0';
            this.txtEmpcode.PlaceholderText = "";
            this.txtEmpcode.ReadOnly = true;
            this.txtEmpcode.SelectedText = "";
            this.txtEmpcode.Size = new System.Drawing.Size(79, 26);
            this.txtEmpcode.TabIndex = 108;
            this.txtEmpcode.Visible = false;
            // 
            // txtEmppass
            // 
            this.txtEmppass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmppass.DefaultText = "";
            this.txtEmppass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmppass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmppass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmppass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmppass.Enabled = false;
            this.txtEmppass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmppass.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtEmppass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmppass.Location = new System.Drawing.Point(97, 835);
            this.txtEmppass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmppass.MaxLength = 3;
            this.txtEmppass.Name = "txtEmppass";
            this.txtEmppass.PasswordChar = '\0';
            this.txtEmppass.PlaceholderText = "";
            this.txtEmppass.ReadOnly = true;
            this.txtEmppass.SelectedText = "";
            this.txtEmppass.Size = new System.Drawing.Size(79, 26);
            this.txtEmppass.TabIndex = 109;
            this.txtEmppass.Visible = false;
            // 
            // txtTenDigitOld
            // 
            this.txtTenDigitOld.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDigitOld.DefaultText = "";
            this.txtTenDigitOld.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenDigitOld.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenDigitOld.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDigitOld.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenDigitOld.Enabled = false;
            this.txtTenDigitOld.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDigitOld.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtTenDigitOld.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenDigitOld.Location = new System.Drawing.Point(33, 801);
            this.txtTenDigitOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDigitOld.MaxLength = 3;
            this.txtTenDigitOld.Name = "txtTenDigitOld";
            this.txtTenDigitOld.PasswordChar = '\0';
            this.txtTenDigitOld.PlaceholderText = "";
            this.txtTenDigitOld.ReadOnly = true;
            this.txtTenDigitOld.SelectedText = "";
            this.txtTenDigitOld.Size = new System.Drawing.Size(157, 26);
            this.txtTenDigitOld.TabIndex = 110;
            this.txtTenDigitOld.Visible = false;
            // 
            // txtSumCount
            // 
            this.txtSumCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSumCount.DefaultText = "";
            this.txtSumCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSumCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSumCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSumCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSumCount.Enabled = false;
            this.txtSumCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSumCount.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtSumCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSumCount.Location = new System.Drawing.Point(241, 56);
            this.txtSumCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSumCount.MaxLength = 3;
            this.txtSumCount.Name = "txtSumCount";
            this.txtSumCount.PasswordChar = '\0';
            this.txtSumCount.PlaceholderText = "";
            this.txtSumCount.ReadOnly = true;
            this.txtSumCount.SelectedText = "";
            this.txtSumCount.Size = new System.Drawing.Size(79, 26);
            this.txtSumCount.TabIndex = 111;
            this.txtSumCount.Visible = false;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpID.DefaultText = "";
            this.txtEmpID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmpID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmpID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpID.Enabled = false;
            this.txtEmpID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpID.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtEmpID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpID.Location = new System.Drawing.Point(326, 56);
            this.txtEmpID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmpID.MaxLength = 3;
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.PasswordChar = '\0';
            this.txtEmpID.PlaceholderText = "";
            this.txtEmpID.ReadOnly = true;
            this.txtEmpID.SelectedText = "";
            this.txtEmpID.Size = new System.Drawing.Size(79, 26);
            this.txtEmpID.TabIndex = 112;
            this.txtEmpID.Visible = false;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOrderDate.DefaultText = "";
            this.txtOrderDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOrderDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOrderDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrderDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrderDate.Font = new System.Drawing.Font("Prompt", 10.2F);
            this.txtOrderDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOrderDate.Location = new System.Drawing.Point(411, 55);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderDate.MaxLength = 3;
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.PasswordChar = '\0';
            this.txtOrderDate.PlaceholderText = "";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.SelectedText = "";
            this.txtOrderDate.Size = new System.Drawing.Size(79, 26);
            this.txtOrderDate.TabIndex = 113;
            this.txtOrderDate.Visible = false;
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.CalendarFont = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(183, 479);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(280, 33);
            this.guna2DateTimePicker1.TabIndex = 114;
            this.guna2DateTimePicker1.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged_1);
            // 
            // AddEmegencyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 874);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.txtSumCount);
            this.Controls.Add(this.txtTenDigitOld);
            this.Controls.Add(this.txtEmppass);
            this.Controls.Add(this.txtEmpcode);
            this.Controls.Add(this.cboOrdType);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.txtOrdID);
            this.Controls.Add(this.txtCheckForm);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.txtInkjetID);
            this.Controls.Add(this.txtLineID);
            this.Controls.Add(this.txtLineFull);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.txtInkjet);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.cboMaterial);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.txtSLife);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddEmegencyOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEmegencyOrder";
            this.Load += new System.EventHandler(this.AddEmegencyOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2ComboBox cboPosition;
        private Guna.UI2.WinForms.Guna2TextBox txtBatch;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2ComboBox cboMaterial;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtFormula;
        private Guna.UI2.WinForms.Guna2TextBox txtSLife;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtLine;
        private Guna.UI2.WinForms.Guna2TextBox txtInkjet;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtBBF;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDigit;
        private System.Windows.Forms.BindingSource materialBindingSource;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private Guna.UI2.WinForms.Guna2TextBox txtLineFull;
        private Guna.UI2.WinForms.Guna2TextBox txtLineID;
        private Guna.UI2.WinForms.Guna2TextBox txtInkjetID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2TextBox txtCheckForm;
        private Guna.UI2.WinForms.Guna2TextBox txtOrdID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2ComboBox cboOrdType;
        private Guna.UI2.WinForms.Guna2TextBox txtEmpcode;
        private Guna.UI2.WinForms.Guna2TextBox txtEmppass;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDigitOld;
        private Guna.UI2.WinForms.Guna2TextBox txtSumCount;
        private Guna.UI2.WinForms.Guna2TextBox txtEmpID;
        private Guna.UI2.WinForms.Guna2TextBox txtOrderDate;
        private System.Windows.Forms.DateTimePicker guna2DateTimePicker1;
    }
}